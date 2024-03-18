Imports Dapper
Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports BSI_Info_Apps


Public Class RoleDAL
        Implements IRoleDAL

        Private Const strConn As String = "Server=.\SQLEXPRESS02;Database=BSI_info;Trusted_Connection=True;"
        Private conn As SqlConnection
        Private cmd As SqlCommand
        Private dr As SqlDataReader

        Public Sub New()
            conn = New SqlConnection(strConn)
        End Sub

        Public Sub Delete(id As Integer) Implements IRoleDAL.Delete
            Throw New NotImplementedException()
        End Sub

        Public Function GetAll() As IEnumerable(Of Role) Implements IRoleDAL.GetAll
            Using connection As New SqlConnection(strConn)
                connection.Open()
                Dim strSql As String = "select * from Roles order by RoleName"
                Dim results = conn.Query(Of Role)(strSql)
                Return results
            End Using
        End Function

        Public Function GetById(id As Integer) As Role Implements IRoleDAL.GetById
            Using connection As New SqlConnection(strConn)
                connection.Open()
                Dim strSql As String = "select * from Roles where RoleID = @RoleID"
                Dim param = New With {.RoleID = id}
                Dim result = conn.QueryFirstOrDefault(Of Role)(strSql, param)
                Return result
            End Using
        End Function

        Public Sub Insert(entity As Role) Implements IRoleDAL.Insert
            Using connection As New SqlConnection(strConn)
                connection.Open()
                Dim strSql As String = "insert into Roles(RoleName) values(@RoleName)"
                Dim param = New With {.RoleName = entity.RoleName}
                Try
                    Dim result As Integer = conn.Execute(strSql, param)
                    If result <> 1 Then
                        Throw New Exception("Data tidak berhasil ditambahkan")
                    End If
                Catch sqlEx As SqlException
                    Throw New ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}")
                Catch ex As Exception
                    Throw New ArgumentException("Kesalahan: " & ex.Message)
                End Try
            End Using
        End Sub

        Public Sub Update(entity As Role) Implements IRoleDAL.Update
            Throw New NotImplementedException()
        End Sub

        Public Sub AddUserToRole(username As String, roleId As Integer) Implements IRoleDAL.AddUserToRole
            Using connection As New SqlConnection(strConn)
                connection.Open()
                Dim strSql As String = "insert into UsersRoles(Username, RoleID) values(@Username, @RoleID)"
                Dim param = New With {.Username = username, .RoleID = roleId}
                Try
                    Dim result As Integer = conn.Execute(strSql, param)
                    If result <> 1 Then
                        Throw New Exception("Data tidak berhasil ditambahkan")
                    End If
                Catch sqlEx As SqlException
                    Throw New ArgumentException($"{sqlEx.InnerException.Message} - {sqlEx.Number}")
                Catch ex As Exception
                    Throw New ArgumentException("Kesalahan: " & ex.Message)
                End Try
            End Using
        End Sub
    End Class

