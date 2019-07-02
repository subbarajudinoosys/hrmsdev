using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

using EntityManager;
/// <summary>
/// Summary description for Employees
/// </summary>
namespace DataManager
{
    public class Employees : DataUtilities
    {

        #region Local Variables


        #endregion

        #region Database Methods

        #region Employee
        public DataSet GetEmployeeDetails(clsEmployee objclsemp)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"in_S_No",objclsemp.S_No},
                                                        {"in_emp_id",objclsemp.EmpID},
                                                        {"in_emp_firstname",objclsemp.empFtName},
                                                        {"in_emp_middlename",objclsemp.empMName},
                                                        {"in_emp_lastname",objclsemp.empLName},
                                                        {"in_emp_doj",objclsemp.empJOD},
                                                        {"in_emp_dob",objclsemp.empDOB},
                                                        {"in_emp_dept",objclsemp.empDepartment},
                                                        {"in_emp_design",objclsemp.empDesignation},
                                                        {"in_emp_login",objclsemp.LoginId},
                                                        {"in_emp_pwd",objclsemp.empPWD},
                                                        {"in_emp_mobile",objclsemp.empMobile},
                                                        {"in_emp_email",objclsemp.empEmail},
                                                        {"in_emp_mgr",objclsemp.empManager},
                                                        {"in_CreatedBy",objclsemp.CreatedBy},
                                                        {"in_OpName",objclsemp.OpName},
                                                        {"in_emp_status",objclsemp.empStatus},
                                                        {"in_emp_panno",objclsemp.empPanNo},
                                                        {"in_emp_adharno",objclsemp.empAdharNo},
                                                        {"in_emp_address",objclsemp.empAddress},
                                                        {"in_emp_passportno",objclsemp.emppassportno},
                                                        {"in_emp_pasexpirydate",objclsemp.emppasexpirydate},
                                                        {"in_ResumeUpload",objclsemp.ResumeUpload},
                                                        {"in_ResumeFilePath",objclsemp.ResumeFilePath},
                                                        {"in_emp_location",objclsemp.emplocation},
                                                         {"in_ImageUpload",objclsemp.ImageUpload},
                                                        {"in_ImageFilePath",objclsemp.ImageFilePath},
                                                   };
            return ExecuteDataSet("ManageEmployee", htparams);
        }

        public int Employee_InsertUpdate(clsEmployee objclsemp)
        {
            Hashtable htparams = new Hashtable{
                                                        {"in_S_No",objclsemp.S_No},
                                                        {"in_emp_id",objclsemp.EmpID},
                                                        {"in_emp_firstname",objclsemp.empFtName},
                                                        {"in_emp_middlename",objclsemp.empMName},
                                                        {"in_emp_lastname",objclsemp.empLName},
                                                        {"in_emp_doj",objclsemp.empJOD},
                                                        {"in_emp_dob",objclsemp.empDOB},
                                                        {"in_emp_dept",objclsemp.empDepartment},
                                                        {"in_emp_design",objclsemp.empDesignation},
                                                        {"in_emp_login",objclsemp.LoginId},
                                                        {"in_emp_pwd",objclsemp.empPWD},
                                                        {"in_emp_mobile",objclsemp.empMobile},
                                                        {"in_emp_email",objclsemp.empEmail},
                                                        {"in_emp_mgr",objclsemp.empManager},
                                                        {"in_CreatedBy",objclsemp.CreatedBy},
                                                        {"in_OpName",objclsemp.OpName},
                                                        {"in_emp_status",objclsemp.empStatus},
                                                        {"in_emp_panno",objclsemp.empPanNo},
                                                        {"in_emp_adharno",objclsemp.empAdharNo},
                                                        {"in_emp_address",objclsemp.empAddress},
                                                        {"in_emp_passportno",objclsemp.emppassportno},
                                                        {"in_emp_pasexpirydate",objclsemp.emppasexpirydate},
                                                        {"in_ResumeUpload",objclsemp.ResumeUpload},
                                                        {"in_ResumeFilePath",objclsemp.ResumeFilePath},
                                                        {"in_emp_location",objclsemp.emplocation},
                                                        {"in_ImageUpload",objclsemp.ImageUpload},
                                                        {"in_ImageFilePath",objclsemp.ImageFilePath},
                                                   };
            int IsSucess = ExecuteNonQuery("ManageEmployee", htparams);
            return IsSucess;
        }





        public DataSet GetHiringManager(clsEmployee objclsemp)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"@in_emp_id",objclsemp.EmpID},                                                      
                                                        {"@in_emp_firstname",objclsemp.empFtName},                                                      
                                                        {"@in_emp_lastname",objclsemp.empLName},
                                                   };
            return ExecuteDataSet("get_HiringManager", htparams);

        }

        public DataSet GetEmpByDesignation(clsEmployee objclsemp)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"@in_emp_id",objclsemp.emp_id},                                                      
                                                        {"in_emp_firstname",objclsemp.empFtName},                                                       
                                                        {"in_emp_lastname",objclsemp.empLName},
                                                        
                                                   };
            return ExecuteDataSet("get_employee_ByDesignation", htparams);

        }

        public DataSet GetEmpList(clsEmployee ObjEmpList)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"in_S_No",ObjEmpList.S_No},
                                                        {"in_emp_id",ObjEmpList.EmpID},
                                                        {"in_emp_firstname",ObjEmpList.empFtName},
                                                        {"in_emp_middlename",ObjEmpList.empMName},
                                                        {"in_emp_lastname",ObjEmpList.empLName},
                                                        {"in_emp_doj",ObjEmpList.empJOD},
                                                        {"in_emp_dob",ObjEmpList.empDOB},
                                                        {"in_emp_dept",ObjEmpList.empDepartment},
                                                        {"in_emp_design",ObjEmpList.empDesignation},
                                                        {"in_emp_login",ObjEmpList.LoginId},
                                                        {"in_emp_pwd",ObjEmpList.empPWD},
                                                        {"in_emp_mobile",ObjEmpList.empMobile},
                                                        {"in_emp_email",ObjEmpList.empEmail},
                                                        {"in_emp_mgr",ObjEmpList.empManager},
                                                        {"in_CreatedBy",ObjEmpList.CreatedBy},
                                                        {"in_OpName",ObjEmpList.OpName},
                                                        {"in_emp_status",ObjEmpList.empStatus},
                                                        {"in_emp_panno",ObjEmpList.empPanNo},
                                                        {"in_emp_adharno",ObjEmpList.empAdharNo},
                                                        {"in_emp_address",ObjEmpList.empAddress},
                                                        {"in_emp_passportno",ObjEmpList.emppassportno},
                                                        {"in_emp_pasexpirydate",ObjEmpList.emppasexpirydate},
                                                        {"in_ResumeUpload",ObjEmpList.ResumeUpload},
                                                        {"in_ResumeFilePath",ObjEmpList.ResumeFilePath},
                                                        {"in_emp_location",ObjEmpList.emplocation},
                                                        {"in_ImageUpload",ObjEmpList.ImageUpload},
                                                        {"in_ImageFilePath",ObjEmpList.ImageFilePath},
                                                        //{"in_ImageUpload",ObjEmpList.ImageUpload},
                                                        //{"in_ImageFilePath",ObjEmpList.ImageFilePath},

                                     
                                                   };
            return ExecuteDataSet("ManageEmployee", htparams);
        }
        #endregion Employee
    }
        #endregion
}

