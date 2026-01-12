using System.Data;

public static class DbCache
{
    // ▼ キャッシュ保持
    public static DataTable dat_queue { get; private set; }

    // ▼ 読み込み済みフラグ
    private static bool _queueLoaded = false;

    /// <summary>
    /// dat_queue を取得（初回のみ DB からロード）
    /// </summary>
    public static DataTable GetQueue()
    {
        if (!_queueLoaded)
        {
            dat_queue = SQL.GetQueue();
            _queueLoaded = true;
        }
        return dat_queue;
    }

    /// <summary>
    /// dat_queue を強制リロード（手動で最新化したい場合）
    /// </summary>
    public static void ReloadQueue()
    {
        dat_queue = SQL.GetQueue();
        _queueLoaded = true;
    }

    // ============================================================
    // ▼▼▼ DataTable と DB を同時に更新するメソッド ▼▼▼
    // ============================================================

    /// <summary>
    /// 行の更新（DB と DataTable を同期）
    /// </summary>
    public static void UpdateQueue(int sortIndex, string postTime, string message)
    {
        // DB 更新
        SQL.UpdateQueue(sortIndex, postTime, message);

        // DataTable 更新
        var rows = dat_queue.Select($"sort_index = {sortIndex}");
        if (rows.Length > 0)
        {
            rows[0]["post_time"] = postTime;
            rows[0]["message"] = message;
        }
    }

    /// <summary>
    /// 行の削除（DB と DataTable を同期）
    /// </summary>
    public static void DeleteQueue(int sortIndex)
    {
        // DB 削除
        SQL.DeleteQueue(sortIndex);

        // DataTable 削除
        var rows = dat_queue.Select($"sort_index = {sortIndex}");
        if (rows.Length > 0)
        {
            dat_queue.Rows.Remove(rows[0]);
        }
    }

    /// <summary>
    /// 行の追加（DB と DataTable を同期）
    /// </summary>
    public static void InsertQueue(int sortIndex, string postTime, string message)
    {
        // DB 追加
        SQL.Insert(sortIndex, postTime, message);

        // DataTable 追加
        var row = dat_queue.NewRow();
        row["sort_index"] = sortIndex;
        row["post_time"] = postTime;
        row["message"] = message;
        dat_queue.Rows.Add(row);
    }
}
