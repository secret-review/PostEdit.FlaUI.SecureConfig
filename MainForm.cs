using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text;
using System.Text.Json;

namespace PostEdit
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private readonly FormData _formData = new FormData();
        private const int MaxTabWidth = 1200;

        // 投稿内容を保持するDataTable
        private DataTable sendDt = new DataTable();

        // ページャー（外部クラスとして切り離し済み）
        private Pager pager;

        // ページごとのUI状態を保持
        private List<PageState> pageStates;

        private void Form1_Resize(object sender, EventArgs e)
        {
            int clientWidth = this.ClientSize.Width;
            int tabWidth = Math.Min(clientWidth, MaxTabWidth);

            tab_Main.Width = tabWidth;
            tab_Main.Left = (clientWidth - tabWidth) / 2;
            tab_Main.Height = this.ClientSize.Height - tab_Main.Top - 20;
        }

        private void FormChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox cb)
            {
                // CheckBox の場合
                if (cb.Checked)
                    _formData.Add(cb.Text);
                else
                    _formData.Remove(cb.Text);
            }
            else if (sender is NumericUpDown nud)
            {
                // NumericUpDown の場合
                _formData._createNumber = (int)nud.Value;
            }
            else if (sender is TextBox tb)
            {
                // TextBox の場合
                _formData._maxLength = int.TryParse(tb.Text, out int maxLength) ? maxLength : 0;
            }

            // 共通処理
            rtb_投稿スタイル.Text = _formData.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CopilotHelper.LoadAppId();

            //SSHトンネル設定
            SshTunnel.Start();

            //試しに接続
            var dt = SQL.Select("SELECT * FROM dat_queue");

            //フォーム初期値をセット
            _formData._createNumber = (int)nud_生成数.Value;
            _formData._maxLength = int.TryParse(tb_文字数.Text, out int maxLength) ? maxLength : 0;
        }

        private async void btn_生成_Click(object sender, EventArgs e)
        {
            string thema = rtb_投稿テーマ.Text;
            string prompt = rtb_投稿スタイル.Text;
            if (string.IsNullOrEmpty(prompt) || string.IsNullOrEmpty(thema)) return;

            await CopilotHelper.StartCopilotAndWait();
            var inputBox = CopilotHelper.FindInputBox();
            CopilotHelper.InputAndSend(inputBox, thema + "\r\n" + prompt);
            CopilotHelper.WaitForResponseComplete();

            if (CopilotHelper.CopyLatestResponse())
            {
                string json = Clipboard.ContainsText() ? Clipboard.GetText() : "";

                if (IsValidJson(json))
                {
                    var root = JObject.Parse(json);
                    var posts = root["posts"] as JArray;
                    if (posts == null || posts.Count == 0) return;

                    // JArray → DataTable に変換
                    sendDt = JsonConvert.DeserializeObject<DataTable>(posts.ToString());
                    if (sendDt == null || sendDt.Rows.Count == 0) return;

                    // PageState を sendDt から作成
                    pageStates = sendDt.AsEnumerable()
                        .Select(row => new PageState
                        {
                            message = row["text"]?.ToString(),
                            IsChkChecked = false,
                            selectedTime = "自動",
                            selectedPosition = "末尾"
                        })
                        .ToList();

                    // ページャー初期化（1ページ1件）
                    pager = new Pager(sendDt.Rows.Count, 1);

                    // 最初のページを表示
                    UpdatePageView();
                    // 現在ページのUI状態を復元
                    RestorePageState();                    
                }
            }

            //使ったスレッドは削除
            CopilotHelper.DeleteThread();

            //Copilotウィンドウを閉じる
            CopilotHelper.CloseCopilotWindow();

            //タブの切替
            tab_Main.SelectedTab = tabPage_案一覧;
        }

        /// <summary>
        /// ページビュー更新処理
        /// </summary>
        private void UpdatePageView()
        {
            if (pager == null || sendDt == null) return;

            lbl_PageInfo.Text = $"{pager.CurrentPage.ToString("00")} / {pager.TotalPages.ToString("00")}";
            rtb_投稿文.Text = GetPageText(sendDt, pager);
        }

        private string GetPageText(DataTable source, Pager pager)
        {
            var (start, end) = pager.GetRowRange();
            StringBuilder sb = new StringBuilder();

            for (int i = start; i < end; i++)
            {
                sb.AppendLine(source.Rows[i]["text"].ToString());
            }

            return sb.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveCurrentPageState();
            pager?.NextPage();
            UpdatePageView();
            RestorePageState();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SaveCurrentPageState();
            pager?.PrevPage();
            //UpdatePageView();
            RestorePageState();
        }

        /// <summary>
        /// 現在ページのUI状態を保存
        /// </summary>
        private void SaveCurrentPageState()
        {
            if (pager == null || pageStates == null) return;
            var state = pageStates[pager.CurrentPage - 1];

            // 本文を格納
            state.message = rtb_投稿文.Text;

            // チェックボックスの「チェック状態」を保存
            state.IsChkChecked = chk_登録対象.Checked;

            // 投稿時刻のラジオボタンの選択状態を保存
            if (rad_案一覧_自動.Checked) state.selectedTime = "自動";
            else if (rad_案一覧_9時.Checked) state.selectedTime = "9時";
            else if (rad_案一覧_21時.Checked) state.selectedTime = "21時";

            // 投稿位置のラジオボタンの選択状態を保存
            if (rad_末尾追加.Checked) state.selectedPosition = "末尾";
            else if (rad_先頭追加.Checked) state.selectedPosition = "先頭";
        }

        /// <summary>
        /// 現在ページのUI状態を復元
        /// </summary>
        private void RestorePageState()
        {
            if (pager == null || pageStates == null) return;
            var state = pageStates[pager.CurrentPage - 1];

            rtb_投稿文.Text = state.message;

            chk_登録対象.Checked = state.IsChkChecked;

            rad_案一覧_自動.Checked = state.selectedTime == "自動";
            rad_案一覧_9時.Checked = state.selectedTime == "9時";
            rad_案一覧_21時.Checked = state.selectedTime == "21時";

            rad_末尾追加.Checked = state.selectedPosition == "末尾";
            rad_先頭追加.Checked = state.selectedPosition == "先頭";
        }

        private static bool IsValidJson(string json)
        {
            try
            {
                JsonDocument.Parse(json);
                return true;
            }
            catch (System.Text.Json.JsonException)
            {
                return false;
            }
        }

        private void btn_DB登録_Click(object sender, EventArgs e)
        {
            //DataTableに投稿内容が含まれてなければ終了
            if (sendDt.Rows.Count == 0) return;

            //現在テーブルに登録されているキューを全件取得
            DataTable allQue = SQL.GetQueue();

            //DB登録対象だけを抽出
            foreach (var item in pageStates)
            {
                if (item.IsChkChecked)
                {
                    string time = "";

                    if (item.selectedTime == "自動")
                    {
                        //テーブル件数が20件未満の場合は、優先的に21:00にする
                        if (allQue.Rows.Count < 20)
                        {
                            time = "21:00";
                        }
                        else if (allQue.Rows.Count > 0) // ← 空チェックを追加
                        {
                            //DB内のテーブル件数が20件以上なら、21:00と9:00で交互に登録されるようにする

                            if (item.selectedPosition == "先頭")
                            {
                                //先頭の登録時刻を調べる
                                var ts = (TimeSpan)allQue.Rows[0]["post_time"];
                                string topTime = ts.ToString(@"hh\:mm");

                                time = (topTime == "21:00") ? "09:00" : "21:00";
                            }
                            else
                            {
                                //末尾の登録時刻
                                var tsTail = (TimeSpan)allQue.Rows[allQue.Rows.Count - 1]["post_time"];
                                string lastTime = tsTail.ToString(@"hh\:mm");

                                time = (lastTime == "21:00") ? "09:00" : "21:00";
                            }
                        }
                        else
                        {
                            // キューが空の場合のデフォルト値
                            time = "21:00";
                        }

                        //指定した位置に追加する
                        if (item.selectedPosition == "先頭")
                        {
                            SQL.InsertAtHead(time, item.message);
                        }
                        else
                        {
                            SQL.InsertAtTail(time, item.message); // ← 修正: 末尾は InsertAtTail
                        }
                    }
                    else
                    {
                        //指定した時刻で登録する
                        time = item.selectedTime;

                        if (item.selectedPosition == "先頭")
                        {
                            SQL.InsertAtHead(time, item.message);
                        }
                        else
                        {
                            SQL.InsertAtTail(time, item.message); // ← 修正: 末尾は InsertAtTail
                        }
                    }
                }
            }

            MessageBox.Show("登録完了");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SSHトンネルを閉じる
            SshTunnel.Stop();
        }

        private void tab_Main_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPage_予約編集)
            {
                //取得したテーブル内容をDataSourceに指定
                dgv_投稿リスト.AutoGenerateColumns = false;
                dgv_投稿リスト.DataSource = DbCache.GetQueue();
            }
        }

        private void dgv_投稿リスト_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_投稿リスト.CurrentRow == null) return;
            //選択行
            var row = dgv_投稿リスト.CurrentRow;

            //フォームに反映
            //投稿予定時刻
            var time = row.Cells["post_time"].Value.ToString();
            rad_09.Checked = (time.Contains("09:00"));
            rad_21.Checked = (time.Contains("21:00"));

            //投稿内容
            rtb_投稿内容.Text = row.Cells["message"].Value.ToString();
        }

        private void btn_投稿更新_Click(object sender, EventArgs e)
        {
            if (dgv_投稿リスト.CurrentRow == null) return;
            //選択行
            var row = dgv_投稿リスト.CurrentRow;

            //選択されている行のsort_indexを取得
            int sortIndex = (int)row.Cells["sort_index"].Value;

            //投稿予定時刻
            var postTime = new[] { rad_09, rad_21 }
            .FirstOrDefault(r => r.Checked)?
            .Text;

            //投稿内容
            string message = rtb_投稿内容.Text;

            //DBとDBキャッシュをUPDATE
            DbCache.UpdateQueue(sortIndex, postTime, message);
        }

        private void btn_投稿削除_Click(object sender, EventArgs e)
        {
            if (dgv_投稿リスト.CurrentRow == null) return;
            //選択行
            var row = dgv_投稿リスト.CurrentRow;

            //選択されている行のsort_indexを取得
            int sortIndex = (int)row.Cells["sort_index"].Value;

            //DBとDBキャッシュの対象行の削除
            DbCache.DeleteQueue(sortIndex);
        }
    }

    /// <summary>
    /// ページごとのUI状態を保持するクラス
    /// </summary>
    public class PageState
    {
        public string message { get; set; }
        public bool IsChkChecked { get; set; }   // ← Checked状態を保持
        public string selectedTime { get; set; } = "自動"; // デフォルト値
        public string selectedPosition { get; set; } = "末尾";
    }
}