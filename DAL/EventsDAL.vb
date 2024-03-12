Imports System.Data.SqlClient
Imports BSI_Info_Apps



Public Class EventsDAL
    Implements IEvents
    Private Const strConn As String = "Server=.\SQLEXPRESS02;Database=BSI_info;Trusted_Connection=True;"
    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader

    Public Sub New()
        conn = New SqlConnection(strConn)
    End Sub

    Public Sub InsertEvent(events As Events) Implements IEvents.InsertEvent
        Dim query As String = "INSERT INTO Events (event_name, description, start_date, end_date, location_id, organizer_id) " &
                              "VALUES (@event_name, @description, @start_date, @end_date, @location_id, @organizer_id);"

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
                    command.ExecuteNonQuery() ' Eksekusi perintah SQL untuk menambahkan data
                Catch ex As Exception
                    ' Handle exception (e.g., log or rethrow)
                    Throw
                End Try
            End Using
        End Using
    End Sub


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

    Public Function GetAllEvents() As IEnumerable(Of Events) Implements IEvents.GetAllEvents
        Dim eventsList As New List(Of Events)
        Dim query As String = "SELECT * FROM Events"

        Using connection As New SqlConnection(strConn)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim eventItem As New Events()
                            eventItem.event_id = Convert.ToInt32(reader("event_id"))
                            eventItem.event_name = Convert.ToString(reader("event_name"))
                            eventItem.description = Convert.ToString(reader("description"))
                            eventItem.start_date = If(reader("start_date") IsNot DBNull.Value, CType(reader("start_date"), DateTime?), Nothing)
                            eventItem.end_date = If(reader("end_date") IsNot DBNull.Value, CType(reader("end_date"), DateTime?), Nothing)
                            eventItem.location_id = If(reader("location_id") IsNot DBNull.Value, CType(reader("location_id"), Integer?), Nothing)
                            eventItem.organizer_id = If(reader("organizer_id") IsNot DBNull.Value, CType(reader("organizer_id"), Integer?), Nothing)
                            eventsList.Add(eventItem)
                        End While
                    End Using
                Catch ex As Exception
                    ' Handle exception (e.g., log or rethrow)
                    Throw
                End Try
            End Using
        End Using

        Return eventsList
    End Function
    Public Sub DeleteEvent(eventId As Integer) Implements IEvents.DeleteEvent
        Dim query As String = "DELETE FROM Events WHERE event_id = @event_id"

        Using connection As New SqlConnection(strConn)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@event_id", eventId)

                Try
                    connection.Open()
                    command.ExecuteNonQuery() ' Eksekusi perintah SQL untuk menghapus data
                Catch ex As Exception
                    ' Handle exception (e.g., log or rethrow)
                    Throw
                End Try
            End Using
        End Using
    End Sub
    Public Sub UpdateEvent(events As Events) Implements IEvents.UpdateEvent
        Dim query As String = "EXEC [dbo].[UpdateEvent] " &
                             "@event_id, @event_name, @description, @start_date, @end_date, @location_id, @organizer_id"

        Using connection As New SqlConnection(strConn)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@event_id", events.event_id)
                command.Parameters.AddWithValue("@event_name", events.event_name)
                command.Parameters.AddWithValue("@description", events.description)
                command.Parameters.AddWithValue("@start_date", If(events.start_date.HasValue, CType(events.start_date, Object), DBNull.Value))
                command.Parameters.AddWithValue("@end_date", If(events.end_date.HasValue, CType(events.end_date, Object), DBNull.Value))
                command.Parameters.AddWithValue("@location_id", If(events.location_id.HasValue, CType(events.location_id, Object), DBNull.Value))
                command.Parameters.AddWithValue("@organizer_id", If(events.organizer_id.HasValue, CType(events.organizer_id, Object), DBNull.Value))

                Try
                    connection.Open()
                    command.ExecuteNonQuery() ' Execute the SQL command to update the data
                Catch ex As Exception
                    ' Handle exception (e.g., log or rethrow)
                    Throw
                End Try
            End Using
        End Using
    End Sub


End Class
