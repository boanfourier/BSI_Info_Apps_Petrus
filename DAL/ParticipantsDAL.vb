Imports System.Data
Imports System.Data.SqlClient
Imports BSI_Info_Apps
Imports [Interface]
Public Class SqlParticipantRepository
    Implements IParticipants
    Private Const strConn As String = "Server=.\SQLEXPRESS02;Database=BSI_info;Trusted_Connection=True;"
    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader
    Public Sub New()
        conn = New SqlConnection(strConn)
    End Sub

    Public Sub AddParticipant(participant As Participants) Implements IParticipants.AddParticipant
        Using connection As New SqlConnection(strConn)
            Using command As New SqlCommand("AddParticipant", connection)
                command.CommandType = CommandType.StoredProcedure

                ' Add parameters
                command.Parameters.AddWithValue("@name", participant.name)
                command.Parameters.AddWithValue("@email", participant.email)
                command.Parameters.AddWithValue("@phone", participant.phone)
                command.Parameters.AddWithValue("@password", participant.password)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                Catch ex As Exception
                    ' Handle exceptions
                    Throw New Exception("Error adding participant: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Function GetParticipants() As List(Of Participants) Implements IParticipants.GetParticipants
        Dim participants As New List(Of Participants)

        Using connection As New SqlConnection(strConn)
            Using command As New SqlCommand("SELECT * FROM Participants", connection)
                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim participant As New Participants()
                            participant.participant_id = Convert.ToInt32(reader("participant_id"))
                            participant.name = Convert.ToString(reader("name"))
                            participant.email = Convert.ToString(reader("email"))
                            participant.phone = Convert.ToString(reader("phone"))
                            participant.password = Convert.ToString(reader("password"))

                            participants.Add(participant)
                        End While
                    End Using
                Catch ex As Exception
                    ' Handle exceptions
                    Throw New Exception("Error getting participants: " & ex.Message)
                End Try
            End Using
        End Using
        Return participants
    End Function
End Class
