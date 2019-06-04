using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;

namespace DataManager
{

    /// <summary>
    /// Summary description for DALDesignationList
    /// </summary>
    public class DALDesignationList : DataUtilities
    {
        public DataSet GetDesignationList(EmpDesignation objEmpDesgList)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"@inDesignation_Id",objEmpDesgList.DesignationId},
                                                        {"@inDepartment_Id",objEmpDesgList.DepartmentId},
                                                        {"@inDesignation",objEmpDesgList.Designation},
                                                        {"@inDepartmentdesc",objEmpDesgList.Departmentdesc},
                                                        {"@inCompanyCode",objEmpDesgList.CompanyCode},
                                                        {"@inRoleId",objEmpDesgList.RoleId},
                                                        {"@inOp_Name",objEmpDesgList.Op_Name},
                                                        
                                                        
                                                   };
            return ExecuteDataSet("EmpDesignation", htparams);
        }
    }
}