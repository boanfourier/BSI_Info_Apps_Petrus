using BSI_Info_APIService_Domain;

namespace BSI_Info_APIService_BLL.Interface
{
    public interface IUserBLL
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserByUsername(string username);
        Task<User> Login(string username, string password);
        Task<bool> ChangePassword(string username, string newPassword);
        Task<User> RegisterUser(User newUser);
        Task<User> GetUserWithRoles(string username);
    }
}
