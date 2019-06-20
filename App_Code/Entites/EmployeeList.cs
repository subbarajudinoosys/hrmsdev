using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
using DataManager;

/// <summary>
/// Summary description for EmployeeList
/// </summary>
/// 
namespace DataManager
{
public class EmployeeList : DataUtilities
{
	 #region Local Variables
        #endregion


        #region Database Methods
        public DataSet GetEmpList(clsEmployee ObjEmpList)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"in_S_No",ObjEmpList.S_No},
                                                        {"in_emp_id",ObjEmpList.emp_id},
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
                                     
                                                   };
            return ExecuteDataSet("ManageEmployee", htparams);
        }
        }
        #endregion
}
