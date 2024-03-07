Imports System.Data.SqlClient
Imports BSI_Info_Apps
Imports [Interface]


Public Class EventsDAL
        Implements IEvents
        Private Const strConn As String = "Server=.\SQLEXPRESS02;Database=BSI_info;Trusted_Connection=True;"
        Private conn As SqlConnection
        Private cmd As SqlCommand
        Private dr As SqlDataReader

        Public Sub New()
            conn = New SqlConnection(strConn)
        End Sub

        Public Function InsertEvent(events As Events) As Integer Implements IEvents.InsertEvent
            Dim query As String = "INSERT INTO Events (event_name, description, start_date, end_date, location_id, organizer_id) " &
                                  "VALUES (@event_name, @description, @start_date, @end_date, @location_id, @organizer_id); " &
                                  "SELECT SCOPE_IDENTITY();"

            Using connection As New SqlConnection(strConn)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@event_name", events.event_name)
                    command.Parameters.AddWithValue("@description", events.description)
                    command.Parameters.AddWithValue("@start_date", If(events.start_date.HasValue, CType(events.start_date, Object), DBNull.Value))
                    command.Parameters.AddWithValue("@end_date", If(events.end_date.HasValue, CType(events.end_date, Object), DBNull.Value))
                    command.Parameters.AddWithValue("@location_id", If(events.location_id.HasValue, CType(events.location_id, Object), DBNull.Value))
                    command.Parameters.AddWithValue("@organizer_id", If(events.organizer_id.HasValue, CType(events.organizer_id, Object), DBNull.Value))

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

        Public Function GetEventById(eventId As Integer) As Events Implements IEvents.GetEventById
            Dim query As String = "SELECT * FROM Events WHERE event_id = @event_id"
            Dim eventItem As New Events()

            Using connection As New SqlConnection(strConn)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@event_id", eventId)

                    Try
                        connection.Open()
                        Using reader As SqlDataReader = command.ExecuteReader()
                            If reader.Read() Then
                                eventItem.event_id = Convert.ToInt32(reader("event_id"))
                                eventItem.event_name = Convert.ToString(reader("event_name"))
                                eventItem.description = Convert.ToString(reader("description"))
                                eventItem.start_date = If(reader("start_date") IsNot DBNull.Value, CType(reader("start_date"), DateTime?), Nothing)
                                eventItem.end_date = If(reader("end_date") IsNot DBNull.Value, CType(reader("end_date"), DateTime?), Nothing)
                                eventItem.location_id = If(reader("location_id") IsNot DBNull.Value, CType(reader("location_id"), Integer?), Nothing)
                                eventItem.organizer_id = If(reader("organizer_id") IsNot DBNull.Value, CType(reader("organizer_id"), Integer?), Nothing)
                            End If
                        End Using
                    Catch ex As Exception
                        ' Handle exception (e.g., log or rethrow)
                        Throw
                    End Try
                End Using
            End Using

            Return eventItem
        End Function
    End Class
