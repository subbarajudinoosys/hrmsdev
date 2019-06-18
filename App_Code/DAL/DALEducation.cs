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
                                                        {"@inS_No",objEmpEdu.S_No},
                                                        {"@inemp_id",objEmpEdu.emp_id},
                                                        {"@inEdu_Type",objEmpEdu.Edu_Type},
                                                        {"@inEdu_Level",objEmpEdu.Edu_Level},
                                                        {"@inSpecialization",objEmpEdu.Specialization},
                                                        {"@inYearOfPassing",objEmpEdu.YearOfPassing},
                                                        {"@inPercentage",objEmpEdu.Percentage},
                                                        {"@inCategory",objEmpEdu.Category},
                                                        {"@inSchoolName",objEmpEdu.SchoolName},
                                                        {"@inBoardName",objEmpEdu.BoardName},
                                                        {"@inStartDate",objEmpEdu.StartDate},
                                                        {"@inEndDate",objEmpEdu.EndDate},
                                                        {"@in_OpName",objEmpEdu.OpName},
                                                        
                                                        
                                                        
                                                   };
            return ExecuteDataSet("EmpEducation", htparams);
        }

        public int InsertEmpEducation(EmpEducation objEmpEdu)
       {
           Hashtable htparams = new Hashtable
                                                   {
                                                        {"@inS_No",objEmpEdu.S_No},
                                                        {"@inemp_id",objEmpEdu.emp_id},
                                                        {"@inEdu_Type",objEmpEdu.Edu_Type},
                                                        {"@inEdu_Level",objEmpEdu.Edu_Level},
                                                        {"@inSpecialization",objEmpEdu.Specialization},
                                                        {"@inYearOfPassing",objEmpEdu.YearOfPassing},
                                                        {"@inPercentage",objEmpEdu.Percentage},
                                                        {"@inCategory",objEmpEdu.Category},
                                                        {"@inSchoolName",objEmpEdu.SchoolName},
                                                        {"@inBoardName",objEmpEdu.BoardName},
                                                        {"@inStartDate",objEmpEdu.StartDate},
                                                        {"@inEndDate",objEmpEdu.EndDate},
                                                        {"@in_OpName",objEmpEdu.OpName},                                                       
                                                                                                                
                                                   };
           return ExecuteNonQuery("EmpEducation", htparams);
       }

        public DataSet GetEduLevel(EmpEducation objEmpEdu)
        {
            Hashtable htparams = new Hashtable()
                                                  {
                                                      {"@inEduLevel_Id",objEmpEdu.EduLevelId},
                                                      {"@inEduLevel_Name",objEmpEdu.EduLevelName},
                                                      {"@inEduType_Id",objEmpEdu.EduType_Id},
                                                     
                                                  };
            return ExecuteDataSet("get_education",htparams);
        }
        public int DeleteEmpEducation(int S_No)
        {
            Hashtable htParams = new Hashtable
                                     {
                                         {"@inS_No",S_No},
                                     };
            return ExecuteNonQuery("EmpEducation_Delete", htParams);
        }
        //public DataSet GetLevelType(EmpEducation objEmpEdu)
        //{
        //    Hashtable htparams = new Hashtable
        //    {
        //                                     {"@inEduLevel_Id",objEmpEdu.EduLevelId},
        //    //                                          {"@inEduLevel_Name",objEmpEdu.EduLevelName},
        //    //                                          {"@inEduType_Id",objEmpEdu.EduType_Id},
        //    };
        //    return ExecuteDataSet("Education_Levelbytype", htparams);
        //}
    }
}