Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Namespace Areas.Member
    Partial Public Class MemberContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("name=MemberContext")
        End Sub

        Public Overridable Property Member As DbSet(Of Member)

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        End Sub
    End Class
End Namespace