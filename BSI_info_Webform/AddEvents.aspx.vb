Imports System

Public Class AddEvents
    Inherits System.Web.UI.Page

    Private ReadOnly _eventsBLL As IEventsBLL

    Public Sub New()
        _eventsBLL = New EventsBLL()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Tidak ada yang perlu dilakukan saat halaman dimuat
    End Sub

    Protected Sub btnAddEvent_Click(sender As Object, e As EventArgs)
        Try
            ' Validasi input sebelum menambahkan event
            If ValidateInput() Then
                Dim newEvent As New CreateEventsDTO()
                newEvent.event_name = txtEventName.Text
                newEvent.description = txtDescription.Text
                newEvent.start_date = txtStartDate.Text
                newEvent.end_date = txtEndDate.Text
                newEvent.location_id = txtLocationId.Text
                newEvent.organizer_id = txtOrganizerId.Text

                ' Tambahkan event
                _eventsBLL.AddEvent(newEvent)

                ' Redirect ke halaman Events.aspx setelah berhasil menambahkan event
                Response.Redirect("/Events.aspx")
            End If
        Catch ex As Exception
            ' Tangani kesalahan dengan menampilkan pesan kesalahan
            lblMessage.Text = "Terjadi kesalahan saat menambahkan event: " & ex.Message
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        ' Lakukan validasi input di sini
        If String.IsNullOrEmpty(txtEventName.Text) Then
            lblMessage.Text = "Nama event harus diisi."
            Return False
        End If

        If String.IsNullOrEmpty(txtDescription.Text) Then
            lblMessage.Text = "Deskripsi event harus diisi."
            Return False
        End If

        If String.IsNullOrEmpty(txtStartDate.Text) Then
            lblMessage.Text = "Tanggal mulai event harus diisi."
            Return False
        End If

        If String.IsNullOrEmpty(txtEndDate.Text) Then
            lblMessage.Text = "Tanggal berakhir event harus diisi."
            Return False
        End If

        Return True
    End Function

End Class
