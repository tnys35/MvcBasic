Imports System.Web.Mvc

Namespace Controllers
    Public Class ViewController
        Inherits Controller

        ' GET: View
        Function From() As ActionResult
            Return View()
        End Function
    End Class
End Namespace