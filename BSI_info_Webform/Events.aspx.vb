Imports System.Data.SqlClient
Imports BSI_Info_BLL

Public Class events
    Inherits System.Web.UI.Page
    Private ReadOnly _eventsBLL As IEventsBLL
    Public Sub New()
        _eventsBLL = New EventsBLL()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindEventsToGridView()
        End If
    End Sub

    Private Sub BindEventsToGridView()
        Dim events = _eventsBLL.GetAllEvents()
        GridViewEvents.DataSource = events
        GridViewEvents.DataBind()
    End Sub

End Class
