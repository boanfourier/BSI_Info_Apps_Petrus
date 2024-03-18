Imports BSI_Info_Apps

Public Interface IRoleDAL
    Inherits ICrud(Of Role)

    Sub AddUserToRole(username As String, roleId As Integer)
End Interface

