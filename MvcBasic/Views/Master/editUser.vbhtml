@modeltype User

@Code
    ViewData("Title") = "ユーザー編集"
End Code

<!DOCTYPE html>

<h2>ユーザー編集</h2>

@Using Html.BeginForm("editUser", "Master", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
    @Html.AntiForgeryToken()
    @<text>
        <hr />
        <fieldset class="">
            <font color="red">@ViewData("Message")</font>

            <div class="form-group">
                <label for="userId">@Html.LabelFor(Function(model) model.userId)</label><br />
                @Html.TextBoxFor(Function(model) model.userId, New With {.class = "form-control", .PlaceHolder = "userId"})
                @Html.ValidationMessageFor(Function(model) model.userId)
            </div>
            <div class="form-group">
                <label for="password">@Html.LabelFor(Function(model) model.userName)</label><br />
                @Html.TextBoxFor(Function(model) model.userName, New With {.class = "form-control", .PlaceHolder = "userName"})
                @Html.ValidationMessageFor(Function(model) model.userName)
            </div>
            <div Class="form-group">
                <Label for="password">@Html.LabelFor(Function(model) model.mailAddress)</Label><br />
                @Html.TextBoxFor(Function(model) model.mailAddress, New With {.class = "form-control", .PlaceHolder = "mailAddress"})
                @Html.ValidationMessageFor(Function(model) model.mailAddress)
            </div>
            <div Class="form-group">
                <Label for="password">@Html.LabelFor(Function(model) model.remark)</Label><br />
                @Html.TextBoxFor(Function(model) model.remark, New With {.class = "form-control", .PlaceHolder = "remark"})
                @Html.ValidationMessageFor(Function(model) model.remark)
            </div>
            <div Class="form-group">
                <input type="submit" value="編集" Class="btn" />
            </div>
            <p>
                @Html.ActionLink("ユーザー一覧", "userMaster", "Master", "", New With {.class = "btn btn-default", .width = "200"})
            </p>
        </fieldset>
    </text>
End Using
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section

