Imports System
Imports System.Collections.Generic
Imports System.Data.Entity

Namespace MvcBasic.Models

    Public Class MvcBasicInitializer

        Dim members As New List(Of User) _
    From {
    New User() With {
        .userName = "なまえ１",
        .mailAddress = "mail1@example.com",
        .remark = "備考1です"
    },
    New User() With {
        .userName = "なまえ２",
        .mailAddress = "mail2@example.com",
        .remark = "備考2です"
    }
}

    End Class

End Namespace