using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmpDesignation
/// </summary>
/// 
namespace EntityManager
{
    public class EmpDesignation
    {
        public int DesignationId { get; set; }
        public string DepartmentId { get; set; }
        public string Designation { get; set; }
        public string Departmentdesc { get; set; }
        public string CompanyCode { get; set; }

        public int  RoleId { get; set; }
        public string Op_Name { get; set; }
       
    }
}