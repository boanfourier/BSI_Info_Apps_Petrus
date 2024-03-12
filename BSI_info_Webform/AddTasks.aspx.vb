Public Class AddTasks
    Inherits System.Web.UI.Page
    Private ReadOnly _tasksBLL As ITasksBLL

    Public Sub New()
        _tasksBLL = New TasksBLL()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAddTasks_Click(sender As Object, e As EventArgs)
        Try
            ' Validasi input sebelum menambahkan event
            If ValidateInput() Then
                Dim newTask As New CreateTasksDTO()
                newTask.event_id = txtevent_id.Text
                newTask.description = txtdescription.Text
                newTask.deadline = txtDeadline.Text
                newTask.status = txtstatus.Text
                ' Tambahkan event
                _tasksBLL.AddTask(newTask)

                ' Redirect ke halaman Events.aspx setelah berhasil menambahkan event
                Response.Redirect("/Tasks.aspx")
            End If
        Catch ex As Exception
            ' Tangani kesalahan dengan menampilkan pesan kesalahan
            lblMessage.Text = "Terjadi kesalahan saat menambahkan task: " & ex.Message
        End Try
    End Sub

    Private Function ValidateInput() As Boolean
        ' Lakukan validasi input di sini


        If String.IsNullOrEmpty(txtevent_id.Text) Then
            lblMessage.Text = "Event ID harus diisi."
            Return False
        End If

        If String.IsNullOrEmpty(txtdescription.Text) Then
            lblMessage.Text = "Deskripsi harus diisi."
            Return False
        End If

        If String.IsNullOrEmpty(txtDeadline.Text) Then
            lblMessage.Text = "Deadline harus diisi."
            Return False
        End If

        If String.IsNullOrEmpty(txtstatus.Text) Then
            lblMessage.Text = "Status harus diisi."
            Return False
        End If

        Return True
    End Function
End Class




