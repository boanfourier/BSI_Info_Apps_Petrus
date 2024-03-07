Imports System.Data.SqlClient
Imports BSI_Info_Apps
Imports [Interface]

Public Class NotesDAL
    Implements INotes
    Private Const strConn As String = "Server=.\SQLEXPRESS02;Database=BSI_info;Trusted_Connection=True;"
    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader

    Public Sub New()
        conn = New SqlConnection(strConn)
    End Sub

    Public Function InsertNote(note As Notes) As Integer Implements INotes.InsertNote
        Dim query As String = "INSERT INTO Notes (event_id, note_text, created_at) " &
                              "VALUES (@event_id, @note_text, @created_at); " &
                              "SELECT SCOPE_IDENTITY();"

        Using connection As New SqlConnection(strConn)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@event_id", If(note.event_id.HasValue, CType(note.event_id, Object), DBNull.Value))
                command.Parameters.AddWithValue("@note_text", note.note_text)
                command.Parameters.AddWithValue("@created_at", If(note.created_at.HasValue, CType(note.created_at, Object), DBNull.Value))

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

    Public Function GetNoteById(noteId As Integer) As Notes Implements INotes.GetNoteById
        Dim query As String = "SELECT * FROM Notes WHERE note_id = @note_id"
        Dim noteItem As New Notes()

        Using connection As New SqlConnection(strConn)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@note_id", noteId)

                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            noteItem.note_id = Convert.ToInt32(reader("note_id"))
                            noteItem.event_id = If(reader("event_id") IsNot DBNull.Value, CType(reader("event_id"), Integer?), Nothing)
                            noteItem.note_text = Convert.ToString(reader("note_text"))
                            noteItem.created_at = If(reader("created_at") IsNot DBNull.Value, CType(reader("created_at"), DateTime?), Nothing)
                        End If
                    End Using
                Catch ex As Exception
                    ' Handle exception (e.g., log or rethrow)
                    Throw
                End Try
            End Using
        End Using

        Return noteItem
    End Function
End Class
