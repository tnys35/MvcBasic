Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class User

    Private _userId As String
    <DisplayName("ユーザーID")>
    Public Property userId() As String
        Get
            Return _userId
        End Get
        Set(ByVal value As String)
            _userId = value
        End Set
    End Property

    Private _passWord As String
    <DisplayName("パスワード")>
    Public Property passWord() As String
        Get
            Return _passWord
        End Get
        Set(ByVal value As String)
            _passWord = value
        End Set
    End Property

    Private _UserName As String
    <DisplayName("ユーザー名")>
    Public Property userName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    Private _MailAddress As String
    <DisplayName("メールアドレス")>
    Public Property mailAddress() As String
        Get
            Return _MailAddress
        End Get
        Set(ByVal value As String)
            _MailAddress = value
        End Set
    End Property

    Private _Remark As String
    <DisplayName("備考")>
    Public Property remark() As String
        Get
            Return _Remark
        End Get
        Set(ByVal value As String)
            _Remark = value
        End Set
    End Property


End Class
