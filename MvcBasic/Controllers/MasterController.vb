Namespace Controllers

    Public Class MasterController
        Inherits Controller

        Dim _db_Master As New MasterDAO

        ' GET: Master
        Function userMaster() As ActionResult
            Dim userList As New List(Of User)

            Try
                userList = _db_Master.fncGetUserList()
            Catch ex As Exception
                ViewData("Message") = "ログイン処理に失敗しました。" & vbCrLf & ex.Message
                Return View()
            End Try

            Return View(userList)
        End Function

        Function editUser(ByVal userId As String) As ActionResult
            Dim u As New User
            Try
                u = _db_Master.fncGetUser(userId)
            Catch ex As Exception
                Return View()
            End Try

            Return View(u)
        End Function

        <AllowAnonymous>
        <HttpPost>
        Function editUser(ByVal user As User) As ActionResult

            Try
                If Not _db_Master.fncEditUser(user) Then
                    ViewData("Message") = "ユーザー編集に失敗しました。"
                End If

                ViewData("Message") = "ユーザー編集が完了しました。"
            Catch ex As Exception
                ViewData("Message") = "ユーザー編集に失敗しました。" & vbCrLf & ex.Message
            End Try
            Return View()

        End Function
    End Class
End Namespace