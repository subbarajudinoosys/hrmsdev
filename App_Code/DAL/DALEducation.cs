using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;


/// <summary>
/// Summary description for DALEducation
/// </summary>
/// 
namespace DataManager
{
    public class DALEducation : DataUtilities
    {
       public DataSet GetEmpEducation(EmpEducation objEmpEdu)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"inEdu_Id",objEmpEdu.Edu_Id},
                                                        {"inEmp_Id",objEmpEdu.Emp_Id},
                                                        {"inEdu_Type",objEmpEdu.Edu_Type},
                                                        {"inEdu_Level",objEmpEdu.Edu_Level},
                                                        {"inSpecialization",objEmpEdu.Specialization},
                                                        {"inYearOfPassing",objEmpEdu.YearOfPassing},
                                                        {"inPercentage",objEmpEdu.Percentage},
                                                        {"inCategory",objEmpEdu.Category},
                                                        {"inSchoolName",objEmpEdu.SchoolName},
                                                        {"inBoardName",objEmpEdu.BoardName},
                                                        {"inStartDate",objEmpEdu.StartDate},
                                                        {"inCompletedOn",objEmpEdu.CompletedOn},
                                                        {"in_OpName",objEmpEdu.OpName},
                                                        
                                                        
                                                        
                                                   };
            return ExecuteDataSet("EmpEducation", htparams);
        }

        public int InsertEmpEducation(EmpEducation objEmpEdu)
       {
           Hashtable htparams = new Hashtable
                                                   {
                                                        {"inEdu_Id",objEmpEdu.Edu_Id},
                                                        {"inEmp_Id",objEmpEdu.Emp_Id},
                                                        {"inEdu_Type",objEmpEdu.Edu_Type},
                                                        {"inEdu_Level",objEmpEdu.Edu_Level},
                                                        {"inSpecialization",objEmpEdu.Specialization},
                                                        {"inYearOfPassing",objEmpEdu.YearOfPassing},
                                                        {"inPercentage",objEmpEdu.Percentage},
                                                        {"inCategory",objEmpEdu.Category},
                                                        {"inSchoolName",objEmpEdu.SchoolName},
                                                        {"inBoardName",objEmpEdu.BoardName},
                                                        {"inStartDate",objEmpEdu.StartDate},
                                                        {"inCompletedOn",objEmpEdu.CompletedOn},
                                                        {"in_OpName",objEmpEdu.OpName},                                                       
                                                                                                                
                                                   };
           return ExecuteNonQuery("EmpEducation", htparams);
       }

        public DataSet GetEduLevel(EmpEducation objEmpEdu)
        {
            Hashtable htparams = new Hashtable()
                                                  {
                                                      {"inEduLevel_Id",objEmpEdu.EduLevelId},
                                                      {"inEduLevel_Name",objEmpEdu.EduLevelName},
                                                      {"inEduLevel_Desc",objEmpEdu.EduLevelDesc},
                                                     
                                                  };
            return ExecuteDataSet("get_education",htparams);
        }
        public int DeleteEmpEducation(int Edu_Id)
        {
            Hashtable htParams = new Hashtable
                                     {
                                         {"inEdu_Id",Edu_Id},
                                     };
            return ExecuteNonQuery("EmpEducation_Delete", htParams);
        }
    }
}