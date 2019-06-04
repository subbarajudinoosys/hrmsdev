using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PassportDetails
/// </summary>
/// 
namespace EntityManager
{
    public class PassportDetails
    {
        public int passportid { get; set; }

        public string EmployeeName { get; set; }
        public string PassportNumber { get; set; }
        public string PassportIssueDate { get; set; }
        public string PassportEXpiryDate { get; set; }

        public string Pannumber { get; set; }

        public string Adharnumber { get; set; }

        public string ImageUpload { get; set; }

        public string ImageFilePath { get; set; }

        public string OpName { get; set; }

        public int CreatedBy { get; set; }


    }

}