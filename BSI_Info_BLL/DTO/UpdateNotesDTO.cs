using System;
using System.Collections.Generic;
using System.Text;


    public class UpdateNotesDTO
    {
        public int note_id { get; set; }
        public int? event_id { get; set; }
        public string note_text { get; set; }
        public DateTime? created_at { get; set; }
    }

