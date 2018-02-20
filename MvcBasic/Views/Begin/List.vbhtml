@Model  IEnumerable(MvcBasic.Models.Member)

@Code
    ViewData("Title") = "List"
End Code

<h2>List</h2>

<table class="table">
    <tr>
        <th>氏名</th><th>メールアドレス</th><th>誕生日</th><th>既婚</th><th>備考</th>
    </tr>
</table>