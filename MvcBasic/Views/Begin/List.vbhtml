﻿@modeltype List(Of User)

@Code
    ViewData("Title") = "List"
End Code

<h2>List</h2>

<table class="table">
    <tr>
        <th>ユーザーID</th>
        <th>氏名</th>
        <th>メールアドレス</th>
        <th>備考</th>
    </tr>
    @For Each item In Model
        @<tr>
            <td>@item.UserId</td>
            <td>@item.UserName</td>
            <td>@item.MailAddress</td>
            <td>@item.Remark</td>
        </tr>
    Next
</table>