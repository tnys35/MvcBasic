Imports System.Data.SqlClient

Public Class MasterDAO
    Inherits User

    ''' <summary>
    ''' ユーザー情報取得
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function fncGetUser(ByVal userId As String) As User

        Dim user As New User

        ' 接続文字列を生成する
        Dim stConnectionString As String = My.Settings.connectionString

        ' conn の新しいインスタンスを生成する (接続文字列を指定)
        Dim conn As New System.Data.SqlClient.SqlConnection(stConnectionString)

        Try
            ' データベース接続を開く
            conn.Open()

            Dim strSQL As String = "SELECT USERID,PASSWORD,USERNAME,MAILADDRESS,REMARK FROM MSUSER WHERE USERID = '" & userId & "' "
            Dim cmd As New SqlCommand(strSQL, conn) ' コマンドの作成 
            Dim reader As SqlDataReader = cmd.ExecuteReader() ' コマンドの実行

            While reader.Read() ' 1 行読み込み 
                user.userId = reader("USERID")
                user.passWord = reader("PASSWORD")
                user.userName = reader("USERNAME")
                user.mailAddress = reader("MAILADDRESS")
                user.remark = reader("REMARK")
            End While

            reader.Close() ' リーダーのクローズ 
            conn.Close() ' 接続のクローズ 

        Catch ex As Exception
            Return user
        Finally
            ' データベース接続を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            conn.Close()
            conn.Dispose()
        End Try
        Return user

    End Function

    ''' <summary>
    ''' ユーザー情報一覧取得
    ''' </summary>
    ''' <returns></returns>
    Public Function fncGetUserList() As List(Of User)

        Dim userList As New List(Of User)

        ' 接続文字列を生成する
        Dim stConnectionString As String = My.Settings.connectionString

        ' conn の新しいインスタンスを生成する (接続文字列を指定)
        Dim conn As New System.Data.SqlClient.SqlConnection(stConnectionString)

        Try
            ' データベース接続を開く
            conn.Open()

            Dim strSQL As String = "SELECT USERID,USERNAME,MAILADDRESS,REMARK FROM MSUSER ORDER BY USERID "
            Dim cmd As New SqlCommand(strSQL, conn) ' コマンドの作成 
            Dim reader As SqlDataReader = cmd.ExecuteReader() ' コマンドの実行

            While reader.Read() ' 1 行読み込み 
                Dim u As New User
                u.userId = reader("USERID")
                u.userName = reader("USERNAME")
                u.mailAddress = reader("MAILADDRESS")
                u.remark = reader("REMARK")
                userList.Add(u)
            End While

            reader.Close() ' リーダーのクローズ 
            conn.Close() ' 接続のクローズ 

        Catch ex As Exception

        Finally
            ' データベース接続を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            conn.Close()
            conn.Dispose()
        End Try
        Return userList

    End Function

    ''' <summary>
    ''' ユーザー情報編集
    ''' </summary>
    ''' <param name="user"></param>
    ''' <returns></returns>
    Public Function fncEditUser(ByVal user As User) As Boolean

        ' 接続文字列を生成する
        Dim stConnectionString As String = My.Settings.connectionString

        ' conn の新しいインスタンスを生成する (接続文字列を指定)
        Dim conn As New System.Data.SqlClient.SqlConnection(stConnectionString)

        Try
            ' データベース接続を開く
            conn.Open()

            Dim strSQL As New System.Text.StringBuilder
            strSQL.Append(" UPDATE MSUSER SET ")
            strSQL.Append("      USERNAME = '" & user.userName & " ', ")
            strSQL.Append("      MAILADDRESS = '" & user.mailAddress & " ', ")
            strSQL.Append("      REMARK = '" & user.remark & " ' ")
            strSQL.Append(" WHERE USERID = '" & user.userId & "' ")
            Dim cmd As New SqlCommand(strSQL.ToString, conn) ' コマンドの作成 
            Dim ret As Integer = cmd.ExecuteNonQuery() ' コマンドの実行

            If ret = 0 Then
                Return False
            End If

            conn.Close() ' 接続のクローズ 

        Catch ex As Exception
            Return False
        Finally
            ' データベース接続を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            conn.Close()
            conn.Dispose()
        End Try
        Return True

    End Function

End Class
