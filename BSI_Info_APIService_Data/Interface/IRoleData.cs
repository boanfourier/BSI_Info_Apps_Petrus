
namespace BSI_Info_APIService_Data.Interface
{
    public interface IRoleData
    {
        Task<Task> AddUserToRole(string username, int roleId);
    }
}
