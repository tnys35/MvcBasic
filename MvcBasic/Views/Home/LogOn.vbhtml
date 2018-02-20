@Model MvcBasic.Models.Member

@Code
    ViewData("Title") = "LogOn"
End Code

<!DOCTYPE html>

<h2>LogOn</h2>

<table class="table">
    <tr>
        <th>UserId</th>
        <td>@Html.TextBox("UserId")</td>
    </tr>
    <tr>
        <th>Password</th>
        <td>@Html.Password("Password")</td>
    </tr>
    <tr>
        <td>@Html.ActionLink("LogOn", "LogOn", "Home")</td>
    </tr>
</table>