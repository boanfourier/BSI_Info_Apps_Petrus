Imports System.Web.UI

Public Class Logout
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' Clear the session variable to indicate that the user is logged out
        Session("LoggedIn") = False
    End Sub
End Class
