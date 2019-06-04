using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
using DataManager;

/// <summary>
/// Summary description for DALDepartment
/// </summary>
/// 
namespace DataManager
{
    public class DALDepartment : DataUtilities
    {
        public DataSet GetDepart(EmpDepartment objEmpDep)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"inDepartment_Id",objEmpDep.DepartmentId},
                                                        {"inDepartment",objEmpDep.Department},
                                                        {"inCompanyCode",objEmpDep.CompanyCode},
                                                        {"in_OpName",objEmpDep.OpName},
                                                        
                                                   };
            return ExecuteDataSet("EmpDepartment", htparams);
        }

        public int InsertEmpDep(EmpDepartment objEmpDep)
        {

            Hashtable htParams = new Hashtable
                                     {
                                                       {"inDepartment_Id",objEmpDep.DepartmentId},
                                                       {"inDepartment",objEmpDep.Department},
                                                       {"inCompanyCode",objEmpDep.CompanyCode},
                                                       {"in_OpName",objEmpDep.OpName},
                                                        
                                     };
            return ExecuteNonQuery("EmpDepartment", htParams);
        }

        public DataSet GetDepartDetails(EmpDepartment objEmpDep)
        {
            //Hashtable htparams = new Hashtable
            //                                       {
            //                                             {"inDepartment_Id",objEmpDep.DepartmentId},
            //                                             {"inDepartment",objEmpDep.Department},
                                                       
                                                        
                                                        
            //                                       };
            return ExecuteDataSet("get_Department");
        }

        public int DeleteDepDetails(int Department_Id)
        {
            Hashtable htparams = new Hashtable       
                                                   {
                                                        {"inDepartment_Id",Department_Id},

                                                   };
            return ExecuteNonQuery("EmpDepartment_Delete", htparams);
        }

    }

}