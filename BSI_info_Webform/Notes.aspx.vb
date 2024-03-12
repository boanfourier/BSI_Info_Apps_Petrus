Imports System.Threading.Tasks

Public Class Notes
    Inherits Page
    Private ReadOnly _notesBLL As INotesBLL
    Public Sub New()
        _notesBLL = New NotesBLL()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindEventsToGridView()
        End If
    End Sub

    Private Sub BindEventsToGridView()
        Dim notes = _notesBLL.GetAllNotes()
        GridViewNotes.DataSource = notes
        GridViewNotes.DataBind()
    End Sub

End Class







