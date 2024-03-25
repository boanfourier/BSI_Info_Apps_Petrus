using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_Info_APIService_Domain
{
    public class Events
    {
        [Key]
        [Column("event_id")]
        public int event_id { get; set; }

        [StringLength(255)]
        public string event_name { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }

        [Column("location_id")]
        public int? location_id { get; set; }

        [Column("organizer_id")]
        public int? organizer_id { get; set; }
    }
}
