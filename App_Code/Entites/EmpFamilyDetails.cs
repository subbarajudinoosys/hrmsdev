using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmpFamilyDetails
/// </summary>
/// 
namespace EntityManager
{
    public class EmpFamilyDetails
    {
        public int S_No { get; set; }
        public string Emp_id { get; set; }
        public string Relationship { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Age { get; set; }
        public string Employmentstatus { get; set; }
        public string IsActive { get; set; }
        public string OpName { get; set; }
    }
}