using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_Info_APIService_BLL.DTOs
{
    public class TasksCreateDTO
    {
        public int? event_id { get; set; }
        public string description { get; set; }
        public DateTime? deadline { get; set; }
        public string status { get; set; }
    }
}
