using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
/// <summary>
/// Summary description for DALEducationList
/// </summary>
/// 
namespace DataManager
{
    public class DALEducationList : DataUtilities
    {
        public DataSet GetEmpEducationList(EmpEducation objEmpEduList)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"inEdu_Id",objEmpEduList.Edu_Id},
                                                        {"inEmp_Id",objEmpEduList.Emp_Id},
                                                        {"inEdu_Type",objEmpEduList.Edu_Type},
                                                        {"inEdu_Level",objEmpEduList.Edu_Level},
                                                        {"inSpecialization",objEmpEduList.Specialization},
                                                        {"inYearOfPassing",objEmpEduList.YearOfPassing},
                                                        {"inPercentage",objEmpEduList.Percentage},
                                                        {"inCategory",objEmpEduList.Category},
                                                        {"inSchoolName",objEmpEduList.SchoolName},
                                                        {"inBoardName",objEmpEduList.BoardName},
                                                        {"inStartDate",objEmpEduList.StartDate},
                                                        {"inCompletedOn",objEmpEduList.CompletedOn},
                                                        {"in_OpName",objEmpEduList.OpName},
                                                        
                                                        
                                                        
                                                   };
            return ExecuteDataSet("EmpEducation", htparams);
        }
    }
}