using System;
using System.Collections.Generic;

public interface ITasksBLL
{
    IEnumerable<TasksDTO> GetTasks();
    TasksDTO GetTaskById(int taskId);
    void AddTask(CreateTasksDTO newTask);
    void UpdateTask(TasksDTO task);
    void DeleteTask(int taskId);
}
