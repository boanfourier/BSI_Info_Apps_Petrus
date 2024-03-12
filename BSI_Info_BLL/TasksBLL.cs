using BSI_Info_Apps;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

public class TasksBLL : ITasksBLL
{
    private readonly ITasks _tasksDAL;
    public TasksBLL()
    {
        _tasksDAL = new TasksDal();
    }

    void ITasksBLL.AddTask(CreateTasksDTO createTasks)
    {
        try
        {
            var tasks = new Tasks
            {
                task_id = createTasks.task_id,
                event_id = (int)createTasks.event_id,
                description = createTasks.description,
                deadline = (DateTime)createTasks.deadline,
                status = createTasks.status,
            };

            if (createTasks != null)
            {
                _tasksDAL.InsertTask(tasks);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }

    }

    void ITasksBLL.DeleteTask(int taskId)
    {
        throw new NotImplementedException();
    }

    IEnumerable<TasksDTO> ITasksBLL.GetTasks()
    {
        try
        {
            var tasks = _tasksDAL.GetTasks();
            var tasksDTOs = new List<TasksDTO>();

            foreach (var tasksObj in tasks)
            {
                var tasksdto = new TasksDTO
                {
                    task_id = tasksObj.task_id,
                    event_id = tasksObj.event_id,
                    description = tasksObj.description,
                    deadline = tasksObj.deadline,
                    status = tasksObj.status,

                };

                tasksDTOs.Add(tasksdto);
            }

            return tasksDTOs;
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }

    }

    TasksDTO ITasksBLL.GetTaskById(int taskId)
    {
        throw new NotImplementedException();
    }

    void ITasksBLL.UpdateTask(TasksDTO task)
    {
        throw new NotImplementedException();
    }
}
