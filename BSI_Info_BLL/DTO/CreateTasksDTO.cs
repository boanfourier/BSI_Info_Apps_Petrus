using System;
using System.Collections.Generic;
using System.Text;


public class CreateTasksDTO
    {
        public int task_id { get; set; }
        public int? event_id { get; set; }
        public string description { get; set; }
        public DateTime? deadline { get; set; }
        public string status { get; set; }
    }


