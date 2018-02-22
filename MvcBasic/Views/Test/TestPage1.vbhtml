@modeltype Member

@Code
    ViewData("Title") = "TestPage1"
End Code

<h2>TestPage1</h2>

<div class="col-md-8">

    @*これはサーバーコメントです。*@

    <p>
        @Html.ActionLink("Create New", "Create")
    </p>

    <!--インライン式-->
    <p>プロパティ：@DateTime.Now</p>
    <p>メソッド：  @DateTime.Now.ToLongDateString() ←スペースで終了</p>
    <p>フィールド：@DateTime.MaxValue：←全角コロンでコード終了</p>

    <!--複数のトークンで構成されたインライン式-->
    <p>@("現在の時刻：" & DateTime.Now)</p>

    <!--コード・ブロック-->
    @Code
        Dim year As Integer = DateTime.Now.Year
        Dim msg = IIf(DateTime.IsLeapYear(year), "うるう年", "平年")
    End Code

    <!--コード・ブロック内の変数を、後述のインライン式／コード・ブロック内で使用-->
    <p>コード・ブロック内の変数を、後述のインライン式で出力：@msg</p>

    <!--HTMLタグにより、コード・ブロック内で文字列と変数を出力-->
    @Code
        Dim strMsg As String = DateTime.Now.ToLongDateString()
        @<p>コード・ブロック内の変数を、HTMLタグ付きで出力：@strMsg</p>
    End Code

    <!--<text>タグにより、コード・ブロック内で文字列と変数を出力-->
    @Code
        strMsg = DateTime.Now.ToLongDateString()
        @<text>コード・ブロック内の変数を、textタグで出力：@strMsg</text>
    End Code

    @*これは「@:」により、コード・ブロック内で1行の文字列と変数を出力*@
    @Code
        strMsg = DateTime.Now.ToLongDateString()
        @:この1行が、そのまま出力される。<br>変数も使える@strMsg
    End Code

    <!--HTMLコード内でのコメント-->
    @* この部分はコメントになる *@
    @*
        当然、複数行で記述することもできる
    *@

    <!--コード・ブロックでのコメント-->
    @Code
        @* この部分はコメントになる *@
' 当然、VBのコメントも使える
    End Code
</div>
