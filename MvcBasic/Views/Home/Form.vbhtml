@ModelType Member

@Code
    ViewData("Title") = "Form"
End Code

<h2>Form</h2>

@Html.TextBoxFor(Function(model) model.UserId, New With {.readonly = "readOnly", .size = 30, .maxlength = 40})
