using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
using DataManager;

/// <summary>
/// Summary description for DALDesignation
/// </summary>
/// 
namespace DataManager
{
    public class DALDesignation : DataUtilities
    {
        public DataSet GetDesignation(EmpDesignation objEmpDesg)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"inDesignation_Id",objEmpDesg.DesignationId},
                                                        {"inDepartment_Id",objEmpDesg.DepartmentId},
                                                        {"inDesignation",objEmpDesg.Designation},
                                                        {"inDepartmentdesc",objEmpDesg.Departmentdesc},
                                                        {"inCompanyCode",objEmpDesg.CompanyCode},
                                                        {"inRoleId",objEmpDesg.RoleId},
                                                        {"inOp_Name",objEmpDesg.Op_Name},
                                                        
                                                   };
            return ExecuteDataSet("EmpDesignation", htparams);
        }

        public int InsertEmpDesg(EmpDesignation objEmpDesg)
        {

            Hashtable htParams = new Hashtable
                                     {
                                            {"inDesignation_Id",objEmpDesg.DesignationId},
                                            {"inDepartment_Id",objEmpDesg.DepartmentId},
                                            {"inDesignation",objEmpDesg.Designation},
                                            {"inDepartmentdesc",objEmpDesg.Departmentdesc},
                                            {"inCompanyCode",objEmpDesg.CompanyCode},
                                            {"inRoleId",objEmpDesg.RoleId},
                                            {"inOp_Name",objEmpDesg.Op_Name},
                                                       
                                     };
            return ExecuteNonQuery("EmpDesignation", htParams);
        }


        public int DeleteDesigDetails(int DesigId)
        {
            Hashtable htparams = new Hashtable()
                                               {
                                                          {"inDesignation_Id",DesigId},
                                                };
            return ExecuteNonQuery("EmpDesignation_Delete", htparams);
        }

        public DataSet GetDesigDetails(EmpDesignation objEmpDesg)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"inDesignation_Id",objEmpDesg.DesignationId},
                                                        {"inDepartment_Id",objEmpDesg.DepartmentId},
                                                        
                                                        
                                                        
                                                   };
            return ExecuteDataSet("get_Designation", htparams);
        }

        public DataSet GetDesignationByDes(EmpDesignation objEmpDesg)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"inDesignation_Id",objEmpDesg.DesignationId},
                                                        {"inDesignation",objEmpDesg.Designation},
                                                        
                                                        
                                                        
                                                   };
            return ExecuteDataSet("get_JobTitle", htparams);
        }



    }
}