Imports System
Imports System.Collections.Generic
Imports System.Data.Entity

Namespace MvcBasic.Models

    Public Class MvcBasicInitializer

        Dim members As New List(Of Member) _
    From {
    New Member() With {
        .Name = "なまえ１",
        .Email = "mail1@example.com",
        .Birth = DateTime.Parse("1980-06-25"),
        .Married = False,
        .Memo = "備考1です"
    },
    New Member() With {
        .Name = "なまえ２",
        .Email = "mail2@example.com",
        .Birth = DateTime.Parse("1975-06-25"),
        .Married = False,
        .Memo = "備考2です"
    }
}

    End Class

End Namespace
