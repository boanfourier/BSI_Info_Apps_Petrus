using BSI_Info_Apps;
using BSI_Info_BLL.DTO;
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
        _tasksDAL.DeleteTask(taskId);
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
        try
        {
            var tasks = _tasksDAL.GetTaskById(taskId);
            var taskdto = new TasksDTO
            {
                task_id = tasks.task_id,
                event_id = tasks.event_id,
                description = tasks.description,
                deadline = tasks.deadline,
                status = tasks.status,

            };

            return taskdto;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
    }

    void ITasksBLL.UpdateTask(UpdateTasksDTO updatetask)
    {
        try
        {
            var tasks = new Tasks
            {
                task_id = updatetask.task_id,
                event_id = (int)updatetask.event_id,
                description = updatetask.description,
                deadline = (DateTime)updatetask.deadline,
                status = updatetask.status,
               
            };

            if (updatetask != null)
            {
                _tasksDAL.UpdateTask(tasks);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
    }
}
