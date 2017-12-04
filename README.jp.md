# clipdiff
clipdiffはファイルを使わずに２つのテキストを比較するツールです。

# 動作環境
Windows, .NET 4.0以上

# 取扱種別
このソフトはフリーウェアです。LICENCEファイルを参照してください。

# インストール
ダウンロードしたファイルは7z形式の自己解凍ファイルです。実行して解凍するか7zなどの解凍ソフトウェアで解凍してください。
インストーラーはありません。

# アンインストール
ファイルを削除してください。アンインストーラーはありません。

# 使い方
* clipdiff.exeを起動します。
* 比較したい最初のテキストをコピーします。
* clipdiffの **[貼り付け]** クリックします。テキストが左のペインに貼り付けられます。
* 比較したい次のテキストをコピーします。
* もう一度 **[貼り付け]** をクリックします。
* これで２つのテキストが比較できます。
* 語句やキャラクターで比較したい場合は、行を右クリックしてコンテキストメニューを表示し、 **[docdiff(...)]** を選択します。

# 実例
* コマンドプロンプトを２つ開きます。１つ目は３２ビットプロセスから起動し、２つ目は６４ビットプロセスから起動します。２つのプロセスは異なる環境変数を持ちます。
* clipdiff.exeを開き、 **[ツール」->[クリップボードの監視]** をチェックします。
* １つめのコマンドプロンプトで、 **set | clip** と入力します。
* ２つめのコマンドプロンプトで、 **set | clip** と入力します。
* clipdiffで差分を確認します。


# 開発
以下のコマンドでソースを取得します。
```
git clone https://github.com/erasoni/SessionGlobalMemory.git
git clone https://github.com/erasoni/lsMisc.git
git clone https://github.com/erasoni/clipdiff.git
```
clipdiff.slnを開きビルドします。

# ダウンロード
バイナリーはここから入手できます。
https://github.com/erasoni/clipdiff/releases

# 作者への連絡先
* 電子メール ambiesoft.trueff@gmail.com
* 掲示板 http://ambiesoft.fam.cx/minibbs/minibbs.php
