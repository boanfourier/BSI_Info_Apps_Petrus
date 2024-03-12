Imports System.Data.SqlClient

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' Disable browser back button after logout
        If Not IsPostBack Then
            If Session("LoggedIn") IsNot Nothing AndAlso CBool(Session("LoggedIn")) Then
                DisableBackButton()
            End If
        End If
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim username As String = txtusername.Text
        Dim password As String = txtPassword.Text

        If (ValidateUser(username, password)) Then
            ' Set the session variable to indicate that the user is logged in
            Session("LoggedIn") = True

            Dim Script As String = "alert('Login berhasil!');"
            Script += "window.location.href = 'default.aspx';"
            ClientScript.RegisterStartupScript(Me.GetType(), "SuccessScript", Script, True)
        Else
            Response.Write("<script>alert('Login gagal. Cek kembali username dan password Anda.');</script>")
        End If
    End Sub

    Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Check if the user is logged in before allowing logout
        If Session("LoggedIn") IsNot Nothing AndAlso CBool(Session("LoggedIn")) Then
            ' Clear the session variable to indicate that the user is logged out
            Session("LoggedIn") = False
            ' Redirect to the login page or any other appropriate page
            Response.Redirect("login.aspx")
        Else
            Response.Write("<script>alert('Anda belum login.');</script>")
        End If
    End Sub

    Protected Function ValidateUser(username As String, password As String) As Boolean
        Dim connectionString = "Data Source=BSINB23L014\SQLEXPRESS02;Initial Catalog=BSI_info;Integrated Security=True"

        Using connection As New SqlConnection(connectionString)
            Dim Query As String = "SELECT COUNT(*) FROM Participants WHERE username = @username AND password = @password"

            Using cmd As New SqlCommand(Query, connection)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)

                connection.Open()
                Dim count As Integer = CInt(cmd.ExecuteScalar())
                connection.Close()

                Return count > 0
            End Using
        End Using
    End Function

    Private Sub DisableBackButton()
        ' Disable browser back button using JavaScript
        Dim script As String = "window.history.forward();"
        script += "function noBack() { window.history.forward(); }"
        script += "noBack();"
        script += "window.onload = noBack;"
        script += "window.onpageshow = function(evt) { if (evt.persisted) noBack(); };"
        script += "window.onunload = function() { void (0); };"
        ClientScript.RegisterStartupScript(Me.GetType(), "DisableBackButtonScript", script, True)
    End Sub
End Class
