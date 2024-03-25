using BSI_Info_APIService_BLL.DTOs;


namespace BSI_Info_APIService_BLL.Interface
{
    public interface IRoleBLL
    {
        Task<IEnumerable<RoleDTO>> GetAllRoles();
        Task<Task> AddRole(string roleName);
        Task<Task> AddUserToRole(string username, int roleId);
    }
}
