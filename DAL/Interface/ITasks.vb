Imports BSI_Info_Apps
Public Interface ITasks
    Function GetTasks() As IEnumerable(Of Tasks)
    Sub InsertTask(task As Tasks)

End Interface