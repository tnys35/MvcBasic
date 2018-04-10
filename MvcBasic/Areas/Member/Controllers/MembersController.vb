Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports MvcBasic.Areas.Member

Namespace Areas.Member.Controllers
    Public Class MembersController
        Inherits System.Web.Mvc.Controller

        Private db As New MemberContext

        ' GET: Member/Members
        Function Index() As ActionResult
            Return View(db.Member.ToList())
        End Function

        ' GET: Member/Members/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim member As Member = db.Member.Find(id)
            If IsNothing(member) Then
                Return HttpNotFound()
            End If
            Return View(member)
        End Function

        ' GET: Member/Members/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Member/Members/Create
        '過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        '詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Name,Email,BirthDay,Memo")> ByVal member As Member) As ActionResult
            If ModelState.IsValid Then
                db.Member.Add(member)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(member)
        End Function

        ' GET: Member/Members/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim member As Member = db.Member.Find(id)
            If IsNothing(member) Then
                Return HttpNotFound()
            End If
            Return View(member)
        End Function

        ' POST: Member/Members/Edit/5
        '過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        '詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Name,Email,BirthDay,Memo")> ByVal member As Member) As ActionResult
            If ModelState.IsValid Then
                db.Entry(member).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(member)
        End Function

        ' GET: Member/Members/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim member As Member = db.Member.Find(id)
            If IsNothing(member) Then
                Return HttpNotFound()
            End If
            Return View(member)
        End Function

        ' POST: Member/Members/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim member As Member = db.Member.Find(id)
            db.Member.Remove(member)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
