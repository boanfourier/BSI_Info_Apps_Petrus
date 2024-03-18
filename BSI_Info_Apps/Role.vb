Public Class Role
    Public Sub New()
        Me.Users = New List(Of User)()
    End Sub

    Public Property RoleID As Integer
    Public Property RoleName As String
    Public Property Users As IEnumerable(Of User)

End Class
