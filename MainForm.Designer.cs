namespace PostEdit
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tlp_外枠 = new TableLayoutPanel();
            tab_Main = new TabControl();
            tabPage_案作成 = new TabPage();
            rtb_投稿スタイル = new RichTextBox();
            tlp_生成設定外側 = new TableLayoutPanel();
            tlp_生成設定 = new TableLayoutPanel();
            tlp_文字数 = new TableLayoutPanel();
            lbl_文字数 = new Label();
            tb_文字数 = new TextBox();
            btn_生成 = new Button();
            tlp_生成数 = new TableLayoutPanel();
            nud_生成数 = new NumericUpDown();
            label1 = new Label();
            tlp_chk全体 = new TableLayoutPanel();
            tlp_chk内部 = new TableLayoutPanel();
            chk_バズり重視 = new CheckBox();
            chk_問いかける感じ = new CheckBox();
            chk_堅苦しくない = new CheckBox();
            chk_ライト層に響く = new CheckBox();
            chk_口語調を使わない = new CheckBox();
            chk_感情に訴える = new CheckBox();
            chk_丁寧に = new CheckBox();
            chk_詩的な表現 = new CheckBox();
            chk_命令系にしない = new CheckBox();
            chk_緊迫感を出す = new CheckBox();
            chk_印象深く = new CheckBox();
            chk_インパクト重視 = new CheckBox();
            rtb_投稿テーマ = new RichTextBox();
            tabPage_案一覧 = new TabPage();
            tlp_投稿選択外枠 = new TableLayoutPanel();
            tlp_pager = new TableLayoutPanel();
            btn_next = new Button();
            btn_preview = new Button();
            lbl_PageInfo = new Label();
            tlp_時刻設定 = new TableLayoutPanel();
            rad_案一覧_21時 = new RadioButton();
            rad_案一覧_9時 = new RadioButton();
            rad_案一覧_自動 = new RadioButton();
            tlp_投稿位置 = new TableLayoutPanel();
            rad_先頭追加 = new RadioButton();
            rad_末尾追加 = new RadioButton();
            tlp_DB登録ボタン外枠 = new TableLayoutPanel();
            btn_DB登録 = new Button();
            chk_登録対象 = new CheckBox();
            rtb_投稿文 = new RichTextBox();
            tabPage_予約編集 = new TabPage();
            btn_投稿削除 = new Button();
            btn_投稿更新 = new Button();
            tlp_投稿内容 = new TableLayoutPanel();
            label4 = new Label();
            rtb_投稿内容 = new RichTextBox();
            tlp_投稿日時 = new TableLayoutPanel();
            tlp_投稿時刻 = new TableLayoutPanel();
            rad_09 = new RadioButton();
            rad_21 = new RadioButton();
            label5 = new Label();
            dgv_投稿リスト = new DataGridView();
            sort_index = new DataGridViewTextBoxColumn();
            post_time = new DataGridViewTextBoxColumn();
            message = new DataGridViewTextBoxColumn();
            tlp_外枠.SuspendLayout();
            tab_Main.SuspendLayout();
            tabPage_案作成.SuspendLayout();
            tlp_生成設定外側.SuspendLayout();
            tlp_生成設定.SuspendLayout();
            tlp_文字数.SuspendLayout();
            tlp_生成数.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_生成数).BeginInit();
            tlp_chk全体.SuspendLayout();
            tlp_chk内部.SuspendLayout();
            tabPage_案一覧.SuspendLayout();
            tlp_投稿選択外枠.SuspendLayout();
            tlp_pager.SuspendLayout();
            tlp_時刻設定.SuspendLayout();
            tlp_投稿位置.SuspendLayout();
            tlp_DB登録ボタン外枠.SuspendLayout();
            tabPage_予約編集.SuspendLayout();
            tlp_投稿内容.SuspendLayout();
            tlp_投稿日時.SuspendLayout();
            tlp_投稿時刻.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_投稿リスト).BeginInit();
            SuspendLayout();
            // 
            // tlp_外枠
            // 
            tlp_外枠.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_外枠.ColumnCount = 3;
            tlp_外枠.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tlp_外枠.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tlp_外枠.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tlp_外枠.Controls.Add(tab_Main, 1, 0);
            tlp_外枠.Location = new Point(10, 10);
            tlp_外枠.Margin = new Padding(0);
            tlp_外枠.Name = "tlp_外枠";
            tlp_外枠.RowCount = 1;
            tlp_外枠.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_外枠.Size = new Size(794, 580);
            tlp_外枠.TabIndex = 0;
            // 
            // tab_Main
            // 
            tab_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            tab_Main.Controls.Add(tabPage_案作成);
            tab_Main.Controls.Add(tabPage_案一覧);
            tab_Main.Controls.Add(tabPage_予約編集);
            tab_Main.Location = new Point(42, 3);
            tab_Main.MaximumSize = new Size(1200, 0);
            tab_Main.Name = "tab_Main";
            tab_Main.Padding = new Point(20, 5);
            tab_Main.SelectedIndex = 0;
            tab_Main.Size = new Size(708, 574);
            tab_Main.TabIndex = 0;
            tab_Main.Selected += tab_Main_Selected;
            // 
            // tabPage_案作成
            // 
            tabPage_案作成.Controls.Add(rtb_投稿スタイル);
            tabPage_案作成.Controls.Add(tlp_生成設定外側);
            tabPage_案作成.Controls.Add(tlp_chk全体);
            tabPage_案作成.Controls.Add(rtb_投稿テーマ);
            tabPage_案作成.Location = new Point(4, 28);
            tabPage_案作成.Name = "tabPage_案作成";
            tabPage_案作成.Padding = new Padding(3);
            tabPage_案作成.Size = new Size(700, 542);
            tabPage_案作成.TabIndex = 0;
            tabPage_案作成.Text = "案作成";
            tabPage_案作成.UseVisualStyleBackColor = true;
            // 
            // rtb_投稿スタイル
            // 
            rtb_投稿スタイル.Location = new Point(20, 230);
            rtb_投稿スタイル.Name = "rtb_投稿スタイル";
            rtb_投稿スタイル.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtb_投稿スタイル.Size = new Size(660, 140);
            rtb_投稿スタイル.TabIndex = 9;
            rtb_投稿スタイル.Text = "";
            // 
            // tlp_生成設定外側
            // 
            tlp_生成設定外側.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tlp_生成設定外側.BackColor = Color.Gainsboro;
            tlp_生成設定外側.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            tlp_生成設定外側.ColumnCount = 1;
            tlp_生成設定外側.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_生成設定外側.Controls.Add(tlp_生成設定, 0, 0);
            tlp_生成設定外側.Location = new Point(560, 379);
            tlp_生成設定外側.Margin = new Padding(0);
            tlp_生成設定外側.Name = "tlp_生成設定外側";
            tlp_生成設定外側.RowCount = 1;
            tlp_生成設定外側.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_生成設定外側.Size = new Size(120, 149);
            tlp_生成設定外側.TabIndex = 8;
            // 
            // tlp_生成設定
            // 
            tlp_生成設定.ColumnCount = 1;
            tlp_生成設定.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_生成設定.Controls.Add(tlp_文字数, 0, 0);
            tlp_生成設定.Controls.Add(btn_生成, 0, 3);
            tlp_生成設定.Controls.Add(tlp_生成数, 0, 2);
            tlp_生成設定.Location = new Point(13, 13);
            tlp_生成設定.Margin = new Padding(10);
            tlp_生成設定.Name = "tlp_生成設定";
            tlp_生成設定.RowCount = 4;
            tlp_生成設定.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_生成設定.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            tlp_生成設定.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_生成設定.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_生成設定.Size = new Size(94, 123);
            tlp_生成設定.TabIndex = 7;
            // 
            // tlp_文字数
            // 
            tlp_文字数.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_文字数.ColumnCount = 2;
            tlp_文字数.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlp_文字数.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_文字数.Controls.Add(lbl_文字数, 1, 0);
            tlp_文字数.Controls.Add(tb_文字数, 0, 0);
            tlp_文字数.Location = new Point(0, 0);
            tlp_文字数.Margin = new Padding(0);
            tlp_文字数.Name = "tlp_文字数";
            tlp_文字数.RowCount = 1;
            tlp_文字数.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_文字数.Size = new Size(94, 28);
            tlp_文字数.TabIndex = 2;
            // 
            // lbl_文字数
            // 
            lbl_文字数.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_文字数.AutoSize = true;
            lbl_文字数.Location = new Point(53, 0);
            lbl_文字数.Name = "lbl_文字数";
            lbl_文字数.Size = new Size(38, 28);
            lbl_文字数.TabIndex = 2;
            lbl_文字数.Text = "文字";
            lbl_文字数.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_文字数
            // 
            tb_文字数.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tb_文字数.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tb_文字数.Location = new Point(0, 2);
            tb_文字数.Margin = new Padding(0, 2, 0, 0);
            tb_文字数.MaxLength = 4;
            tb_文字数.Name = "tb_文字数";
            tb_文字数.Size = new Size(50, 27);
            tb_文字数.TabIndex = 3;
            tb_文字数.Text = "280";
            tb_文字数.TextAlign = HorizontalAlignment.Center;
            tb_文字数.TextChanged += FormChanged;
            // 
            // btn_生成
            // 
            btn_生成.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_生成.BackColor = Color.DodgerBlue;
            btn_生成.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btn_生成.ForeColor = Color.Transparent;
            btn_生成.Location = new Point(0, 76);
            btn_生成.Margin = new Padding(0, 10, 0, 0);
            btn_生成.Name = "btn_生成";
            btn_生成.Size = new Size(94, 47);
            btn_生成.TabIndex = 6;
            btn_生成.Text = "投稿案生成";
            btn_生成.UseVisualStyleBackColor = false;
            btn_生成.Click += btn_生成_Click;
            // 
            // tlp_生成数
            // 
            tlp_生成数.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_生成数.ColumnCount = 2;
            tlp_生成数.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlp_生成数.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_生成数.Controls.Add(nud_生成数, 0, 0);
            tlp_生成数.Controls.Add(label1, 1, 0);
            tlp_生成数.Location = new Point(0, 38);
            tlp_生成数.Margin = new Padding(0);
            tlp_生成数.Name = "tlp_生成数";
            tlp_生成数.RowCount = 1;
            tlp_生成数.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_生成数.Size = new Size(94, 28);
            tlp_生成数.TabIndex = 4;
            // 
            // nud_生成数
            // 
            nud_生成数.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            nud_生成数.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nud_生成数.Location = new Point(0, 0);
            nud_生成数.Margin = new Padding(0);
            nud_生成数.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nud_生成数.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_生成数.Name = "nud_生成数";
            nud_生成数.Size = new Size(50, 33);
            nud_生成数.TabIndex = 0;
            nud_生成数.TextAlign = HorizontalAlignment.Center;
            nud_生成数.Value = new decimal(new int[] { 5, 0, 0, 0 });
            nud_生成数.ValueChanged += FormChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(53, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 28);
            label1.TabIndex = 1;
            label1.Text = "個";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tlp_chk全体
            // 
            tlp_chk全体.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_chk全体.BackColor = Color.Gainsboro;
            tlp_chk全体.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            tlp_chk全体.ColumnCount = 1;
            tlp_chk全体.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_chk全体.Controls.Add(tlp_chk内部, 0, 0);
            tlp_chk全体.Location = new Point(20, 380);
            tlp_chk全体.Margin = new Padding(0);
            tlp_chk全体.Name = "tlp_chk全体";
            tlp_chk全体.RowCount = 1;
            tlp_chk全体.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_chk全体.Size = new Size(530, 148);
            tlp_chk全体.TabIndex = 5;
            // 
            // tlp_chk内部
            // 
            tlp_chk内部.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_chk内部.BackColor = Color.WhiteSmoke;
            tlp_chk内部.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlp_chk内部.ColumnCount = 4;
            tlp_chk内部.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlp_chk内部.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlp_chk内部.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlp_chk内部.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlp_chk内部.Controls.Add(chk_バズり重視, 3, 2);
            tlp_chk内部.Controls.Add(chk_問いかける感じ, 3, 1);
            tlp_chk内部.Controls.Add(chk_堅苦しくない, 2, 2);
            tlp_chk内部.Controls.Add(chk_ライト層に響く, 0, 2);
            tlp_chk内部.Controls.Add(chk_口語調を使わない, 1, 2);
            tlp_chk内部.Controls.Add(chk_感情に訴える, 3, 0);
            tlp_chk内部.Controls.Add(chk_丁寧に, 2, 1);
            tlp_chk内部.Controls.Add(chk_詩的な表現, 0, 0);
            tlp_chk内部.Controls.Add(chk_命令系にしない, 1, 1);
            tlp_chk内部.Controls.Add(chk_緊迫感を出す, 2, 0);
            tlp_chk内部.Controls.Add(chk_印象深く, 0, 1);
            tlp_chk内部.Controls.Add(chk_インパクト重視, 1, 0);
            tlp_chk内部.Location = new Point(13, 13);
            tlp_chk内部.Margin = new Padding(10);
            tlp_chk内部.Name = "tlp_chk内部";
            tlp_chk内部.RowCount = 3;
            tlp_chk内部.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlp_chk内部.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlp_chk内部.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlp_chk内部.Size = new Size(504, 122);
            tlp_chk内部.TabIndex = 7;
            // 
            // chk_バズり重視
            // 
            chk_バズり重視.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chk_バズり重視.AutoSize = true;
            chk_バズり重視.Location = new Point(386, 81);
            chk_バズり重視.Margin = new Padding(10, 0, 0, 0);
            chk_バズり重視.Name = "chk_バズり重視";
            chk_バズり重視.Size = new Size(117, 40);
            chk_バズり重視.TabIndex = 3;
            chk_バズり重視.Text = "バズり重視";
            chk_バズり重視.UseVisualStyleBackColor = true;
            chk_バズり重視.CheckedChanged += FormChanged;
            // 
            // chk_問いかける感じ
            // 
            chk_問いかける感じ.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chk_問いかける感じ.AutoSize = true;
            chk_問いかける感じ.Location = new Point(386, 41);
            chk_問いかける感じ.Margin = new Padding(10, 0, 0, 0);
            chk_問いかける感じ.Name = "chk_問いかける感じ";
            chk_問いかける感じ.Size = new Size(117, 39);
            chk_問いかける感じ.TabIndex = 3;
            chk_問いかける感じ.Text = "問いかける感じ";
            chk_問いかける感じ.UseVisualStyleBackColor = true;
            chk_問いかける感じ.CheckedChanged += FormChanged;
            // 
            // chk_堅苦しくない
            // 
            chk_堅苦しくない.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chk_堅苦しくない.AutoSize = true;
            chk_堅苦しくない.Location = new Point(261, 81);
            chk_堅苦しくない.Margin = new Padding(10, 0, 0, 0);
            chk_堅苦しくない.Name = "chk_堅苦しくない";
            chk_堅苦しくない.Size = new Size(114, 40);
            chk_堅苦しくない.TabIndex = 2;
            chk_堅苦しくない.Text = "堅苦しくない";
            chk_堅苦しくない.UseVisualStyleBackColor = true;
            chk_堅苦しくない.CheckedChanged += FormChanged;
            // 
            // chk_ライト層に響く
            // 
            chk_ライト層に響く.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chk_ライト層に響く.AutoSize = true;
            chk_ライト層に響く.Location = new Point(11, 81);
            chk_ライト層に響く.Margin = new Padding(10, 0, 0, 0);
            chk_ライト層に響く.Name = "chk_ライト層に響く";
            chk_ライト層に響く.Size = new Size(114, 40);
            chk_ライト層に響く.TabIndex = 0;
            chk_ライト層に響く.Text = "ライト層に響く";
            chk_ライト層に響く.UseVisualStyleBackColor = true;
            chk_ライト層に響く.CheckedChanged += FormChanged;
            // 
            // chk_口語調を使わない
            // 
            chk_口語調を使わない.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chk_口語調を使わない.AutoSize = true;
            chk_口語調を使わない.Location = new Point(136, 81);
            chk_口語調を使わない.Margin = new Padding(10, 0, 0, 0);
            chk_口語調を使わない.Name = "chk_口語調を使わない";
            chk_口語調を使わない.Size = new Size(114, 40);
            chk_口語調を使わない.TabIndex = 1;
            chk_口語調を使わない.Text = "口語調を使わない";
            chk_口語調を使わない.UseVisualStyleBackColor = true;
            chk_口語調を使わない.CheckedChanged += FormChanged;
            // 
            // chk_感情に訴える
            // 
            chk_感情に訴える.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chk_感情に訴える.AutoSize = true;
            chk_感情に訴える.Location = new Point(386, 1);
            chk_感情に訴える.Margin = new Padding(10, 0, 0, 0);
            chk_感情に訴える.Name = "chk_感情に訴える";
            chk_感情に訴える.Size = new Size(117, 39);
            chk_感情に訴える.TabIndex = 3;
            chk_感情に訴える.Text = "感情に訴える";
            chk_感情に訴える.UseVisualStyleBackColor = true;
            chk_感情に訴える.CheckedChanged += FormChanged;
            // 
            // chk_丁寧に
            // 
            chk_丁寧に.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chk_丁寧に.AutoSize = true;
            chk_丁寧に.Location = new Point(261, 41);
            chk_丁寧に.Margin = new Padding(10, 0, 0, 0);
            chk_丁寧に.Name = "chk_丁寧に";
            chk_丁寧に.Size = new Size(114, 39);
            chk_丁寧に.TabIndex = 2;
            chk_丁寧に.Text = "丁寧に";
            chk_丁寧に.UseVisualStyleBackColor = true;
            chk_丁寧に.CheckedChanged += FormChanged;
            // 
            // chk_詩的な表現
            // 
            chk_詩的な表現.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chk_詩的な表現.AutoSize = true;
            chk_詩的な表現.Location = new Point(11, 1);
            chk_詩的な表現.Margin = new Padding(10, 0, 0, 0);
            chk_詩的な表現.Name = "chk_詩的な表現";
            chk_詩的な表現.Size = new Size(114, 39);
            chk_詩的な表現.TabIndex = 0;
            chk_詩的な表現.Text = "詩的な表現";
            chk_詩的な表現.UseVisualStyleBackColor = true;
            chk_詩的な表現.CheckedChanged += FormChanged;
            // 
            // chk_命令系にしない
            // 
            chk_命令系にしない.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chk_命令系にしない.AutoSize = true;
            chk_命令系にしない.Location = new Point(136, 41);
            chk_命令系にしない.Margin = new Padding(10, 0, 0, 0);
            chk_命令系にしない.Name = "chk_命令系にしない";
            chk_命令系にしない.Size = new Size(114, 39);
            chk_命令系にしない.TabIndex = 1;
            chk_命令系にしない.Text = "命令系にしない";
            chk_命令系にしない.UseVisualStyleBackColor = true;
            chk_命令系にしない.CheckedChanged += FormChanged;
            // 
            // chk_緊迫感を出す
            // 
            chk_緊迫感を出す.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chk_緊迫感を出す.AutoSize = true;
            chk_緊迫感を出す.Location = new Point(261, 1);
            chk_緊迫感を出す.Margin = new Padding(10, 0, 0, 0);
            chk_緊迫感を出す.Name = "chk_緊迫感を出す";
            chk_緊迫感を出す.Size = new Size(114, 39);
            chk_緊迫感を出す.TabIndex = 2;
            chk_緊迫感を出す.Text = "緊迫感を出す";
            chk_緊迫感を出す.UseVisualStyleBackColor = true;
            chk_緊迫感を出す.CheckedChanged += FormChanged;
            // 
            // chk_印象深く
            // 
            chk_印象深く.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chk_印象深く.AutoSize = true;
            chk_印象深く.Location = new Point(11, 41);
            chk_印象深く.Margin = new Padding(10, 0, 0, 0);
            chk_印象深く.Name = "chk_印象深く";
            chk_印象深く.Size = new Size(114, 39);
            chk_印象深く.TabIndex = 0;
            chk_印象深く.Text = "妥当性重視";
            chk_印象深く.UseVisualStyleBackColor = true;
            chk_印象深く.CheckedChanged += FormChanged;
            // 
            // chk_インパクト重視
            // 
            chk_インパクト重視.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chk_インパクト重視.AutoSize = true;
            chk_インパクト重視.Location = new Point(136, 1);
            chk_インパクト重視.Margin = new Padding(10, 0, 0, 0);
            chk_インパクト重視.Name = "chk_インパクト重視";
            chk_インパクト重視.Size = new Size(114, 39);
            chk_インパクト重視.TabIndex = 1;
            chk_インパクト重視.Text = "インパクト重視";
            chk_インパクト重視.UseVisualStyleBackColor = true;
            chk_インパクト重視.CheckedChanged += FormChanged;
            // 
            // rtb_投稿テーマ
            // 
            rtb_投稿テーマ.Location = new Point(20, 20);
            rtb_投稿テーマ.Margin = new Padding(0);
            rtb_投稿テーマ.Name = "rtb_投稿テーマ";
            rtb_投稿テーマ.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtb_投稿テーマ.Size = new Size(660, 200);
            rtb_投稿テーマ.TabIndex = 0;
            rtb_投稿テーマ.Text = "";
            // 
            // tabPage_案一覧
            // 
            tabPage_案一覧.Controls.Add(tlp_投稿選択外枠);
            tabPage_案一覧.Controls.Add(tlp_DB登録ボタン外枠);
            tabPage_案一覧.Controls.Add(rtb_投稿文);
            tabPage_案一覧.Location = new Point(4, 28);
            tabPage_案一覧.Margin = new Padding(0);
            tabPage_案一覧.Name = "tabPage_案一覧";
            tabPage_案一覧.Padding = new Padding(3);
            tabPage_案一覧.Size = new Size(700, 542);
            tabPage_案一覧.TabIndex = 1;
            tabPage_案一覧.Text = "案一覧";
            tabPage_案一覧.UseVisualStyleBackColor = true;
            // 
            // tlp_投稿選択外枠
            // 
            tlp_投稿選択外枠.BackColor = Color.WhiteSmoke;
            tlp_投稿選択外枠.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlp_投稿選択外枠.ColumnCount = 3;
            tlp_投稿選択外枠.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tlp_投稿選択外枠.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_投稿選択外枠.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tlp_投稿選択外枠.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlp_投稿選択外枠.Controls.Add(tlp_pager, 2, 0);
            tlp_投稿選択外枠.Controls.Add(tlp_時刻設定, 0, 0);
            tlp_投稿選択外枠.Controls.Add(tlp_投稿位置, 1, 0);
            tlp_投稿選択外枠.Location = new Point(20, 420);
            tlp_投稿選択外枠.Margin = new Padding(0);
            tlp_投稿選択外枠.Name = "tlp_投稿選択外枠";
            tlp_投稿選択外枠.RowCount = 1;
            tlp_投稿選択外枠.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_投稿選択外枠.Size = new Size(660, 50);
            tlp_投稿選択外枠.TabIndex = 3;
            // 
            // tlp_pager
            // 
            tlp_pager.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_pager.ColumnCount = 3;
            tlp_pager.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlp_pager.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlp_pager.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlp_pager.Controls.Add(btn_next, 2, 0);
            tlp_pager.Controls.Add(btn_preview, 0, 0);
            tlp_pager.Controls.Add(lbl_PageInfo, 1, 0);
            tlp_pager.Location = new Point(479, 1);
            tlp_pager.Margin = new Padding(0);
            tlp_pager.Name = "tlp_pager";
            tlp_pager.RowCount = 1;
            tlp_pager.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_pager.Size = new Size(180, 48);
            tlp_pager.TabIndex = 1;
            // 
            // btn_next
            // 
            btn_next.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_next.BackColor = Color.Gainsboro;
            btn_next.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btn_next.Location = new Point(126, 0);
            btn_next.Margin = new Padding(0);
            btn_next.Name = "btn_next";
            btn_next.Size = new Size(54, 48);
            btn_next.TabIndex = 2;
            btn_next.Text = ">>";
            btn_next.UseVisualStyleBackColor = false;
            btn_next.Click += btnNext_Click;
            // 
            // btn_preview
            // 
            btn_preview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_preview.BackColor = Color.Gainsboro;
            btn_preview.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btn_preview.Location = new Point(0, 0);
            btn_preview.Margin = new Padding(0);
            btn_preview.Name = "btn_preview";
            btn_preview.Size = new Size(54, 48);
            btn_preview.TabIndex = 0;
            btn_preview.Text = "<<";
            btn_preview.UseVisualStyleBackColor = false;
            btn_preview.Click += btnPrev_Click;
            // 
            // lbl_PageInfo
            // 
            lbl_PageInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_PageInfo.AutoSize = true;
            lbl_PageInfo.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbl_PageInfo.Location = new Point(57, 0);
            lbl_PageInfo.Name = "lbl_PageInfo";
            lbl_PageInfo.Size = new Size(66, 48);
            lbl_PageInfo.TabIndex = 1;
            lbl_PageInfo.Text = "1 / 5";
            lbl_PageInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlp_時刻設定
            // 
            tlp_時刻設定.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_時刻設定.ColumnCount = 3;
            tlp_時刻設定.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlp_時刻設定.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlp_時刻設定.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlp_時刻設定.Controls.Add(rad_案一覧_21時, 2, 0);
            tlp_時刻設定.Controls.Add(rad_案一覧_9時, 1, 0);
            tlp_時刻設定.Controls.Add(rad_案一覧_自動, 0, 0);
            tlp_時刻設定.Location = new Point(11, 1);
            tlp_時刻設定.Margin = new Padding(10, 0, 0, 0);
            tlp_時刻設定.Name = "tlp_時刻設定";
            tlp_時刻設定.RowCount = 1;
            tlp_時刻設定.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_時刻設定.Size = new Size(170, 48);
            tlp_時刻設定.TabIndex = 4;
            // 
            // rad_案一覧_21時
            // 
            rad_案一覧_21時.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rad_案一覧_21時.AutoSize = true;
            rad_案一覧_21時.Location = new Point(112, 0);
            rad_案一覧_21時.Margin = new Padding(0);
            rad_案一覧_21時.Name = "rad_案一覧_21時";
            rad_案一覧_21時.Size = new Size(58, 48);
            rad_案一覧_21時.TabIndex = 2;
            rad_案一覧_21時.Text = "21時";
            rad_案一覧_21時.UseVisualStyleBackColor = true;
            // 
            // rad_案一覧_9時
            // 
            rad_案一覧_9時.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rad_案一覧_9時.AutoSize = true;
            rad_案一覧_9時.Location = new Point(56, 0);
            rad_案一覧_9時.Margin = new Padding(0);
            rad_案一覧_9時.Name = "rad_案一覧_9時";
            rad_案一覧_9時.Size = new Size(56, 48);
            rad_案一覧_9時.TabIndex = 1;
            rad_案一覧_9時.Text = "09時";
            rad_案一覧_9時.UseVisualStyleBackColor = true;
            // 
            // rad_案一覧_自動
            // 
            rad_案一覧_自動.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rad_案一覧_自動.AutoSize = true;
            rad_案一覧_自動.Checked = true;
            rad_案一覧_自動.Location = new Point(0, 0);
            rad_案一覧_自動.Margin = new Padding(0);
            rad_案一覧_自動.Name = "rad_案一覧_自動";
            rad_案一覧_自動.Size = new Size(56, 48);
            rad_案一覧_自動.TabIndex = 0;
            rad_案一覧_自動.TabStop = true;
            rad_案一覧_自動.Text = "自動";
            rad_案一覧_自動.UseVisualStyleBackColor = true;
            // 
            // tlp_投稿位置
            // 
            tlp_投稿位置.Anchor = AnchorStyles.None;
            tlp_投稿位置.ColumnCount = 2;
            tlp_投稿位置.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_投稿位置.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_投稿位置.Controls.Add(rad_先頭追加, 1, 0);
            tlp_投稿位置.Controls.Add(rad_末尾追加, 0, 0);
            tlp_投稿位置.Location = new Point(211, 1);
            tlp_投稿位置.Margin = new Padding(20, 0, 0, 0);
            tlp_投稿位置.Name = "tlp_投稿位置";
            tlp_投稿位置.RowCount = 1;
            tlp_投稿位置.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_投稿位置.Size = new Size(257, 48);
            tlp_投稿位置.TabIndex = 5;
            // 
            // rad_先頭追加
            // 
            rad_先頭追加.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rad_先頭追加.AutoSize = true;
            rad_先頭追加.Location = new Point(128, 0);
            rad_先頭追加.Margin = new Padding(0);
            rad_先頭追加.Name = "rad_先頭追加";
            rad_先頭追加.Size = new Size(129, 48);
            rad_先頭追加.TabIndex = 2;
            rad_先頭追加.Text = "キューの先頭に追加";
            rad_先頭追加.UseVisualStyleBackColor = true;
            // 
            // rad_末尾追加
            // 
            rad_末尾追加.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rad_末尾追加.AutoSize = true;
            rad_末尾追加.Checked = true;
            rad_末尾追加.Location = new Point(0, 0);
            rad_末尾追加.Margin = new Padding(0);
            rad_末尾追加.Name = "rad_末尾追加";
            rad_末尾追加.Size = new Size(128, 48);
            rad_末尾追加.TabIndex = 1;
            rad_末尾追加.TabStop = true;
            rad_末尾追加.Text = "キューの最後に追加";
            rad_末尾追加.UseVisualStyleBackColor = true;
            // 
            // tlp_DB登録ボタン外枠
            // 
            tlp_DB登録ボタン外枠.ColumnCount = 3;
            tlp_DB登録ボタン外枠.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tlp_DB登録ボタン外枠.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_DB登録ボタン外枠.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tlp_DB登録ボタン外枠.Controls.Add(btn_DB登録, 2, 0);
            tlp_DB登録ボタン外枠.Controls.Add(chk_登録対象, 1, 0);
            tlp_DB登録ボタン外枠.Location = new Point(20, 480);
            tlp_DB登録ボタン外枠.Name = "tlp_DB登録ボタン外枠";
            tlp_DB登録ボタン外枠.RowCount = 1;
            tlp_DB登録ボタン外枠.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_DB登録ボタン外枠.Size = new Size(660, 50);
            tlp_DB登録ボタン外枠.TabIndex = 2;
            // 
            // btn_DB登録
            // 
            btn_DB登録.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_DB登録.BackColor = Color.FromArgb(0, 230, 155);
            btn_DB登録.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btn_DB登録.ForeColor = SystemColors.MenuText;
            btn_DB登録.Location = new Point(480, 0);
            btn_DB登録.Margin = new Padding(0);
            btn_DB登録.Name = "btn_DB登録";
            btn_DB登録.Size = new Size(180, 50);
            btn_DB登録.TabIndex = 2;
            btn_DB登録.Text = "DBに登録";
            btn_DB登録.UseVisualStyleBackColor = false;
            btn_DB登録.Click += btn_DB登録_Click;
            // 
            // chk_登録対象
            // 
            chk_登録対象.Anchor = AnchorStyles.None;
            chk_登録対象.AutoSize = true;
            chk_登録対象.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            chk_登録対象.Location = new Point(268, 13);
            chk_登録対象.Margin = new Padding(0);
            chk_登録対象.Name = "chk_登録対象";
            chk_登録対象.Size = new Size(123, 24);
            chk_登録対象.TabIndex = 3;
            chk_登録対象.Text = "登録対象にする";
            chk_登録対象.UseVisualStyleBackColor = true;
            // 
            // rtb_投稿文
            // 
            rtb_投稿文.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            rtb_投稿文.Location = new Point(20, 20);
            rtb_投稿文.Name = "rtb_投稿文";
            rtb_投稿文.Size = new Size(660, 380);
            rtb_投稿文.TabIndex = 0;
            rtb_投稿文.Text = "\n";
            // 
            // tabPage_予約編集
            // 
            tabPage_予約編集.Controls.Add(btn_投稿削除);
            tabPage_予約編集.Controls.Add(btn_投稿更新);
            tabPage_予約編集.Controls.Add(tlp_投稿内容);
            tabPage_予約編集.Controls.Add(tlp_投稿日時);
            tabPage_予約編集.Controls.Add(dgv_投稿リスト);
            tabPage_予約編集.Location = new Point(4, 28);
            tabPage_予約編集.Name = "tabPage_予約編集";
            tabPage_予約編集.Padding = new Padding(3);
            tabPage_予約編集.Size = new Size(700, 542);
            tabPage_予約編集.TabIndex = 2;
            tabPage_予約編集.Text = "予約編集";
            tabPage_予約編集.UseVisualStyleBackColor = true;
            // 
            // btn_投稿削除
            // 
            btn_投稿削除.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_投稿削除.BackColor = Color.DeepPink;
            btn_投稿削除.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btn_投稿削除.ForeColor = SystemColors.ControlText;
            btn_投稿削除.Location = new Point(472, 500);
            btn_投稿削除.Name = "btn_投稿削除";
            btn_投稿削除.Size = new Size(100, 30);
            btn_投稿削除.TabIndex = 10;
            btn_投稿削除.Text = "削除";
            btn_投稿削除.UseVisualStyleBackColor = false;
            btn_投稿削除.Click += btn_投稿削除_Click;
            // 
            // btn_投稿更新
            // 
            btn_投稿更新.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_投稿更新.BackColor = Color.FromArgb(0, 230, 115);
            btn_投稿更新.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btn_投稿更新.Location = new Point(582, 500);
            btn_投稿更新.Name = "btn_投稿更新";
            btn_投稿更新.Size = new Size(100, 30);
            btn_投稿更新.TabIndex = 9;
            btn_投稿更新.Text = "更新";
            btn_投稿更新.UseVisualStyleBackColor = false;
            btn_投稿更新.Click += btn_投稿更新_Click;
            // 
            // tlp_投稿内容
            // 
            tlp_投稿内容.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_投稿内容.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlp_投稿内容.ColumnCount = 2;
            tlp_投稿内容.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tlp_投稿内容.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_投稿内容.Controls.Add(label4, 0, 0);
            tlp_投稿内容.Controls.Add(rtb_投稿内容, 1, 0);
            tlp_投稿内容.Location = new Point(20, 310);
            tlp_投稿内容.Name = "tlp_投稿内容";
            tlp_投稿内容.RowCount = 1;
            tlp_投稿内容.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_投稿内容.Size = new Size(660, 180);
            tlp_投稿内容.TabIndex = 8;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.BackColor = Color.Gainsboro;
            label4.Location = new Point(1, 1);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(80, 178);
            label4.TabIndex = 3;
            label4.Text = "投稿内容";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rtb_投稿内容
            // 
            rtb_投稿内容.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtb_投稿内容.Location = new Point(85, 4);
            rtb_投稿内容.Name = "rtb_投稿内容";
            rtb_投稿内容.Size = new Size(571, 172);
            rtb_投稿内容.TabIndex = 4;
            rtb_投稿内容.Text = "";
            // 
            // tlp_投稿日時
            // 
            tlp_投稿日時.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tlp_投稿日時.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlp_投稿日時.ColumnCount = 2;
            tlp_投稿日時.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlp_投稿日時.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_投稿日時.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlp_投稿日時.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlp_投稿日時.Controls.Add(tlp_投稿時刻, 4, 0);
            tlp_投稿日時.Controls.Add(label5, 0, 0);
            tlp_投稿日時.Location = new Point(20, 270);
            tlp_投稿日時.Name = "tlp_投稿日時";
            tlp_投稿日時.RowCount = 1;
            tlp_投稿日時.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_投稿日時.Size = new Size(240, 30);
            tlp_投稿日時.TabIndex = 7;
            // 
            // tlp_投稿時刻
            // 
            tlp_投稿時刻.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlp_投稿時刻.ColumnCount = 2;
            tlp_投稿時刻.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_投稿時刻.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_投稿時刻.Controls.Add(rad_09, 0, 0);
            tlp_投稿時刻.Controls.Add(rad_21, 1, 0);
            tlp_投稿時刻.Location = new Point(117, 1);
            tlp_投稿時刻.Margin = new Padding(15, 0, 0, 0);
            tlp_投稿時刻.Name = "tlp_投稿時刻";
            tlp_投稿時刻.RowCount = 1;
            tlp_投稿時刻.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_投稿時刻.Size = new Size(122, 28);
            tlp_投稿時刻.TabIndex = 8;
            // 
            // rad_09
            // 
            rad_09.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rad_09.AutoSize = true;
            rad_09.Location = new Point(0, 0);
            rad_09.Margin = new Padding(0);
            rad_09.Name = "rad_09";
            rad_09.Size = new Size(61, 28);
            rad_09.TabIndex = 6;
            rad_09.TabStop = true;
            rad_09.Text = "09:00";
            rad_09.UseVisualStyleBackColor = true;
            // 
            // rad_21
            // 
            rad_21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rad_21.AutoSize = true;
            rad_21.Location = new Point(61, 0);
            rad_21.Margin = new Padding(0);
            rad_21.Name = "rad_21";
            rad_21.Size = new Size(61, 28);
            rad_21.TabIndex = 5;
            rad_21.TabStop = true;
            rad_21.Text = "21:00";
            rad_21.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.BackColor = Color.Gainsboro;
            label5.Location = new Point(1, 1);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(100, 28);
            label5.TabIndex = 3;
            label5.Text = "投稿予定時刻";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgv_投稿リスト
            // 
            dgv_投稿リスト.AllowUserToAddRows = false;
            dgv_投稿リスト.AllowUserToDeleteRows = false;
            dgv_投稿リスト.AllowUserToResizeColumns = false;
            dgv_投稿リスト.AllowUserToResizeRows = false;
            dgv_投稿リスト.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_投稿リスト.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_投稿リスト.ColumnHeadersHeight = 25;
            dgv_投稿リスト.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_投稿リスト.Columns.AddRange(new DataGridViewColumn[] { sort_index, post_time, message });
            dgv_投稿リスト.EnableHeadersVisualStyles = false;
            dgv_投稿リスト.Location = new Point(20, 20);
            dgv_投稿リスト.MultiSelect = false;
            dgv_投稿リスト.Name = "dgv_投稿リスト";
            dgv_投稿リスト.ReadOnly = true;
            dgv_投稿リスト.RowHeadersVisible = false;
            dgv_投稿リスト.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_投稿リスト.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_投稿リスト.ShowCellToolTips = false;
            dgv_投稿リスト.Size = new Size(660, 230);
            dgv_投稿リスト.TabIndex = 0;
            dgv_投稿リスト.SelectionChanged += dgv_投稿リスト_SelectionChanged;
            // 
            // sort_index
            // 
            sort_index.DataPropertyName = "sort_index";
            sort_index.HeaderText = "sort_index";
            sort_index.Name = "sort_index";
            sort_index.ReadOnly = true;
            sort_index.Visible = false;
            // 
            // post_time
            // 
            post_time.DataPropertyName = "post_time";
            post_time.HeaderText = "投稿予定時刻";
            post_time.Name = "post_time";
            post_time.ReadOnly = true;
            post_time.Width = 90;
            // 
            // message
            // 
            message.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            message.DataPropertyName = "message";
            message.HeaderText = "投稿内容";
            message.Name = "message";
            message.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 600);
            Controls.Add(tlp_外枠);
            Name = "MainForm";
            Text = "PostEdit";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            SizeChanged += Form1_Resize;
            tlp_外枠.ResumeLayout(false);
            tab_Main.ResumeLayout(false);
            tabPage_案作成.ResumeLayout(false);
            tlp_生成設定外側.ResumeLayout(false);
            tlp_生成設定.ResumeLayout(false);
            tlp_文字数.ResumeLayout(false);
            tlp_文字数.PerformLayout();
            tlp_生成数.ResumeLayout(false);
            tlp_生成数.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_生成数).EndInit();
            tlp_chk全体.ResumeLayout(false);
            tlp_chk内部.ResumeLayout(false);
            tlp_chk内部.PerformLayout();
            tabPage_案一覧.ResumeLayout(false);
            tlp_投稿選択外枠.ResumeLayout(false);
            tlp_pager.ResumeLayout(false);
            tlp_pager.PerformLayout();
            tlp_時刻設定.ResumeLayout(false);
            tlp_時刻設定.PerformLayout();
            tlp_投稿位置.ResumeLayout(false);
            tlp_投稿位置.PerformLayout();
            tlp_DB登録ボタン外枠.ResumeLayout(false);
            tlp_DB登録ボタン外枠.PerformLayout();
            tabPage_予約編集.ResumeLayout(false);
            tlp_投稿内容.ResumeLayout(false);
            tlp_投稿内容.PerformLayout();
            tlp_投稿日時.ResumeLayout(false);
            tlp_投稿日時.PerformLayout();
            tlp_投稿時刻.ResumeLayout(false);
            tlp_投稿時刻.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_投稿リスト).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlp_外枠;
        private TabControl tab_Main;
        private TabPage tabPage_案作成;
        private TabPage tabPage_案一覧;
        private TableLayoutPanel tlp_文字数;
        private RichTextBox rtb_投稿テーマ;
        private Label lbl_文字数;
        private TextBox tb_文字数;
        private CheckBox chk_ライト層に響く;
        private TableLayoutPanel tlp_生成数;
        private NumericUpDown nud_生成数;
        private Label label1;
        private CheckBox chk_口語調を使わない;
        private CheckBox chk_バズり重視;
        private CheckBox chk_堅苦しくない;
        private CheckBox chk_問いかける感じ;
        private CheckBox chk_丁寧に;
        private CheckBox chk_命令系にしない;
        private CheckBox chk_印象深く;
        private CheckBox chk_感情に訴える;
        private CheckBox chk_緊迫感を出す;
        private CheckBox chk_インパクト重視;
        private CheckBox chk_詩的な表現;
        private TableLayoutPanel tlp_chk全体;
        private Button btn_生成;
        private TableLayoutPanel tlp_chk内部;
        private TableLayoutPanel tlp_生成設定;
        private TableLayoutPanel tlp_生成設定外側;
        private RichTextBox rtb_投稿文;
        private TableLayoutPanel tlp_pager;
        private Button btn_preview;
        private Label lbl_PageInfo;
        private TableLayoutPanel tlp_DB登録ボタン外枠;
        private Button btn_next;
        private Button btn_DB登録;
        private CheckBox chk_登録対象;
        private RichTextBox rtb_投稿スタイル;
        private TabPage tabPage_予約編集;
        private DataGridView dgv_投稿リスト;
        private RichTextBox rtb_投稿内容;
        private Label label4;
        private TableLayoutPanel tlp_時刻設定;
        private TableLayoutPanel tlp_投稿選択外枠;
        private RadioButton rad_案一覧_21時;
        private RadioButton rad_案一覧_9時;
        private RadioButton rad_案一覧_自動;
        private TableLayoutPanel tlp_投稿日時;
        private RadioButton rad_09;
        private RadioButton rad_21;
        private TableLayoutPanel tlp_投稿時刻;
        private Label label5;
        private TableLayoutPanel tlp_投稿内容;
        private Button btn_投稿削除;
        private Button btn_投稿更新;
        private TableLayoutPanel tlp_投稿位置;
        private RadioButton rad_末尾追加;
        private RadioButton rad_先頭追加;
        private DataGridViewTextBoxColumn sort_index;
        private DataGridViewTextBoxColumn post_time;
        private DataGridViewTextBoxColumn message;
    }
}
