using System;
using System.Collections.Generic;
using System.Text;

public class CreateEventsDTO
{
    public string event_name { get; set; }
    public string description { get; set; }
    public DateTime? start_date { get; set; }
    public DateTime? end_date { get; set; }
    public int? location_id { get; set; }
    public int? organizer_id { get; set; }

}

