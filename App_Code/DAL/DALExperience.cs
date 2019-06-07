using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityManager;
using System.Data;
using System.Collections;

namespace DataManager
{
    /// <summary>
    /// Summary description for DALExperience
    /// </summary>
    public class DALExperience : DataUtilities
    {
       
        #region Database Methods

        public DataSet GetEmpExperience(EmpExperience objEmpExe)
        {
            Hashtable htparams = new Hashtable
                                                  {
                                                      {"inS_No",objEmpExe.S_No},
                                                      {"inEmp_id",objEmpExe.Emp_id},
                                                      {"inCompanyName",objEmpExe.CompanyName},
                                                      {"inFromDate",objEmpExe.FromDate},
                                                      {"inToDate",objEmpExe.ToDate},
                                                      {"inDesignation",objEmpExe.Designation},
                                                      {"inTechnology",objEmpExe.Technology},
                                                      {"inProjectTitles",objEmpExe.ProjectTitles},
                                                      {"inIsActive",objEmpExe.IsActive},
                                                      {"in_OpName",objEmpExe.OpName},
                                                   };
             return ExecuteDataSet("EmpExperience",htparams);
        }


        public int InsertEmpExperience(EmpExperience objEmpExe)
        {
            Hashtable htparams = new Hashtable
                                                  {
                                                     {"inS_No",objEmpExe.S_No},
                                                      {"inEmp_id",objEmpExe.Emp_id},
                                                      {"inCompanyName",objEmpExe.CompanyName},
                                                      {"inFromDate",objEmpExe.FromDate},
                                                      {"inToDate",objEmpExe.ToDate},
                                                      {"inDesignation",objEmpExe.Designation},
                                                      {"inTechnology",objEmpExe.Technology},
                                                      {"inProjectTitles",objEmpExe.ProjectTitles},
                                                       {"inIsActive",objEmpExe.IsActive},
                                                      {"in_OpName",objEmpExe.OpName},
                                                   };
            return ExecuteNonQuery("EmpExperience", htparams);
        }


        public int DeleteEmpExp(int S_No, string Emp_id)
        {
            Hashtable htparams = new Hashtable
                                                  {
                                                      {"inS_No",S_No},
                                                      {"inEmp_id",Emp_id},
                                                      
                                                   };
            return ExecuteNonQuery("delete_Experience", htparams);
        }
        #endregion Database Methods
    }
}