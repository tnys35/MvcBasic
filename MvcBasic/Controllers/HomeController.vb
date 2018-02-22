Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Function Logon() As ActionResult
        Return View()
    End Function

    <AllowAnonymous>
    <HttpPost>
    Function Logon(ByVal user As Member) As ActionResult

        If String.IsNullOrEmpty(user.UserId) Then
            ModelState.AddModelError("userId", "userId" & "を入力して下さい。")
        End If

        If String.IsNullOrEmpty(user.PassWord) Then
            ModelState.AddModelError("passWord", "passWord" & "を入力して下さい。")
        End If

        If Not ModelState.IsValid Then
            Return View(user)
        End If

        Session("userid") = user.UserId
        Return RedirectToAction("Menu", "Home")
    End Function

    Function Menu() As ActionResult
        If String.IsNullOrEmpty(Session("userid")) Then
            Return RedirectToAction("Logon", "Home")
        End If

        Return View()
    End Function

End Class
