Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace Controllers

    Public Class BeginController
        Inherits Controller

        ' GET: Begin
        Function Index() As ActionResult
            Return View("こんにちは、世界！")
        End Function

        Public Function Show() As ActionResult
            ViewBag.Message = "こんにちは、世界!"
            Return View()
        End Function

    End Class

End Namespace