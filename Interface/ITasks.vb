Imports BSI_Info_Apps
Public Interface ITasks
    Function GetTasks() As List(Of Tasks)
    Sub InsertTask(task As Tasks)

End Interface