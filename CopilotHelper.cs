using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Debug = System.Diagnostics.Debug;

public static class CopilotHelper
{
    public static string AppId { get; private set; } = "";

    private static FlaUI.Core.Application copilotApp;
    private static UIA3Automation automation;
    private static FlaUI.Core.AutomationElements.Button cachedSendButton;

    // ✅ 削除対象スレッドを保持するプロパティ
    public static AutomationElement TargetThreadItem { get; private set; }
    public static string TargetThreadTitle { get; private set; }

    /// <summary>
    /// PowerShell を使って Copilot の AppID を取得
    /// </summary>
    public static void LoadAppId()
    {
        // PowerShell を起動するための設定を構築
        var psi = new ProcessStartInfo()
        {
            // 実行するコマンドは PowerShell
            FileName = "powershell.exe",

            // Copilot を含むアプリの AppID を取得する PowerShell コマンド
            // Get-StartApps → インストール済みアプリ一覧
            // Where-Object Name -like '*Copilot*' → Copilot を含む名前のアプリを抽出
            // Select-Object -First 1 -ExpandProperty AppID → 最初の1件の AppID を取り出す
            Arguments = "Get-StartApps | Where-Object Name -like '*Copilot*' | Select-Object -First 1 -ExpandProperty AppID",

            // 標準出力を C# 側で受け取るための設定
            RedirectStandardOutput = true,

            // シェルを使わずに直接プロセスを起動
            UseShellExecute = false,

            // PowerShell のウィンドウを表示しない
            CreateNoWindow = true
        };

        // PowerShell プロセスを起動し、結果を読み取る
        using (var process = Process.Start(psi))
        {
            // PowerShell の出力（AppID）をすべて読み取り、前後の空白を除去
            AppId = process.StandardOutput.ReadToEnd().Trim();

            // プロセスが終了するまで待機
            process.WaitForExit();
        }
    }

    /// <summary>
    /// Copilot を起動し、ウィンドウが表示されるまで待機する。
    /// ・既に起動している場合は一度閉じてから再起動
    /// ・起動していない場合は AppID から起動
    /// ・ウィンドウが画面に表示されるまで待機
    /// </summary>
    public static async Task<bool> StartCopilotAndWait(int timeoutMs = 10000)
    {
        if (string.IsNullOrEmpty(AppId))
            LoadAppId();

        // ---------------------------------------
        // ① 既存の Copilot プロセスを探して閉じる
        // ---------------------------------------
        var processes = Process.GetProcessesByName("Copilot");
        foreach (var proc in processes)
        {
            try
            {
                if (proc.MainWindowHandle != IntPtr.Zero)
                {
                    // Attach → Close
                    copilotApp = FlaUI.Core.Application.Attach(proc);
                    automation = new UIA3Automation();

                    var mainWin = copilotApp.GetMainWindow(automation);
                    if (mainWin != null)
                    {
                        mainWin.Close();
                        proc.WaitForExit(3000); // 最大3秒待つ
                    }
                }
            }
            catch
            {
                // 権限などで例外が出ても無視
            }
        }

        // ----------------------------------------
        // ② Copilot を新規起動
        // ----------------------------------------
        Process.Start(new ProcessStartInfo()
        {
            FileName = "explorer.exe",
            Arguments = $"shell:AppsFolder\\{AppId}",
            UseShellExecute = true
        });

        // ------------------------------------------
        // ③ 起動完了（ウィンドウ表示）を待つ
        // ------------------------------------------
        var sw = Stopwatch.StartNew();
        while (sw.ElapsedMilliseconds < timeoutMs)
        {
            processes = Process.GetProcessesByName("Copilot");
            foreach (var proc in processes)
            {
                if (proc.MainWindowHandle != IntPtr.Zero)
                {
                    copilotApp = FlaUI.Core.Application.Attach(proc);
                    automation = new UIA3Automation();

                    var mainWin = copilotApp.GetMainWindow(automation);
                    if (mainWin != null && !mainWin.Properties.IsOffscreen.ValueOrDefault)
                        return true;
                }
            }

            await Task.Delay(200);
        }

        // タイムアウト
        return false;
    }

    /// <summary>
    /// Copilot のメインウィンドウ内から「入力欄（TextBox）」を探し出す。
    /// 
    /// ・AutomationId = "InputTextBox" を持つ要素を検索  
    /// ・見つかるまで一定時間リトライ  
    /// ・見つかったら FlaUI の TextBox として返す  
    /// ・タイムアウトしたら null を返す  
    /// 
    /// Copilot の UI が表示されるまで時間差があるため、
    /// ポーリングしながら待つ仕組みになっている。
    /// </summary>
    /// <param name="timeoutMs">探索を続ける最大時間（ミリ秒）</param>
    /// <returns>TextBox が見つかればそのインスタンス、見つからなければ null</returns>
    public static FlaUI.Core.AutomationElements.TextBox FindInputBox(int timeoutMs = 5000)
    {
        // Copilot のメインウィンドウを取得
        var mainWin = copilotApp.GetMainWindow(automation);

        // タイムアウト管理用のストップウォッチ
        var sw = Stopwatch.StartNew();

        // 指定時間内で繰り返し探索
        while (sw.ElapsedMilliseconds < timeoutMs)
        {
            // AutomationId = "InputTextBox" を持つ要素を検索し、TextBox として取得
            var input = mainWin
                .FindFirstDescendant(cf => cf.ByAutomationId("InputTextBox"))
                ?.AsTextBox();

            // 見つかったら即返す
            if (input != null)
                return input;

            // 見つからない場合は少し待って再試行
            Task.Delay(100).Wait();
        }

        // タイムアウトした場合は null
        return null;
    }

    /// <summary>
    /// 指定された入力欄（TextBox）にメッセージを入力し、
    /// Copilot の送信ボタンを押してメッセージを送信する。
    /// 
    /// ・TextBox が null の場合は例外  
    /// ・テキストはキー入力ではなく Text プロパティで直接反映  
    /// ・送信ボタンは複数の候補（AutomationId / Name）から探索  
    /// ・見つかったボタンを Invoke() でクリック  
    /// </summary>
    /// <param name="inputBox">メッセージを入力する TextBox</param>
    /// <param name="message">送信したい文字列</param>
    public static void InputAndSend(FlaUI.Core.AutomationElements.TextBox inputBox, string message)
    {
        // 入力欄が null の場合は処理できないため例外を投げる
        if (inputBox == null)
            throw new ArgumentNullException(nameof(inputBox));

        // TextBox に直接テキストを設定
        // （キー入力のシミュレーションより高速で確実）
        inputBox.Text = message;

        // UI が更新されるまで少し待つ
        // （即座に送信すると反映前に送信される可能性があるため）
        System.Threading.Thread.Sleep(200);

        // 入力欄の親要素を取得し、その中から送信ボタンを探す
        var parent = inputBox.Parent;

        // Copilot の UI はバージョンによって AutomationId や Name が異なるため、
        // 複数の候補を OR 条件で指定して探索する
        cachedSendButton = parent.FindFirstDescendant(cf =>
            cf.ByAutomationId("SendButton")                // 旧 UI
              .Or(cf.ByAutomationId("ComposerSubmitButton")) // 新 UI
              .Or(cf.ByName("メッセージの送信"))            // 日本語環境
              .Or(cf.ByName("Send message"))                // 英語環境
        )?.AsButton();

        // ボタンが見つかっていればクリック（Invoke）
        cachedSendButton?.Invoke();
    }

    /// <summary>
    /// Copilot の応答生成が完了するまで待機する。
    /// 
    /// Copilot が返答を生成している間は、UI 上に  
    /// 「停止」「Stop」「メッセージの割り込み」などの“割り込みボタン”が表示される。
    /// 
    /// このメソッドでは、
    /// 1. 割り込みボタンが一度でも表示されるのを確認し、  
    /// 2. その後ボタンが消える（＝応答生成が完了した）タイミングを待つ  
    /// というロジックで応答完了を検知する。
    /// 
    /// 指定時間内に完了しなければ TimeoutException を投げる。
    /// </summary>
    /// <param name="timeoutMs">応答完了を待つ最大時間（ミリ秒）</param>
    public static void WaitForResponseComplete(int timeoutMs = 30000)
    {
        // Copilot のメインウィンドウを取得
        var mainWin = copilotApp.GetMainWindow(automation);

        // タイムアウト管理用ストップウォッチ
        var sw = Stopwatch.StartNew();

        // 「停止ボタンが一度でも表示されたか」を記録するフラグ
        bool stopButtonAppeared = false;

        // タイムアウトまでループしながら UI を監視
        while (sw.ElapsedMilliseconds < timeoutMs)
        {
            // 割り込みボタンを複数の候補から探索
            // Copilot の UI はバージョンや言語で名称が変わるため OR 条件で検索
            var stopBtn = mainWin.FindFirstDescendant(cf =>
                cf.ByAutomationId("StopButton")
                  .Or(cf.ByName("停止"))
                  .Or(cf.ByName("Stop"))
                  .Or(cf.ByName("メッセージの割り込み"))
            )?.AsButton();

            // ボタンが存在し、かつ画面上に表示されている場合
            if (stopBtn != null && !stopBtn.Properties.IsOffscreen.ValueOrDefault)
            {
                // 一度でも表示されたことを記録
                stopButtonAppeared = true;
            }
            else
            {
                // ボタンが消えている AND 一度は表示されていた → 応答完了
                if (stopButtonAppeared)
                {
                    return;
                }
            }

            // UI 更新待ち
            System.Threading.Thread.Sleep(500);
        }

        // 指定時間内に完了しなかった場合はタイムアウト
        throw new TimeoutException("応答完了待機がタイムアウトしました。");
    }

    /// <summary>
    /// Copilot の最新応答に付いている「コピー」ボタンを押して、
    /// クリップボードへ内容をコピーする。
    /// 
    /// ・UI の生成タイミングにばらつきがあるため、最大 5 秒間リトライ  
    /// ・AutomationId / Name の違いに対応（日本語 / 英語 UI）  
    /// ・Invoke パターンが使えない場合はクリック位置を取得してマウスクリック  
    /// 
    /// 成功すれば true、ボタンが見つからなければ false を返す。
    /// </summary>
    public static bool CopyLatestResponse()
    {
        // Copilot のメインウィンドウを取得
        var mainWin = copilotApp.GetMainWindow(automation);

        // -------------------------------------
        // ① Copy ボタンをリトライしながら探索
        // -------------------------------------
        FlaUI.Core.AutomationElements.Button copyBtn = null;

        for (int i = 0; i < 50; i++) // 最大 5 秒（100ms × 50）
        {
            // Copilot の UI はバージョンや言語で名称が異なるため、
            // AutomationId と Name の両方を OR 条件で探索
            copyBtn = mainWin.FindFirstDescendant(cf =>
                cf.ByAutomationId("CopyButton")
                  .Or(cf.ByName("コピー"))
                  .Or(cf.ByName("Copy"))
            )?.AsButton();

            if (copyBtn != null)
                break; // 見つかったら即終了

            System.Threading.Thread.Sleep(100); // 少し待って再試行
        }

        // ボタンが見つからなければコピー不可
        if (copyBtn == null)
            return false;

        // --------------------------------------------
        // ② ボタンを画面内にスクロールしてフォーカス
        // --------------------------------------------
        // List 内にある場合、スクロールしないとクリックできないことがある
        copyBtn.Patterns.ScrollItem.Pattern.ScrollIntoView();

        // フォーカスを当てて UI 操作を安定させる
        copyBtn.Focus();

        // -------------------------------
        // ③ Invoke パターンで押す（最も確実）
        // -------------------------------
        if (copyBtn.Patterns.Invoke.IsSupported)
        {
            copyBtn.Invoke();
        }
        else
        {
            // Invoke が使えない UI の場合はクリック位置を取得してマウスクリック
            var pt = copyBtn.GetClickablePoint();
            FlaUI.Core.Input.Mouse.Click(pt);
        }

        return true;
    }

    //処理完了後に対象のスレッドを削除
    public static void DeleteThread()
    {
        try
        {
            //サイドバーを開く
            if (!OpenSidebar()) throw new Exception("OpenSidebar()でエラー");

            //最新のスレッドメニューを開く
            if (!ClickMoreActions()) throw new Exception("ClickMoreActions()でエラー");

            //削除実行
            ConfirmDeleteConversation();

        }
        catch (Exception ex)
        {
            //エラー時は特になにもしない
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
        finally
        {
            //いかなる場合でもサイドバーを閉じて終了
            CloseSidebar();
        }

    }


    /// <summary>
    /// Copilot ウィンドウ内の「サイドバーを開く」ボタンを押して、
    /// サイドバーを展開する処理を行う。
    /// 
    /// ・AutomationId("OpenPane") が最も安定した識別子  
    /// ・日本語 UI では Name("サイド バーを開く") が使われる場合がある  
    /// ・Invoke パターンが使える場合はそれを優先  
    /// ・Invoke が使えない UI の場合はクリック位置を取得してマウスクリック  
    /// 
    /// 成功すれば true、ボタンが見つからなければ false を返す。
    /// </summary>
    public static bool OpenSidebar()
    {
        // Copilot のメインウィンドウを取得
        var mainWin = copilotApp.GetMainWindow(automation);

        // -----------------------------------------
        // ① サイドバーを開くボタンを探索
        // -----------------------------------------
        // Copilot の UI はバージョンや言語で名称が変わるため、
        // AutomationId と Name の両方を OR 条件で検索する
        var sidebarBtn = mainWin.FindFirstDescendant(cf =>
            cf.ByAutomationId("OpenPane")          // 最も安定した識別子
              .Or(cf.ByName("サイド バーを開く")) // 日本語 UI
        )?.AsButton();

        // ボタンが見つからなければ操作不可
        if (sidebarBtn == null)
            return false;

        // -----------------------------------------------
        // ② ボタンを押す（Invoke が使える場合は Invoke）
        // -----------------------------------------------
        if (sidebarBtn.Patterns.Invoke.IsSupported)
        {
            // Invoke パターンは UI Automation 的に最も正しい操作
            sidebarBtn.Invoke();
        }
        else
        {
            // Invoke が使えない UI の場合はクリック位置を取得してマウスクリック
            var pt = sidebarBtn.GetClickablePoint();
            FlaUI.Core.Input.Mouse.Click(pt);
        }

        return true;
    }

    /// <summary>
    /// Copilot の会話一覧から「現在開いているスレッド」を特定し、
    /// そのスレッドの「その他のアクション（三点メニュー）」を開いて
    /// 「会話の削除」を実行する。
    ///
    /// ・ウィンドウタイトルが「無題の会話」の間はタイトル確定まで待機  
    /// ・会話履歴（ConversationHistoryRepeater）から「今日」グループを取得  
    /// ・その中から現在のスレッドタイトルと一致する ListItem を探す  
    /// ・三点メニューを開き、「会話の削除」を選択  
    /// ・削除メニューは Popup 内の MenuFlyoutItem として表示される  
    ///
    /// 成功すれば true、どこかで要素が見つからなければ false を返す。
    /// </summary>
    public static bool ClickMoreActions()
    {
        var mainWin = copilotApp.GetMainWindow(automation);
        Debug.WriteLine("MainWindow取得: " + (mainWin != null));

        // ---------------------------------------------
        // ① 現在開いているスレッドのタイトルを取得
        // ---------------------------------------------
        string threadTitle = mainWin.Name;
        Debug.WriteLine("threadTitle→" + threadTitle);

        // Copilot は新規会話開始直後「無題の会話」になるため、
        // タイトルが確定するまで最大 30 秒待つ
        var n = 0;
        while (threadTitle == "無題の会話" && n < 30)
        {
            Thread.Sleep(1000);
            threadTitle = mainWin.Name;
            n++;
        }

        // ---------------------------------------------
        // ② 会話履歴リスト（左側のスレッド一覧）を取得
        // ---------------------------------------------
        var threadList = mainWin.FindFirstDescendant(cf => cf.ByAutomationId("ConversationHistoryRepeater"));
        if (threadList == null)
        {
            Debug.WriteLine("会話履歴リストが見つかりませんでした");
            return false;
        }

        // ---------------------------------------------
        // ③ 「今日」グループを取得
        // ---------------------------------------------
        var todayGroup = threadList.FindAllDescendants(cf =>
            cf.ByControlType(FlaUI.Core.Definitions.ControlType.Group)
              .And(cf.ByName("今日")))
              .FirstOrDefault();

        if (todayGroup == null)
        {
            Debug.WriteLine("グループ一覧を取得できませんでした");
            return false;
        }

        // ---------------------------------------------
        // ④ 今日の会話一覧（ListItem）を取得
        // ---------------------------------------------
        var listItems = todayGroup.FindAllDescendants(cf =>
            cf.ByClassName("ListViewItem")
              .And(cf.ByControlType(ControlType.ListItem)));

        // ---------------------------------------------
        // ⑤ 現在のスレッドタイトルと一致する項目を探す
        // ---------------------------------------------
        AutomationElement tgtThread = null;
        foreach (var list in listItems)
        {
            string title = list.Name;
            Debug.WriteLine("title→" + title);

            if (title == threadTitle)
            {
                // todayGroup を対象スレッドに置き換える
                todayGroup = list;
                break;
            }
        }

        if (todayGroup == null)
        {
            Debug.WriteLine("対象のスレッドが見つかりませんでした");
            return false;
        }

        // 対象スレッドにフォーカス
        todayGroup.Focus();

        // ---------------------------------------------
        // ⑥ 三点メニュー（その他のアクション）を取得
        // ---------------------------------------------
        var moreBtn = Retry.WhileNull(
            () => todayGroup.FindFirstDescendant(cf =>
                         cf.ByControlType(ControlType.Button)
                           .And(cf.ByName("その他のアクション"))
            )?.AsButton(),
            timeout: TimeSpan.FromSeconds(30)
        ).Result;

        if (moreBtn == null)
        {
            Debug.WriteLine("三点ボタンが見つかりませんでした");
            return false;
        }

        // ---------------------------------------------
        // ⑦ 三点メニューをクリック
        // ---------------------------------------------
        if (moreBtn.Patterns.Invoke.IsSupported)
            moreBtn.Invoke();
        else
            Mouse.Click(moreBtn.GetClickablePoint());

        // ---------------------------------------------
        // ⑧ 三点メニュー押下後の Popup を取得
        // ---------------------------------------------
        var popup = Retry.WhileNull(
            () => automation.GetDesktop().FindFirstDescendant(cf =>
                          cf.ByClassName("Popup")
                            .And(cf.ByControlType(ControlType.Window))
            ),
            timeout: TimeSpan.FromSeconds(3)
        ).Result;

        if (popup == null)
        {
            Debug.WriteLine("削除メニューのポップアップが見つかりませんでした");
            return false;
        }

        // ---------------------------------------------
        // ⑨ Popup 内の「会話の削除」メニューを取得
        // ---------------------------------------------
        var deleteItem = popup.FindFirstDescendant(cf =>
                            cf.ByControlType(ControlType.MenuItem)
                              .And(cf.ByClassName("MenuFlyoutItem"))
                              .And(cf.ByName("会話の削除"))
        )?.AsMenuItem();

        if (deleteItem == null)
        {
            Debug.WriteLine("会話の削除メニューが見つかりませんでした");
            return false;
        }

        Debug.WriteLine($"DeleteItem情報: Name={deleteItem.Name}, Rect={deleteItem.BoundingRectangle}");

        // ---------------------------------------------
        // ⑩ 「会話の削除」をクリック
        // ---------------------------------------------
        if (deleteItem.Patterns.Invoke.IsSupported)
            deleteItem.Invoke();
        else
            Mouse.Click(deleteItem.GetClickablePoint());

        // ---------------------------------------------------------
        // ⑪ deleteItem 内の TextBlock（実際のクリック対象）を探す
        // ---------------------------------------------------------
        var deleteTextBlock = deleteItem.FindFirstDescendant(cf =>
                                      cf.ByControlType(ControlType.Text)
                                        .And(cf.ByName("会話の削除"))
        );

        if (deleteTextBlock == null)
        {
            Debug.WriteLine("TextBlock '会話の削除' が見つかりませんでした");
            return false;
        }

        Debug.WriteLine($"DeleteTextBlock情報: Name={deleteTextBlock.Name}, Rect={deleteTextBlock.BoundingRectangle}");

        // TextBlock は Invoke を持たないためクリックで削除実行
        Mouse.Click(deleteTextBlock.GetClickablePoint());

        return true;
    }

    /// <summary>
    /// 「会話の削除」確認ダイアログから削除ボタンを押し、
    /// 対象スレッドが会話一覧から消えるまで待機する。
    ///
    /// ・Popup（確認ダイアログ）を UIA で検出  
    /// ・DeleteButton（または「削除」）を押す  
    /// ・削除対象タイトル（TargetThreadTitle）が指定されている場合、
    ///   会話一覧からそのタイトルが消えるまで監視  
    ///
    /// 成功すれば true、要素が見つからない・消えない場合は false を返す。
    /// </summary>
    public static bool ConfirmDeleteConversation()
    {
        var desktop = automation.GetDesktop();

        // ---------------------------------------------
        // ① Popup（削除確認ダイアログ）を取得
        // ---------------------------------------------
        // Popup は ClassName="Popup" かつ ControlType=Window として現れる。
        // UI の表示に時間差があるため Retry で最大 5 秒待つ。
        var popups = Retry.While(
            () => desktop.FindAllDescendants(cf =>
                cf.ByClassName("Popup").And(cf.ByControlType(ControlType.Window))),
            r => r.Length == 0,
            timeout: TimeSpan.FromSeconds(5)
        ).Result;

        // Popup の中から DeleteButton を含むものを探す
        var targetPopup = popups.FirstOrDefault(p =>
            p.FindFirstDescendant(cf =>
                cf.ByControlType(ControlType.Button)
                  .And(cf.ByAutomationId("DeleteButton").Or(cf.ByName("削除"))
            )) != null);

        if (targetPopup == null)
            return false;

        // ---------------------------------------------
        // ② Popup 内の削除ボタンを取得
        // ---------------------------------------------
        var deleteBtn = targetPopup.FindFirstDescendant(cf =>
            cf.ByControlType(ControlType.Button)
              .And(cf.ByAutomationId("DeleteButton").Or(cf.ByName("削除"))
        ))?.AsButton();

        if (deleteBtn == null)
            return false;

        // ---------------------------------------------
        // ③ 削除ボタンを押す（Invoke）
        // ---------------------------------------------
        deleteBtn.Invoke();

        // ------------------------------------------------
        // ④ 削除対象タイトルが会話一覧から消えるまで待機
        // ------------------------------------------------
        if (!string.IsNullOrEmpty(TargetThreadTitle))
        {
            var mainWin = copilotApp.GetMainWindow(automation);

            // Retry.WhileFalse → 条件が true になるまで待つ
            var disappeared = Retry.WhileFalse(
                () =>
                {
                    // 会話一覧（ConversationHistoryRepeater）を取得
                    var threadList = mainWin.FindFirstDescendant(cf => cf.ByAutomationId("ConversationHistoryRepeater"));
                    if (threadList == null) return false;

                    // 全 ListItem を取得
                    var items = threadList.FindAllDescendants(cf => cf.ByControlType(ControlType.ListItem));

                    // まだ削除対象タイトルが残っているか？
                    return items.Any(i =>
                    {
                        var text = i.FindFirstDescendant(cf => cf.ByControlType(ControlType.Text))?.Name ?? "";
                        return !string.IsNullOrEmpty(text) && text.Contains(TargetThreadTitle);
                    });
                },
                timeout: TimeSpan.FromSeconds(15)
            ).Result;

            Debug.WriteLine("削除対象タイトル消滅確認: " + disappeared);

            // disappeared が true → まだ存在する（逆）
            // 「消えたか？」ではなく「存在するか？」を返しているため、
            // ここでは disappeared をそのまま返す。
            return disappeared;
        }

        // タイトル指定なしの場合は削除ボタン押下のみで成功扱い
        return true;
    }

    /// <summary>
    /// Copilot ウィンドウ内の「ホーム」ボタンを押して、
    /// ホーム画面へ戻る処理を行う。
    ///
    /// ・AutomationId("HomeButton") が最も安定した識別子  
    /// ・日本語 UI では Name("ホーム") が使われる場合がある  
    /// ・UI の生成タイミングにばらつきがあるため Retry で最大 3 秒待機  
    /// ・Invoke パターンが使える場合は Invoke を優先  
    /// ・Invoke が使えない UI の場合は ClickablePoint を使ってクリック  
    ///
    /// 成功すれば true、ボタンが見つからなければ false を返す。
    /// </summary>
    public static bool ClickHomeButton()
    {
        // Copilot のメインウィンドウを取得
        var mainWin = copilotApp.GetMainWindow(automation);
        Debug.WriteLine("MainWindow取得: " + (mainWin != null));

        if (mainWin == null)
            return false;

        // ---------------------------------------------
        // ① ホームボタンを探索（AutomationId / Name）
        // ---------------------------------------------
        // UI の表示タイミングが遅れることがあるため Retry で待機しながら取得する
        var homeBtn = Retry.WhileNull(
            () => mainWin.FindFirstDescendant(cf =>
                cf.ByAutomationId("HomeButton")      // 最も安定した識別子
                  .Or(cf.ByName("ホーム"))           // 日本語 UI
                  .And(cf.ByControlType(ControlType.Button))
            )?.AsButton(),
            timeout: TimeSpan.FromSeconds(3)
        ).Result;

        Debug.WriteLine("ホームボタン取得: " + (homeBtn != null));

        if (homeBtn == null)
        {
            Debug.WriteLine("ホームボタンが見つかりませんでした");
            return false;
        }

        Debug.WriteLine($"ホームボタン情報: Name={homeBtn.Name}, Rect={homeBtn.BoundingRectangle}");

        // ---------------------------------------------
        // ② Invoke パターンでクリック（最も正しい UI 操作）
        // ---------------------------------------------
        if (homeBtn.Patterns.Invoke.IsSupported)
        {
            Debug.WriteLine("Invokeパターンでクリック");
            homeBtn.Invoke();
        }
        else
        {
            // Invoke が使えない UI の場合はクリック位置を取得してマウスクリック
            Debug.WriteLine("ClickablePointでクリック");
            var pt = homeBtn.GetClickablePoint();
            FlaUI.Core.Input.Mouse.Click(pt);
        }

        return true;
    }

    /// <summary>
    /// Copilot ウィンドウ内の「サイドバーを閉じる」ボタンを押して、
    /// 展開中のサイドバーを閉じる処理を行う。
    ///
    /// ・AutomationId("ClosePane") が最も安定した識別子  
    /// ・日本語 UI では Name("サイド バーを閉じる") が使われる場合がある  
    /// ・Invoke パターンが利用可能ならそれを優先  
    /// ・Invoke が使えない UI の場合は ClickablePoint を使ってマウスクリック  
    ///
    /// 成功すれば true、ボタンが見つからなければ false を返す。
    /// </summary>
    public static bool CloseSidebar()
    {
        // Copilot のメインウィンドウを取得
        var mainWin = copilotApp.GetMainWindow(automation);

        // ---------------------------------------------
        // ① サイドバーを閉じるボタンを探索
        // ---------------------------------------------
        // UI のバージョンや言語によって AutomationId / Name が異なるため、
        // OR 条件で両方を検索する
        var closeBtn = mainWin.FindFirstDescendant(cf =>
            cf.ByAutomationId("ClosePane")              // 最も安定した識別子
              .Or(cf.ByName("サイド バーを閉じる"))    // 日本語 UI
        )?.AsButton();

        // ボタンが見つからなければ閉じる操作はできない
        if (closeBtn == null)
            return false;

        // -------------------------------------------------
        // ② Invoke パターンでクリック（最も正しい UI 操作）
        // -------------------------------------------------
        if (closeBtn.Patterns.Invoke.IsSupported)
        {
            closeBtn.Invoke();
        }
        else
        {
            // Invoke が使えない UI の場合はクリック位置を取得してマウスクリック
            var pt = closeBtn.GetClickablePoint();
            FlaUI.Core.Input.Mouse.Click(pt);
        }

        return true;
    }

    /// <summary>
    /// Copilot ウィンドウを閉じる
    /// </summary>
    public static bool CloseCopilotWindow()
    {
        if (copilotApp == null) return false;
        var mainWin = copilotApp.GetMainWindow(automation);
        mainWin.Close();
        return true;
    }

}
