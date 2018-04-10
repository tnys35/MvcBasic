Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Dim _db_Master As New MasterDAO

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
    Function Logon(ByVal user As User) As ActionResult

        If String.IsNullOrEmpty(user.userId) Then
            ModelState.AddModelError("userId", "userId" & "を入力して下さい。")
        End If

        If String.IsNullOrEmpty(user.passWord) Then
            ModelState.AddModelError("passWord", "passWord" & "を入力して下さい。")
        End If

        If Not ModelState.IsValid Then
            Return View(user)
        End If

        Dim u As New User
        Try
            u = _db_Master.fncGetUser(user.userId)
        Catch ex As Exception
            ViewData("Message") = "ログイン処理に失敗しました。" & vbCrLf & ex.Message
            Return View()
        End Try

        If u Is Nothing OrElse String.IsNullOrEmpty(u.userId) Then
            ViewData("Message") = "対象のユーザーIDは存在しません。"
            Return View()
        Else
            If Not u.passWord = user.passWord Then
                ViewData("Message") = "入力したパスワードが間違っています。"
                Return View()
            End If
        End If

        Session("userid") = u.userId
        Session("username") = u.userName
        Return RedirectToAction("Menu", "Home")
    End Function

    Function Menu() As ActionResult
        If String.IsNullOrEmpty(Session("userid")) Then
            Return RedirectToAction("Logon", "Home")
        End If

        Return View()
    End Function

    ' GET: View
    Function From() As ActionResult
        Return View()
    End Function

End Class
