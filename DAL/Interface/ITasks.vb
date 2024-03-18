Imports BSI_Info_Apps
Public Interface ITasks
    Function GetTasks() As IEnumerable(Of Tasks)
    Function GetTaskById(taskId As Integer) As Tasks
    Sub InsertTask(task As Tasks)
    Sub UpdateTask(task As Tasks)
    Sub DeleteTask(taskId As Integer)

End Interface