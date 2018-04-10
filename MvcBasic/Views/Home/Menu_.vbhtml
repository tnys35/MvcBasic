@Code
    ViewData("Title") = "Menu"
End Code

<h2>Menu</h2>
<div style="width:100%;">
    ログインユーザー:@Session("username")
</div>

<div class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <ul class="nav navbar-nav">
            <li>@Html.ActionLink("ページ１", "TestPage1", "Test", "", New With {.class = "btn btn-default", .width = "200"})</li>
            <li>@Html.ActionLink("ページ2", "TestPage2", "Test", "", New With {.class = "btn btn-default", .width = "200"})</li>
            <li>@Html.ActionLink("ユーザー一覧", "userMaster", "Master", "", New With {.class = "btn btn-default", .width = "200"})</li>
            <li>@Html.ActionLink("メンバーリスト", "Index", "Member/Members", "", New With {.class = "btn btn-default", .width = "200"})</li>
        </ul>
    </div>
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section