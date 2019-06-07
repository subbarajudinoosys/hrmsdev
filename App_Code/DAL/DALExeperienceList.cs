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
    /// Summary description for DALExeperienceList
    /// </summary>
    public class DALExeperienceList : DataUtilities

    {
        public DataSet GetEmpExperienceList(EmpExperience objEmpExeList)
        {
            Hashtable htparams = new Hashtable
                                                  {
                                                      {"inS_No",objEmpExeList.S_No},
                                                      {"inEmp_id",objEmpExeList.Emp_id},
                                                      {"inCompanyName",objEmpExeList.CompanyName},
                                                      {"inFromDate",objEmpExeList.FromDate},
                                                      {"inToDate",objEmpExeList.ToDate},
                                                      {"inDesignation",objEmpExeList.Designation},
                                                      {"inTechnology",objEmpExeList.Technology},
                                                      {"inProjectTitles",objEmpExeList.ProjectTitles},
                                                       {"inIsActive",objEmpExe.IsActive},
                                                      {"in_OpName",objEmpExeList.OpName},
                                                   };
            return ExecuteDataSet("EmpExperience", htparams);
        }
    }
}