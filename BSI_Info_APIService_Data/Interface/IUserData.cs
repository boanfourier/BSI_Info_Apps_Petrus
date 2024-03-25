using BSI_Info_APIService_Domain;


namespace BSI_Info_APIService_Data.Interface
{
    public interface IUserData
    {
        Task<IEnumerable<User>> GetAllWithRoles();
        Task<User> GetUserWithRoles(string username);
        Task<User> GetByUsername(string username);
        Task<User> Login(string username, string password);
        Task ChangePassword(string username, string newPassword);
    }
}
