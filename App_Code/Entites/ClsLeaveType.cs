using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsLeaveType
/// </summary>
/// 
namespace EntityManager
{
    public class ClsLeaveType
    {
        public int LeaveTypeId { get; set; }
        public string LeaveType { get; set; }
        public string TotalLeaves { get; set; }
        public string OpName { get; set; }
        
    }
}