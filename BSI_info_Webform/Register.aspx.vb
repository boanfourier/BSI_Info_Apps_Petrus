Imports System.Data.SqlClient

Public Class Register
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs)
        If (Page.IsValid) Then
            Dim registerFirstname As String = txtRegisterFirstName.Text
            Dim registerLastName As String = txtRegisterLastName.Text
            Dim registerUsername As String = txtRegisterUsername.Text
            Dim registerPassword As String = txtRegisterPassword.Text
            Dim registerEmail As String = txtRegisterEmail.Text
            Dim registerPhone As String = txtRegisterPhone.Text

            If (Not IsUserExist(registerUsername, registerEmail) AndAlso RegisterUser(registerFirstname, registerLastName, registerUsername, registerPassword, registerEmail, registerPhone)) Then
                lblRegistrationStatus.Text = "Registration successful. You can now login."
                lblRegistrationStatus.Visible = True
                Response.Redirect("Login.aspx") ' Redirect to the login page after successful registration
            Else
                lblRegistrationStatus.Text = "Registration failed. Username or email already exists. Please try again."
                lblRegistrationStatus.Visible = True
            End If
        End If
    End Sub

    Protected Function IsUserExist(registerUsername As String, registerEmail As String) As Boolean
        Dim connectionString = "Data Source=BSINB23L014\SQLEXPRESS02;Initial Catalog=BSI_info;Integrated Security=True"

        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT COUNT(*) FROM Participants WHERE username = @username OR email = @email"

            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@username", registerUsername)
                cmd.Parameters.AddWithValue("@email", registerEmail)

                connection.Open()

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                connection.Close()

                Return count > 0
            End Using
        End Using
    End Function

    Protected Function RegisterUser(registerFirstName As String, registerLastName As String, registerUsername As String, registerPassword As String, registerEmail As String, registerPhone As String) As Boolean
        Dim connectionString = "Data Source=BSINB23L014\SQLEXPRESS02;Initial Catalog=BSI_info;Integrated Security=True"

        Using connection As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO Participants (FirstName,LastName, username, password, email, phone) VALUES (@FirstName, @LastName, @username, @password, @email, @phone)"

            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@FirstName", registerFirstName)
                cmd.Parameters.AddWithValue("@LastName", registerLastName)
                cmd.Parameters.AddWithValue("@username", registerUsername)
                cmd.Parameters.AddWithValue("@password", registerPassword)
                cmd.Parameters.AddWithValue("@email", registerEmail)
                cmd.Parameters.AddWithValue("@phone", registerPhone)

                Try
                    connection.Open()
                    cmd.ExecuteNonQuery()
                    Return True
                Catch ex As Exception
                    Return False
                Finally
                    connection.Close()
                End Try
            End Using
        End Using
    End Function
End Class
