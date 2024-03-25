using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_Info_APIService_Domain
{
    public class Tasks
    {
        [Key]
        [Column("task_id")]
        public int task_id { get; set; }

        [Column("event_id")]
        public int event_id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime deadline { get; set; }

        [StringLength(50)]
        public string status { get; set; }
    }

}
