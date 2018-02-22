@modeltype Member

@Code
    ViewData("Title") = "LogOn"
End Code

<!DOCTYPE html>

<h2>LogOn</h2>
<div class="row">
    @Using Html.BeginForm("Logon", "Home", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @Html.AntiForgeryToken()
        @<text>
            <hr />
            <fieldset>
                @ViewData("Message")
                <p>
                    <label for="userId">@Html.LabelFor(Function(model) model.UserId)</label><br />
                    @Html.TextBoxFor(Function(model) model.UserId)
                    @Html.ValidationMessageFor(Function(model) model.UserId)
                </p>
                <p>
                    <label for="password">@Html.LabelFor(Function(model) model.PassWord)</label><br />
                    @Html.PasswordFor(Function(model) model.PassWord)
                    @Html.ValidationMessageFor(Function(model) model.PassWord)
                </p>
                <p>
                    <input type="submit" value="ログオン" class="btn" />
                </p>
            </fieldset>

        </text>
    End Using
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section