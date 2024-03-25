using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_Info_APIService_BLL.DTOs
{
    public class UserDTO
    {
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Telp { get; set; }

        public IEnumerable<RoleDTO>? Roles { get; set; }
    }
}
