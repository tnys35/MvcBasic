Imports System.Data.Entity

Namespace MvcBasic.Models

    Public Class MvcBasicContext

        Private _DbSet As User
        Public Property DbSet As User
            Get
                Return _DbSet
            End Get
            Set(value As User)
                _DbSet = value
            End Set
        End Property

    End Class

End Namespace