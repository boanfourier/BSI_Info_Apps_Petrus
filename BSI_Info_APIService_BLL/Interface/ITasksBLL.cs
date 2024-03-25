using BSI_Info_APIService_BLL.DTOs;
using BSI_Info_APIService_Domain;


namespace BSI_Info_APIService_BLL.Interface
{
    public interface ITasksBLL
    {
        Task<IEnumerable<TasksDTO>> GetAllTasks();

        Task<TasksDTO> GetTasks(int task_id);

        Task<TasksDTO> AddTasks(TasksCreateDTO entity);

        Task<TasksDTO> UpdateTasks(int task_id, TasksUpdateDTO entity);

        Task<bool> DeleteTasks(int task_id);
    }
}
