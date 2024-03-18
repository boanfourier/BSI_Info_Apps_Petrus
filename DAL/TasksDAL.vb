Imports System.Data.SqlClient
Imports System.Threading
Imports BSI_Info_Apps

Public Class TasksDal
    Implements ITasks
    Private Const strConn As String = "Server=.\SQLEXPRESS02;Database=BSI_info;Trusted_Connection=True;"
    Private conn As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader

    Public Sub New()
        conn = New SqlConnection(strConn)
    End Sub

    Public Function GetTasks() As IEnumerable(Of Tasks) Implements ITasks.GetTasks
        Dim tasksList As New List(Of Tasks)

        Using connection As New SqlConnection(strConn)
            connection.Open()

            Dim query As String = "SELECT task_id, event_id, description, deadline, status FROM Tasks"
            Using command As New SqlCommand(query, connection)
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim task As New Tasks()
                        task.task_id = Convert.ToInt32(reader("task_id"))
                        task.event_id = Convert.ToInt32(reader("event_id"))
                        task.description = reader("description").ToString()
                        task.deadline = Convert.ToDateTime(reader("deadline"))
                        task.status = reader("status").ToString()

                        tasksList.Add(task)
                    End While
                End Using
            End Using
        End Using

        Return tasksList
    End Function

    Public Sub InsertTask(task As Tasks) Implements ITasks.InsertTask
        Using connection As New SqlConnection(strConn)
            connection.Open()

            Dim query As String = "INSERT INTO Tasks (event_id, description, deadline, status) VALUES (@event_id, @description, @deadline, @status)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@event_id", task.event_id)
                command.Parameters.AddWithValue("@description", task.description)
                command.Parameters.AddWithValue("@deadline", task.deadline)
                command.Parameters.AddWithValue("@status", task.status)

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Sub UpdateTask(task As Tasks) Implements ITasks.UpdateTask
        Using connection As New SqlConnection(strConn)
            connection.Open()

            Dim query As String = "UPDATE Tasks SET event_id = @event_id, description = @description, deadline = @deadline, status = @status WHERE task_id = @task_id"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@event_id", task.event_id)
                command.Parameters.AddWithValue("@description", task.description)
                command.Parameters.AddWithValue("@deadline", task.deadline)
                command.Parameters.AddWithValue("@status", task.status)
                command.Parameters.AddWithValue("@task_id", task.task_id)

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub DeleteTask(taskId As Integer) Implements ITasks.DeleteTask
        Using connection As New SqlConnection(strConn)
            connection.Open()

            Dim query As String = "DELETE FROM Tasks WHERE task_id = @task_id"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@task_id", taskId)

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Function GetTaskById(taskId As Integer) As Tasks Implements ITasks.GetTaskById
        Dim task As New Tasks()

        Using connection As New SqlConnection(strConn)
            connection.Open()

            Dim query As String = "SELECT task_id, event_id, description, deadline, status FROM Tasks WHERE task_id = @task_id"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@task_id", taskId)
                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        task.task_id = Convert.ToInt32(reader("task_id"))
                        task.event_id = Convert.ToInt32(reader("event_id"))
                        task.description = reader("description").ToString()
                        task.deadline = Convert.ToDateTime(reader("deadline"))
                        task.status = reader("status").ToString()
                    Else
                        ' Handle the case where task with the given ID is not found
                        Return Nothing
                    End If
                End Using
            End Using
        End Using

        Return task
    End Function
End Class


