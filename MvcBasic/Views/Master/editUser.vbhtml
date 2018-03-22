@modeltype User

@Code
    ViewData("Title") = "ユーザー編集"
End Code

<!DOCTYPE html>

<h2>ユーザー編集</h2>
<div class="row">
    @Using Html.BeginForm("editUser", "Master", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @Html.AntiForgeryToken()
        @<text>
            <hr />
            <fieldset>
                <font color="red">@ViewData("Message")</font>
                <p>
                    <label for="userId">@Html.LabelFor(Function(model) model.userId)</label><br />
                    @Html.TextBoxFor(Function(model) model.userId)
                    @Html.ValidationMessageFor(Function(model) model.userId)
                </p>
                <p>
                    <label for="password">@Html.LabelFor(Function(model) model.userName)</label><br />
                    @Html.TextBoxFor(Function(model) model.userName)
                    @Html.ValidationMessageFor(Function(model) model.userName)
                </p>
                <p>
                    <label for="password">@Html.LabelFor(Function(model) model.mailAddress)</label><br />
                    @Html.TextBoxFor(Function(model) model.mailAddress)
                    @Html.ValidationMessageFor(Function(model) model.mailAddress)
                </p>
                <p>
                    <label for="password">@Html.LabelFor(Function(model) model.remark)</label><br />
                    @Html.TextBoxFor(Function(model) model.remark)
                    @Html.ValidationMessageFor(Function(model) model.remark)
                </p>
                <p>
                    <input type="submit" value="編集" class="btn" />
                    @Html.ActionLink("ユーザー一覧", "userMaster", "Master", "", New With {.class = "btn btn-default", .width = "200"})
                </p>
            </fieldset>

        </text>
    End Using
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section

