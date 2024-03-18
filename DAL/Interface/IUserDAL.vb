Imports BSI_Info_Apps

Public Interface IUserDAL
    Inherits ICrud(Of User)

    Function GetAllWithRoles() As IEnumerable(Of User)
    Function GetUserWithRoles(username As String) As User
    Function GetByUsername(username As String) As User
    Function Login(username As String, password As String) As User
    Sub ChangePassword(username As String, newPassword As String)
End Interface

