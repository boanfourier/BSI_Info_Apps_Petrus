Imports System.Data.SqlClient
Imports BSI_Info_Apps


Public Class OrganizerDal
    Implements IOrganizers
    Private Const strConn As String = "Server=.\SQLEXPRESS02;Database=BSI_info;Trusted_Connection=True;"
    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader

    Public Sub New()
        conn = New SqlConnection(strConn)
    End Sub

    Public Function GetAll() As List(Of Organizer) Implements IOrganizers.GetAllOrganizer
        Dim organizers As New List(Of Organizer)()
        Using conn As New SqlConnection(strConn)
            Dim strSql As String = "SELECT * FROM Organizers ORDER BY Name"
            Using cmd As New SqlCommand(strSql, conn)
                conn.Open()

                Dim dr As SqlDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    While dr.Read()
                        organizers.Add(New Organizer With {
                            .organizer_id = Convert.ToInt32(dr("organizer_id")),
                            .name = dr("name").ToString(),
                            .email = dr("email").ToString(),
                            .phone = dr("phone").ToString()
                        })
                    End While
                End If

                dr.Close()
            End Using
        End Using

        Return organizers
    End Function

    Public Sub AddOrganizer(ByVal organizer As Organizer) Implements IOrganizers.AddOrganizer
        Using conn As New SqlConnection(strConn)
            conn.Open()
            Dim strSql As String = "INSERT INTO Organizers (name, email, phone) VALUES (@name, @email, @phone)"
            Using cmd As New SqlCommand(strSql, conn)
                cmd.Parameters.AddWithValue("@name", organizer.name)
                cmd.Parameters.AddWithValue("@email", organizer.email)
                cmd.Parameters.AddWithValue("@phone", organizer.phone)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class

