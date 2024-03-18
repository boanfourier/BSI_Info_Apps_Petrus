
using System.Collections.Generic;

    public interface IRoleBLL
    {
        IEnumerable<RoleDTO> GetAllRoles();
        void AddRole(string roleName);
        void AddUserToRole(string username, int roleId);
    }

