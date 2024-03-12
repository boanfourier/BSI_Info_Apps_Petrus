Imports System.Data.SqlClient
Imports BSI_Info_Apps

Public Class Event_ParticipantsDAL
    Implements IEvent_Participants
    Private Const strConn As String = "Server=.\SQLEXPRESS02;Database=BSI_info;Trusted_Connection=True;"

    Public Function InsertEventParticipant(eventParticipant As Event_Participants) As Integer Implements IEvent_Participants.InsertEventParticipant
        Dim query As String = "INSERT INTO Event_Participants (event_id, participant_id, registration_date) VALUES (@event_id, @participant_id, @registration_date); SELECT SCOPE_IDENTITY();"

        Using connection As New SqlConnection(strConn)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@event_id", eventParticipant.event_id)
                command.Parameters.AddWithValue("@participant_id", eventParticipant.participant_id)
                command.Parameters.AddWithValue("@registration_date", If(eventParticipant.registration_date.HasValue, CType(eventParticipant.registration_date, Object), DBNull.Value))

                Try
                    connection.Open()
                    Return Convert.ToInt32(command.ExecuteScalar())
                Catch ex As Exception
                    ' Handle exception (e.g., log or rethrow)
                    Throw
                End Try
            End Using
        End Using
    End Function

    Public Function GetEventParticipantById(eventParticipantId As Integer) As Event_Participants Implements IEvent_Participants.GetEventParticipantById
        Dim query As String = "SELECT * FROM Event_Participants WHERE ID = @ID"
        Dim eventParticipant As New Event_Participants()

        Using connection As New SqlConnection(strConn)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ID", eventParticipantId)

                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            eventParticipant.event_id = Convert.ToInt32(reader("event_id"))
                            eventParticipant.participant_id = Convert.ToInt32(reader("participant_id"))
                            eventParticipant.registration_date = If(reader("registration_date") IsNot DBNull.Value, CType(reader("registration_date"), DateTime?), Nothing)
                        End If
                    End Using
                Catch ex As Exception
                    ' Handle exception (e.g., log or rethrow)
                    Throw
                End Try
            End Using
        End Using

        Return eventParticipant
    End Function
End Class
