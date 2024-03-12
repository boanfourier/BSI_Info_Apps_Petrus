Public Class UpdateEvents
    Inherits System.Web.UI.Page
    Private ReadOnly _eventsBLL As IEventsBLL
    Public Sub New()
        _eventsBLL = New EventsBLL()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim events_id As Integer = Request.QueryString("ID")
        Dim events = _eventsBLL.GetEventById(events_id)
        txtEventName.Text = events.event_name
        txtDescription.Text = events.description
        txtStartDate.Text = events.start_date
        txtEndDate.Text = events.end_date
        txtLocationId.Text = events.location_id
        txtOrganizerId.Text = events.organizer_id

    End Sub

    Protected Sub btnupdEvent_Click(sender As Object, e As EventArgs)
        Try
            ' Validasi input sebelum menambahkan event
            If ValidateInput() Then
                Dim updateEvent As New UpdateEventsDTO()
                updateEvent.event_id = Request.QueryString("ID")
                updateEvent.event_name = txtEventName.Text
                updateEvent.description = txtDescription.Text
                updateEvent.start_date = txtStartDate.Text
                updateEvent.end_date = txtEndDate.Text
                updateEvent.location_id = txtLocationId.Text
                updateEvent.organizer_id = txtOrganizerId.Text
                _eventsBLL.UpdateEvent(updateEvent)

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