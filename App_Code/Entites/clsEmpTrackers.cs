using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsEmpTrackers
/// </summary>
/// 
namespace EntityManager
{
    public class clsEmpTrackers
    {
        public int TrackerId { get; set; }
        public string TrackerName { get; set; }
        public string EmployeeName { get; set; }
        public string EmpId { get; set; }
        public string AssignedReviewers { get; set; }
        public string AvailableReviewers { get; set; }
        public string OpName { get; set; }
    }
}