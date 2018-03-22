@Code
    ViewData("Title") = "Menu"
End Code

<h2>Menu</h2>
<div style="width:100%;align:right;">
    ログインユーザー:@Session("username")
</div>

<div class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li>@Html.ActionLink("ページ１", "TestPage1", "Test", "", New With {.class = "btn btn-default", .width = "200"})</li>
                <li>@Html.ActionLink("ユーザー一覧", "userMaster", "Master", "", New With {.class = "btn btn-default", .width = "200"})</li>
            </ul>
        </div>
    </div>
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section