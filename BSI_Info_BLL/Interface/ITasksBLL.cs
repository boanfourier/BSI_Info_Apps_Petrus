using BSI_Info_BLL.DTO;
using System;
using System.Collections.Generic;

public interface ITasksBLL
{
    IEnumerable<TasksDTO> GetTasks();
    TasksDTO GetTaskById(int taskId);
    void AddTask(CreateTasksDTO newTask);
    void UpdateTask(UpdateTasksDTO updatetask);
    void DeleteTask(int taskId);
}
