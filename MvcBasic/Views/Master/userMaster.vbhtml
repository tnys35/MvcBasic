@modeltype IList(Of User)

@Code
    ViewData("Title") = "ユーザー一覧"
End Code

<h2>ユーザー一覧</h2>

<table class="table" border="1">
    <tr>
        <th>ユーザーID</th>
        <th>氏名</th>
        <th>メールアドレス</th>
        <th>備考</th>
        <th>編集</th>
    </tr>
    @For Each item In Model
        @<tr>
            <td>@item.UserId</td>
            <td>@item.UserName</td>
            <td>@item.MailAddress</td>
            <td>@item.Remark</td>
            <td>@Html.ActionLink("編集", "editUser", "Master", item, New With {.class = "btn btn-default", .width = "200"})</td>
        </tr>
    Next
</table>