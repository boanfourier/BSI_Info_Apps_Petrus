Imports System

Public Class AddNotes
    Inherits System.Web.UI.Page

    Private ReadOnly _notesBLL As INotesBLL

    Public Sub New()
        _notesBLL = New NotesBLL()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAddNotes_Click(sender As Object, e As EventArgs)
        Try
            ' Validasi input sebelum menambahkan event
            If ValidateInput() Then
                Dim newNote As New CreateNotesDTO()

                newNote.event_id = txtevent_id.Text
                newNote.note_text = note_text.Text
                newNote.created_at = txtcreated_at.Text

                ' Tambahkan event
                _notesBLL.AddNote(newNote)

                ' Redirect ke halaman Events.aspx setelah berhasil menambahkan event
                Response.Redirect("/Notes.aspx")
            End If
        Catch ex As Exception
            ' Tangani kesalahan dengan menampilkan pesan kesalahan
            lblMessage.Text = "Terjadi kesalahan saat menambahkan event: " & ex.Message
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        ' Lakukan validasi input di sini

        If String.IsNullOrEmpty(txtevent_id.Text) Then
            lblMessage.Text = "Event ID harus diisi."
            Return False
        End If

        If String.IsNullOrEmpty(note_text.Text) Then
            lblMessage.Text = "Note Text harus diisi."
            Return False
        End If

        If String.IsNullOrEmpty(txtcreated_at.Text) Then
            lblMessage.Text = "Created harus diisi."
            Return False
        End If

        Return True
    End Function

End Class




