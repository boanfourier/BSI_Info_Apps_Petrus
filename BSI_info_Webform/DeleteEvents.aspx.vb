Imports System.Threading.Tasks

Public Class DeleteEvents
    Inherits System.Web.UI.Page
    Private ReadOnly _eventsBLL As IEventsBLL
    Public Sub New()
        _eventsBLL = New EventsBLL()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Tidak ada yang perlu dilakukan di sini pada saat halaman dimuat
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim eventId As Integer = Integer.Parse(Request.QueryString("ID"))
        _eventsBLL.DeleteEvent(eventId)
        Response.Redirect("/Events")

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        ' Redirect pengguna kembali ke halaman sebelumnya (Events.aspx)
        Response.Redirect("/Events")
    End Sub


End Class
