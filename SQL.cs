using MySqlConnector;
using System.Data;
using PostEdit.Properties;

/// <summary>
/// MySQL を利用した投稿キュー(dat_queue)の CRUD 操作をまとめたユーティリティクラス。
/// 接続管理・SQL 実行を簡潔に扱えるように抽象化している。
/// </summary>
public static class SQL
{
    // 接続文字列は Config.cs に分離して管理（セキュリティ・保守性のため）
    private static readonly string connStr = PostEdit.Config.ConnectionString;

    /// <summary>
    /// 指定した sort_index（queueOrder）で新しいメッセージを挿入する。
    /// </summary>
    public static void Insert(int queueOrder, string postTime, string message)
    {
        using var conn = new MySqlConnection(connStr);
        conn.Open();

        // パラメータ化クエリで SQL インジェクションを防止
        string sql = "INSERT INTO dat_queue (sort_index, post_time, message) VALUES (@order, @time, @msg)";
        using var cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@order", queueOrder);
        cmd.Parameters.AddWithValue("@time", postTime);
        cmd.Parameters.AddWithValue("@msg", message);

        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// キューの先頭に追加する（現在の MIN(sort_index) - 1 を採用）。
    /// </summary>
    public static void InsertAtHead(string postTime, string message)
    {
        using var conn = new MySqlConnection(connStr);
        conn.Open();

        // MIN(sort_index) を取得し、1 減らして先頭に挿入するための新しい sort_index を作成
        string sqlMin = "SELECT COALESCE(MIN(sort_index),0)-1 FROM dat_queue";
        using var cmdMin = new MySqlCommand(sqlMin, conn);
        int newOrder = Convert.ToInt32(cmdMin.ExecuteScalar());

        Insert(newOrder, postTime, message);
    }

    /// <summary>
    /// キューの末尾に追加する（現在の MAX(sort_index) + 1 を採用）。
    /// </summary>
    public static void InsertAtTail(string postTime, string message)
    {
        using var conn = new MySqlConnection(connStr);
        conn.Open();

        // MAX(sort_index) を取得し、1 増やして末尾に挿入するための新しい sort_index を作成
        string sqlMax = "SELECT COALESCE(MAX(sort_index),0)+1 FROM dat_queue";
        using var cmdMax = new MySqlCommand(sqlMax, conn);
        int newOrder = Convert.ToInt32(cmdMax.ExecuteScalar());

        Insert(newOrder, postTime, message);
    }

    /// <summary>
    /// 任意の SELECT 文を実行し、結果を DataTable として返す。
    /// パラメータも可変長で受け取れるため汎用性が高い。
    /// </summary>
    public static DataTable Select(string sql, params MySqlParameter[] parameters)
    {
        using var conn = new MySqlConnection(connStr);
        conn.Open();

        using var cmd = new MySqlCommand(sql, conn);

        // パラメータが指定されていれば追加
        if (parameters != null && parameters.Length > 0)
        {
            cmd.Parameters.AddRange(parameters);
        }

        // DataAdapter を使って DataTable に結果を流し込む
        using var adapter = new MySqlDataAdapter(cmd);
        var table = new DataTable();
        adapter.Fill(table);

        return table;
    }

    /// <summary>
    /// 投稿キュー全件を sort_index 昇順で取得する。
    /// </summary>
    public static DataTable GetQueue()
    {
        string sql = "SELECT sort_index, post_time, message FROM dat_queue ORDER BY sort_index ASC";
        return Select(sql);
    }

    /// <summary>
    /// 指定した sort_index のレコードを更新する。
    /// </summary>
    public static void UpdateQueue(int sortIndex, string postTime, string message)
    {
        using var conn = new MySqlConnection(connStr);
        conn.Open();

        string sql = @"
            UPDATE dat_queue 
            SET post_time = @time, message = @msg 
            WHERE sort_index = @order";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@order", sortIndex);
        cmd.Parameters.AddWithValue("@time", postTime);
        cmd.Parameters.AddWithValue("@msg", message);

        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// 指定した sort_index のレコードを削除する。
    /// </summary>
    public static void DeleteQueue(int sortIndex)
    {
        using var conn = new MySqlConnection(connStr);
        conn.Open();

        string sql = "DELETE FROM dat_queue WHERE sort_index = @order";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@order", sortIndex);

        cmd.ExecuteNonQuery();
    }
}