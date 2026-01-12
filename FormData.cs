using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostEdit
{
    // フォームで選択されたチェックボックスの内容を保持するためのクラス
    internal class FormData
    {
        // チェックされた項目を格納するリスト（外部から直接変更できないよう private にしている）
        private readonly List<string> _checkedItems = new List<string>();

        //投稿文章の最大文字数
        public int? _maxLength { get; set; }

        //投稿文章の生成数
        public int? _createNumber { get; set; }

        // 外部からは読み取り専用でアクセスできるプロパティ
        // IReadOnlyList にすることで、追加・削除はこのクラスのメソッド経由に限定される
        public IReadOnlyList<string> CheckedItems => _checkedItems;
                
        // 項目を追加するメソッド
        // すでに存在する場合は重複して追加しない
        public void Add(string item)
        {
            if (!_checkedItems.Contains(item))
                _checkedItems.Add(item);
        }

        // 項目を削除するメソッド
        // 存在しない場合は何も起きない（List.Remove の仕様）
        public void Remove(string item)
        {
            _checkedItems.Remove(item);
        }

        public override string ToString()
        {
            //区切りを半角スペースにする
            var space = " ";

            // 出力の先頭に固定で表示する文言を定義
            // \r\n を含めて改行を入れているので、次の行から箇条書きが始まる
            var header = "上記内容について、以下の方針でX用の投稿文を作成" + Environment.NewLine
                       + "・" + _maxLength + "文字以内"
                       + space + "・" + _createNumber + "個生成"
                       + space + "・適度な改行をつける"
                       + space + "・ハッシュタグを2つ生成"
                       + space + "・JObject形式で出力"
                       + space + "・この形のJSONだけを出力する：{\"posts\":[{\"text\":\"\"}]}"
                       + space + "・コードブロックで出力";

            // _checkedItems に入っている各要素の先頭に「・」を付けて文字列化
            // それらを Environment.NewLine(OSを問わない改行コード) で区切って一つの文字列にまとめる
            var body = string.Join(
                space,
                _checkedItems.Select(item => "・" + item)
            );

            // header の後に改行を入れ、その下に body を連結して返す
            // これにより「固定文言 → 箇条書きリスト」という形式の文字列になる
            return header + space + body;
        }

    }
}