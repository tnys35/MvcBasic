@modeltype List(Of User)

@Code
    ViewData("Title") = "ユーザー一覧"
End Code

<h2>ユーザー一覧</h2>
<br />
@Using Html.BeginForm("Logon", "Home", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
    @Html.AntiForgeryToken()
    @<text>
        <div class="container">
            <div class="table-responsive">
                <p>@Html.ActionLink("New", "editUser", "Master")</p>
                <Table Class="table table-striped table-bordered">
                    <thead>
                        <tr>
                            <th> ユーザーID</th>
                            <th> 氏名</th>
                            <th> メールアドレス</th>
                            <th> 備考</th>
                            <th> 編集</th>
                        </tr>
                    </thead>
                    <tbody>
                        @For Each item In Model
                            @<tr>
                                <td>@item.userId</td>
                                <td>@item.userName</td>
                                <td>@item.mailAddress</td>
                                <td>@item.remark</td>
                                <td>@Html.ActionLink("編集", "editUser", "Master", item)</td>
                            </tr>
                        Next
                    </tbody>
                </Table>
            </div>
        </div>
    </text>
End Using
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
