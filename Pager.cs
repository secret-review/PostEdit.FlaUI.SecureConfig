using System;

namespace PostEdit
{
    /// <summary>
    /// 循環型ページャーを表すクラス。
    /// 
    /// ・ページを前後に移動できる  
    /// ・最終ページから次へ進むと 1 ページへ戻る  
    /// ・1 ページから前へ戻ると最終ページへ移動する  
    /// 
    /// いわゆる「ループするページャー」を実現する。
    /// </summary>
    public class Pager
    {
        /// <summary>
        /// 現在のページ番号（1 始まり）。
        /// </summary>
        public int CurrentPage { get; private set; } = 1;

        /// <summary>
        /// 1 ページあたりの表示件数。
        /// </summary>
        public int ItemsPerPage { get; }

        /// <summary>
        /// 全件数。
        /// </summary>
        public int TotalItems { get; }

        /// <summary>
        /// 総ページ数。
        /// TotalItems / ItemsPerPage を切り上げて算出する。
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / ItemsPerPage);

        /// <summary>
        /// ページャーを初期化する。
        /// </summary>
        /// <param name="totalItems">全件数</param>
        /// <param name="itemsPerPage">1ページあたりの件数</param>
        public Pager(int totalItems, int itemsPerPage)
        {
            TotalItems = totalItems;
            ItemsPerPage = itemsPerPage;
        }

        /// <summary>
        /// 次のページへ移動する。
        /// 最終ページの場合は 1 ページへ戻る。
        /// </summary>
        public void NextPage()
        {
            if (CurrentPage >= TotalPages)
                CurrentPage = 1;
            else
                CurrentPage++;
        }

        /// <summary>
        /// 前のページへ移動する。
        /// 1 ページの場合は最終ページへ移動する。
        /// </summary>
        public void PrevPage()
        {
            if (CurrentPage <= 1)
                CurrentPage = TotalPages;
            else
                CurrentPage--;
        }

        /// <summary>
        /// 現在ページに対応するデータ範囲（開始インデックスと終了インデックス）を取得する。
        /// </summary>
        /// <returns>
        /// startIndex: 0 始まりの開始位置  
        /// endIndex:   終了位置（TotalItems を超えない）
        /// </returns>
        public (int startIndex, int endIndex) GetRowRange()
        {
            // 例: CurrentPage = 2, ItemsPerPage = 10 → start = 10
            int start = (CurrentPage - 1) * ItemsPerPage;

            // end は「start + ItemsPerPage」だが、総件数を超えないように調整
            int end = Math.Min(start + ItemsPerPage, TotalItems);

            return (start, end);
        }
    }
}