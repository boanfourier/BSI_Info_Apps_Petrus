Imports Dapper
Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports BSI_Info_Apps



Public Class UserDAL
    Implements IUserDAL

    Private Const strConn As String = "Server=.\SQLEXPRESS02;Database=BSI_info;Trusted_Connection=True;"
    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader

    Public Sub New()
        conn = New SqlConnection(strConn)
    End Sub

    Public Sub ChangePassword(username As String, newPassword As String) Implements IUserDAL.ChangePassword
        Throw New NotImplementedException()
    End Sub

    Public Sub Delete(id As Integer) Implements IUserDAL.Delete
        Throw New NotImplementedException()
    End Sub

    Public Function GetAll() As IEnumerable(Of User) Implements IUserDAL.GetAll
        Using connection As New SqlConnection(strConn)
            connection.Open()
            Dim strSql As String = "select * from Users order by Username"
            Dim results = conn.Query(Of User)(strSql)
            Return results
        End Using
    End Function

    Public Function GetById(id As Integer) As User Implements IUserDAL.GetById
        Throw New NotImplementedException()
    End Function

    Public Sub Insert(entity As User) Implements IUserDAL.Insert
        Using connection As New SqlConnection(strConn)
            connection.Open()
            Try
                Dim strSql As String = "insert into Users(Username,Password,FirstName,LastName,Address,Email,Telp) values(@Username,@Password,@FirstName,@LastName,@Address,@Email,@Telp)"
                Dim param = New With {
                .Username = entity.Username,
                .Password = entity.Password,
                .FirstName = entity.FirstName,
                .LastName = entity.LastName,
                .Address = entity.Address,
                .Email = entity.Email,
                .Telp = entity.Telp}

                Dim result As Integer = conn.Execute(strSql, param)
                If result <> 1 Then
                    Throw New System.Exception("Data tidak berhasil ditambahkan")
                End If

                Dim user As User = GetByUsername(entity.Username)

                Dim strSql2 As String = "INSERT INTO [dbo].[UsersRoles] ([RoleID] ,[Username]) VALUES (@Roleid ,@Username)"
                Dim param2 = New With {
                .Roleid = 2,
                .Username = entity.Username}

                Dim result2 As Integer = conn.Execute(strSql2, param2)

            Catch sqlEx As SqlException
                Throw New ArgumentException($"{sqlEx.Number}")
            Catch ex As Exception
                Throw New ArgumentException("Kesalahan: " & ex.Message)
            End Try
        End Using
    End Sub

    Public Function Login(username As String, password As String) As User Implements IUserDAL.Login
        Using connection As New SqlConnection(strConn)
            connection.Open()
            Dim strSql As String = "select * from Users where Username = @Username and Password = @Password"
            Dim param = New With {
                .Username = username,
                .Password = password
            }
            Dim result = conn.QueryFirstOrDefault(Of User)(strSql, param)
            If result Is Nothing Then
                Throw New ArgumentException("Username atau Password salah")
            End If

            Dim strSqlRole As String = "select r.* from UsersRoles ur inner join Roles r on ur.RoleID = r.RoleID where ur.Username = @Username"
            Dim roles = conn.Query(Of Role)(strSqlRole, param)
            result.Roles = roles

            Return result
        End Using
    End Function

    Public Sub Update(entity As User) Implements IUserDAL.Update
        Throw New NotImplementedException()
    End Sub

    Public Function GetByUsername(username As String) As User Implements IUserDAL.GetByUsername
        Using connection As New SqlConnection(strConn)
            connection.Open()
            Dim strSql As String = "select * from Users where Username = @Username"
            Dim param = New With {
                .Username = username
            }
            Dim result = conn.QueryFirstOrDefault(Of User)(strSql, param)
            Return result
        End Using
    End Function

    Public Function GetAllWithRoles() As IEnumerable(Of User) Implements IUserDAL.GetAllWithRoles
        Using connection As New SqlConnection(strConn)
            connection.Open()
            Dim strSql As String = "select * from Users"
            Dim users = conn.Query(Of User)(strSql)
            For Each user In users
                strSql = "select r.* from UsersRoles ur inner join Roles r on ur.RoleId = r.RoleId where ur.Username = @Username"
                Dim param = New With {
                    .Username = user.Username
                }
                Dim roles = conn.Query(Of Role)(strSql, param)
                user.Roles = roles
            Next
            Return users
        End Using
    End Function

    Public Function GetUserWithRoles(username As String) As User Implements IUserDAL.GetUserWithRoles
        Using connection As New SqlConnection(strConn)
            connection.Open()
            Dim strSql As String = "select * from Users where Username=@Username"
            Dim param = New With {
                .Username = username
            }
            Dim user = conn.QuerySingleOrDefault(Of User)(strSql, param)

            If user IsNot Nothing Then
                strSql = "select r.* from UsersRoles ur inner join Roles r on ur.RoleId = r.RoleId where ur.Username = @Username"
                Dim paramRole = New With {
                    .Username = user.Username
                }
                Dim roles = conn.Query(Of Role)(strSql, paramRole)
                user.Roles = roles
            End If

            Return user
        End Using
    End Function
End Class

