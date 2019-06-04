using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmpEducation
/// </summary>
/// 
namespace EntityManager
{
    public class EmpEducation
    {

            public int Edu_Id { get; set; }
            public string Emp_Id { get; set; }
            public string Edu_Type { get; set; }
            public string Edu_Level { get; set; }
            public string Specialization { get; set; }
            public string YearOfPassing { get; set; }
            public string Percentage { get; set; }
            public string Category { get; set; }
            public string SchoolName { get; set; }
            public string BoardName { get; set; }
            public string OpName { get; set; }


            public int EduLevelId { get; set; }
            public string EduLevelName { get; set; }
            public string EduLevelDesc { get; set; }

            public string StartDate { get; set; }
            public string CompletedOn { get; set; }
        }
    }


