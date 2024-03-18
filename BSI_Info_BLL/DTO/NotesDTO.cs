using System;
using System.Collections.Generic;
using System.Text;

namespace BSI_Info_BLL.DTO
{
    public class NotesDTO
    {
        public int note_id { get; set; }
        public int? event_id { get; set; }
        public string note_text { get; set; }
        public DateTime? created_at { get; set; }
    }
}
