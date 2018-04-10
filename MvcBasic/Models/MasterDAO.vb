Imports System.Data.SqlClient

Public Class MasterDAO
    Inherits User

    Private conn As New System.Data.SqlClient.SqlConnection(My.Settings.connectionString)

    ''' <summary>
    ''' ユーザー情報一覧取得
    ''' </summary>
    ''' <returns></returns>
    Public Function fncGetUserList() As List(Of User)

        Dim userList As New List(Of User)

        Try
            ' データベース接続を開く
            conn.Open()

            Dim strSQL As New System.Text.StringBuilder
            strSQL.Append(" SELECT USERID, ")
            strSQL.Append("        PASSWORD, ")
            strSQL.Append("        USERNAME, ")
            strSQL.Append("        MAILADDRESS, ")
            strSQL.Append("        REMARK ")
            strSQL.Append(" FROM   MSUSER ")
            strSQL.Append(" ORDER BY USERID ")

            Dim cmd As New SqlCommand(strSQL.ToString, conn) ' コマンドの作成 
            Dim reader As SqlDataReader = cmd.ExecuteReader() ' コマンドの実行

            While reader.Read() ' 1 行読み込み 
                Dim u As New User
                u.USERID = reader("USERID").ToString
                u.PASSWORD = reader("PASSWORD").ToString
                u.USERNAME = reader("USERNAME").ToString
                u.MAILADDRESS = reader("MAILADDRESS").ToString
                u.REMARK = reader("REMARK").ToString
                userList.Add(u)
            End While
            reader.Close() ' リーダーのクローズ

        Catch ex As Exception
            Throw New Exception("ユーザー情報一覧の取得に失敗しました。" & vbCrLf & ex.Message & vbCrLf & Err.Description)
        Finally
            ' データベース接続を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            conn.Close()
            conn.Dispose()
        End Try
        Return userList

    End Function

    ''' <summary>
    ''' ユーザー情報取得
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    Public Function fncGetUser(ByVal userId As String) As User
        Dim user As New User

        Try
            Dim userList As List(Of User) = fncGetUserList()
            Dim userListLinq As IEnumerable(Of User) = From u In userList Where u.userId = userId
            Array.ForEach(userListLinq.ToArray(), AddressOf Console.WriteLine)

            If userListLinq.Count = 1 Then
                user.USERID = userListLinq(0).USERID
                user.PASSWORD = userListLinq(0).PASSWORD
                user.USERNAME = userListLinq(0).USERNAME
                user.MAILADDRESS = userListLinq(0).MAILADDRESS
                user.REMARK = userListLinq(0).REMARK
            End If
        Catch ex As Exception
            Throw New Exception("ユーザー情報の取得に失敗しました。" & vbCrLf & Err.Description & vbCrLf & ex.Message)
        End Try
        Return user

    End Function

    ''' <summary>
    ''' ユーザー情報編集
    ''' </summary>
    ''' <param name="user"></param>
    ''' <returns></returns>
    Public Function fncEditUser(ByVal user As User) As Boolean

        Try
            ' データベース接続を開く
            conn.Open()

            Dim strSQL As New System.Text.StringBuilder
            strSQL.Append(" MERGE INTO MSUSER A ")
            strSQL.Append(" USING ( ")
            strSQL.Append("     SELECT ")
            strSQL.Append("         @USERID      AS USERID, ")
            strSQL.Append("         @USERNAME    AS USERNAME, ")
            strSQL.Append("         @MAILADDRESS AS MAILADDRESS, ")
            strSQL.Append("         @REMARK      AS REMARK ")
            strSQL.Append("     ) B ")
            strSQL.Append(" ON (A.USERID = B.USERID) ")
            strSQL.Append(" WHEN MATCHED THEN ")
            strSQL.Append("     UPDATE SET ")
            strSQL.Append("         USERNAME    = B.USERNAME, ")
            strSQL.Append("         MAILADDRESS = B.MAILADDRESS, ")
            strSQL.Append("         REMARK      = B.REMARK ")
            strSQL.Append(" WHEN NOT MATCHED THEN ")
            strSQL.Append("     INSERT ")
            strSQL.Append("         (  USERID,  USERNAME,  PASSWORD,  MAILADDRESS,  REMARK) ")
            strSQL.Append("     VALUES ")
            strSQL.Append("         (B.USERID,B.USERNAME,B.USERID  ,B.MAILADDRESS,B.REMARK); ")
            Dim cmd As New SqlCommand(strSQL.ToString, conn) ' コマンドの作成 
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@USERID", SqlDbType.NVarChar, 50).Value = user.userId
            cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar, 50).Value = user.userName
            cmd.Parameters.Add("@MAILADDRESS", SqlDbType.NVarChar, 50).Value = user.mailAddress
            cmd.Parameters.Add("@REMARK", SqlDbType.NVarChar, 50).Value = user.remark

            Dim ret As Integer = cmd.ExecuteNonQuery() ' コマンドの実行

            If ret = 0 Then
                Return False
            End If

            conn.Close() ' 接続のクローズ 

        Catch ex As Exception
            Throw New Exception("ユーザー情報の更新に失敗しました。" & vbCrLf & Err.Description)
        Finally
            ' データベース接続を閉じる (正しくは オブジェクトの破棄を保証する を参照)
            conn.Close()
            conn.Dispose()
        End Try
        Return True

    End Function

End Class
