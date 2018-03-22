@ModelType Member

@Code
    ViewData("Title") = "TestPage2"
End Code

<h2>TestPage2</h2>

@*フォームを生成する*@
@*
    //アクション名
    //コントローラー名
    //ルートパラメーター
    //HTTPメソッド
    //その他属性
*@
@Using Html.BeginForm("Edit", "Result", New With {.id = "H15A1", .charset = "uf-8"}, FormMethod.Post, New With {.id = "fm", .enctype = "multipart/form-data"})

    @Html.TextBoxFor(Function(model) model.UserId, New With {.readonly = "readOnly", .size = 30, .maxlength = 40})


End Using

@*<form action="/Result/Edit/H15A1?charset=uf-8" enctype="multipart/form-data" id="fm" method="post"></form>*@