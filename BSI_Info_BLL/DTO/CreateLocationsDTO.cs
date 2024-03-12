using System;
using System.Collections.Generic;
using System.Text;

public class CreateLocationsDTO
{
    public int location_id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public int? capacity { get; set; }
    public string description { get; set; }
}

