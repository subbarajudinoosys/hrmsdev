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
                                                        {"@inS_No",objEmpEduList.S_No},
                                                        {"@inemp_id",objEmpEduList.emp_id},
                                                        {"@inEdu_Type",objEmpEduList.Edu_Type},
                                                        {"@inEdu_Level",objEmpEduList.Edu_Level},
                                                        {"@inSpecialization",objEmpEduList.Specialization},
                                                        //{"@inYearOfPassing",objEmpEduList.YearOfPassing},
                                                        //{"@inPercentage",objEmpEduList.Percentage},
                                                        //{"@inCategory",objEmpEduList.Category},
                                                        //{"@inSchoolName",objEmpEduList.SchoolName},
                                                        //{"@inBoardName",objEmpEduList.BoardName},
                                                        {"@inStartDate",objEmpEduList.StartDate},
                                                        {"@inEndDate",objEmpEduList.EndDate},
                                                        {"@in_OpName",objEmpEduList.OpName},
                                                        
                                                        
                                                        
                                                   };
            return ExecuteDataSet("EmpEducation", htparams);
        }
    }
}