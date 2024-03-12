Imports System.Threading.Tasks

Public Class Tasks
    Inherits System.Web.UI.Page
    Private ReadOnly _tasksBLL As ITasksBLL
    Public Sub New()
        _tasksBLL = New TasksBLL()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindEventsToGridView()
        End If
    End Sub
    Private Sub BindEventsToGridView()
        Dim tasks = _tasksBLL.GetTasks()
        GridViewTasks.DataSource = tasks
        GridViewTasks.DataBind()
    End Sub

End Class




