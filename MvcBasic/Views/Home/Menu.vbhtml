@Code
    ViewData("Title") = "Menu"
End Code

<h2>Menu</h2>

<div class="row">
    @Using Html.BeginForm("Logon", "Home", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @Html.AntiForgeryToken()
        @<text>
            <div>ログインユーザー:@Session("username")</div>
            <ul>
                <li>@Html.ActionLink("ページ１", "TestPage1", "Test", "", New With {.class = "btn btn-default", .width = "200"})</li>
                <li>@Html.ActionLink("ページ2", "TestPage2", "Test", "", New With {.class = "btn btn-default", .width = "200"})</li>
                <li>@Html.ActionLink("ユーザー一覧", "userMaster", "Master", "", New With {.class = "btn btn-default", .width = "200"})</li>
                <li>@Html.ActionLink("メンバーリスト", "Index", "Member/Members", "", New With {.class = "btn btn-default", .width = "200"})</li>
            </ul>
        </text>
    End Using
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
