using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsWorkShift
/// </summary>
/// 
namespace EntityManager
{
    public class clsWorkShift
    {
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public TimeSpan FromDate { get; set; }
        public TimeSpan ToDate { get; set; }
        public string Duration { get; set; }
        public string OpName { get; set; }
      
    }
}