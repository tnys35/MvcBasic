Imports System.Web.Mvc

Namespace Controllers
    Public Class TestController
        Inherits Controller

        ' GET: Test
        Function Index() As ActionResult
            Return View()
        End Function

        Public Function TestPage1() As ActionResult
            Return View()
        End Function

        Public Function TestPage2() As ActionResult
            Return View()
        End Function

    End Class
End Namespace