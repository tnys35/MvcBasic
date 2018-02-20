Imports System.Data.Entity

Namespace MvcBasic.Models

    Public Class MvcBasicContext

        Private _DbSet As Member
        Public Property DbSet As Member
            Get
                Return _DbSet
            End Get
            Set(value As Member)
                _DbSet = value
            End Set
        End Property

    End Class

End Namespace

