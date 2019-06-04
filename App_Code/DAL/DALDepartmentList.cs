using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;


/// <summary>
/// Summary description for DALDepartmentList
/// </summary>

namespace DataManager
{

    public class DALDepartmentList : DataUtilities
    {
        public DataSet GetDepartList(EmpDepartment objEmpDepList)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"inDepartment_Id",objEmpDepList.DepartmentId},
                                                        {"inDepartment",objEmpDepList.Department},
                                                        {"inCompanyCode",objEmpDepList.CompanyCode},
                                                        {"in_OpName",objEmpDepList.OpName},
                                                        
                                                   };
            return ExecuteDataSet("EmpDepartment", htparams);
        }
    }
}