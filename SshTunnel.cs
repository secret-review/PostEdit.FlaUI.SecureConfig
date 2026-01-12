using Renci.SshNet;

namespace PostEdit
{
    /// <summary>
    /// SSH トンネルを開始・停止するためのユーティリティクラス。
    /// 設定値は appsettings.Local.json → Config.Ssh に外部化されている。
    /// </summary>
    public static class SshTunnel
    {
        private static SshClient _ssh;                 // SSH クライアント本体
        private static ForwardedPortLocal _fp;         // ローカルポートフォワード用オブジェクト

        /// <summary>
        /// SSH トンネルを開始する。
        /// すでに接続済みの場合は何もしない。
        /// </summary>
        public static void Start()
        {
            // すでに接続済みなら再接続しない
            if (_ssh != null && _ssh.IsConnected)
                return;

            // appsettings.Local.json → Config.Ssh に読み込まれた設定を取得
            var s = Config.Ssh;

            // 秘密鍵ファイルの読み込み
            // パスフレーズが空の場合とありの場合でコンストラクタが異なる
            var keyFile = string.IsNullOrEmpty(s.KeyPassphrase)
                ? new PrivateKeyFile(s.KeyPath)
                : new PrivateKeyFile(s.KeyPath, s.KeyPassphrase);

            // 認証方式（秘密鍵認証）
            var auth = new PrivateKeyAuthenticationMethod(s.User, keyFile);

            // SSH 接続情報を構築
            var connInfo = new ConnectionInfo(s.Host, s.Port, s.User, auth);

            // SSH 接続開始
            _ssh = new SshClient(connInfo);
            _ssh.Connect();

            // ローカルポートフォワード設定
            // 例：127.0.0.1:LocalPort → SSHサーバー → RemoteHost:RemotePort
            _fp = new ForwardedPortLocal(
                "127.0.0.1",
                (uint)s.LocalPort,
                s.RemoteHost,
                (uint)s.RemotePort
            );

            // SSH クライアントにポートフォワードを追加して開始
            _ssh.AddForwardedPort(_fp);
            _fp.Start();
        }

        /// <summary>
        /// SSH トンネルを停止する。
        /// </summary>
        public static void Stop()
        {
            try
            {
                _fp?.Stop();        // ポートフォワード停止
                _ssh?.Disconnect(); // SSH 切断
            }
            catch
            {
                // 停止処理は失敗しても致命的ではないため握りつぶす
            }
        }
    }
}