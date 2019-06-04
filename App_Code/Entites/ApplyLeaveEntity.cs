using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    public class ApplyLeaveEntity
    {
        public int leave_id { get; set; }
        public int emp_id { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public string reason { get; set; }
        public string no_of_days { get; set; }
        public string leave_type { get; set; }
        public string calender_year { get; set; }
        public string CreatedBy { get; set; }
    }
}