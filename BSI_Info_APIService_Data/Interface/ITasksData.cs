using BSI_Info_APIService_Domain;

namespace BSI_Info_APIService_Data.Interface
{
    public interface ITasksData : ICrudData<Tasks>
    {
        Task<int> InsertWithIdentity(Tasks tasks);

    }
}
