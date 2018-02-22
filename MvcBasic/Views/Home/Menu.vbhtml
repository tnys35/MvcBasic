@Code
    ViewData("Title") = "Menu"
End Code

<h2>Menu</h2>

<div class="row">

    @Html.ActionLink("ページ１", "TestPage1", "Test", "", New With {.class = "btn btn-default", .width = "200"})
    <br />
    @Html.ActionLink("ページ２", "userMaster", "Master", "", New With {.class = "btn btn-default", .width = "200"})

</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section