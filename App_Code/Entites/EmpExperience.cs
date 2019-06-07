using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{


    /// <summary>
    /// Summary description for EmpExperience
    /// </summary>
    public class EmpExperience
    {
        public int S_No { get; set; }
        public string Emp_id { get; set; }
        public string CompanyName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Designation { get; set; }
        public string Technology { get; set; }
        public string ProjectTitles { get; set; }
        public string IsActive { get; set; }
        public string OpName { get; set; }
    }
}