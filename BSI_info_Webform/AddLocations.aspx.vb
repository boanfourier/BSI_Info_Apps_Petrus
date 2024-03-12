Public Class AddLocations
    Inherits System.Web.UI.Page
    Private ReadOnly _locationsBLL As ILocationsBLL
    Public Sub New()
        _locationsBLL = New LocationsBLL()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAddLocations_Click(sender As Object, e As EventArgs)
        Try
            ' Validasi input sebelum menambahkan event
            If ValidateInput() Then
                Dim newLocations As New CreateLocationsDTO()
                newLocations.name = txtName.Text
                newLocations.address = txtAddress.Text
                newLocations.capacity = txtCapacity.Text
                newLocations.description = txtDescription.Text


                _locationsBLL.AddLocation(newLocations)

                ' Redirect ke halaman Events.aspx setelah berhasil menambahkan event
                Response.Redirect("/Locations.aspx")
            End If
        Catch ex As Exception
            ' Tangani kesalahan dengan menampilkan pesan kesalahan
            lblMessage.Text = "Terjadi kesalahan saat menambahkan location: " & ex.Message
        End Try
    End Sub
    Private Function ValidateInput() As Boolean
        ' Lakukan validasi input di sini
        If String.IsNullOrEmpty(txtName.Text) Then
            lblMessage.Text = "Nama event harus diisi."
            Return False
        End If

        If String.IsNullOrEmpty(txtAddress.Text) Then
            lblMessage.Text = "Addres harus diisi."
            Return False
        End If
        If String.IsNullOrEmpty(txtCapacity.Text) Then
            lblMessage.Text = "Capacity harus diisi."
            Return False
        End If

        If String.IsNullOrEmpty(txtDescription.Text) Then
            lblMessage.Text = " Descripstion harus diisi."
            Return False
        End If
        Return True
    End Function
End Class





