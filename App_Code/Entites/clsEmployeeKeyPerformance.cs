using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsEmployeeKeyPerformance
/// </summary>
namespace EntityManager
{ 
public class clsEmployeeKeyPerformance
{
    public int ekp_id { set; get; }
    public string ekp_job_title { set; get; }
    public string ekp_min_rating { set; get; }
    public string ekp_max_rating { set; get; }
    public int ekp_default_scale { set; get; }
    public string ekp_key_performance_indicator { set; get; }
    public string OpName { get; set; }
}
}