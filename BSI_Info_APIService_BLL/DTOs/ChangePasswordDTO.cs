using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_Info_APIService_BLL.DTOs
{
    public class ChangePasswordDTO
    {
        public string Username { get; set; }
        public string NewPassword { get; set; }
    }
}
