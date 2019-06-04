using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsEmployee
/// </summary>
namespace EntityManager
{
    public class clsEmployee
    {
        public int S_No { get; set; }
        public string EmpID { get; set; }
        public string empFtName { get; set; }
        public string empMName { get; set; }
        public string empLName { get; set; }
        public string empDOB { get; set;  }
        public string empJOD { get; set;  }
        public string empMobile { get; set; }
        public string empEmail { get; set; }
        public string empManager { get; set; }
        public int empStatus { get; set; }
        public string empDesignation { get; set; }
        public string empDepartment { get; set; }
        public string LoginId { get; set; }
        public string empPWD { get; set; }
        public int CreatedBy { get; set; }
        public string OpName { get; set; }
        public string empPanNo { get; set; }
        public string empAdharNo { get; set; }
        public string empAddress { get; set; }
        public string emppassportno { get; set; }
        public string emppasexpirydate { get; set; }
        public string ResumeUpload { get; set; }
        public string ResumeFilePath { get; set; }
        public string emplocation { get; set; }
        public string ImageUpload { get; set; }
        public string ImageFilePath { get; set; }
    }
}
