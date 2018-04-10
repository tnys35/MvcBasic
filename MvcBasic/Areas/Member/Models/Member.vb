Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Namespace Areas.Member
    <Table("Member")>
    Partial Public Class Member
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        Public Property Id As Integer

        <StringLength(50)>
        Public Property Name As String

        <StringLength(50)>
        Public Property Email As String

        <Column(TypeName:="date")>
        Public Property BirthDay As Date?

        <StringLength(50)>
        Public Property Memo As String
    End Class
End Namespace