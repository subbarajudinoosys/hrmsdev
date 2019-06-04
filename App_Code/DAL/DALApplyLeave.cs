using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;

/// <summary>
/// Summary description for DALApplyLeave
/// </summary>
namespace DataManager
{
    public class DALApplyLeave:DataUtilities
    {
        public DataSet Get_Leaves_By_Emp(int emp_id)
        {
            Hashtable hst = new Hashtable()
                                {
                                    {"in_emp_id",emp_id}
                                };
            return ExecuteDataSet("Leave_details_get", hst);
        }
        public int Apply_Leave_Insert_Update(ApplyLeaveEntity ObjApplyLeave)
        {
            Hashtable hst=new Hashtable()
                                 {
                                 {"in_leave_id",ObjApplyLeave.leave_id},
                                 {"in_empid",ObjApplyLeave.emp_id},
                                 {"in_from_date",ObjApplyLeave.from_date},
                                 {"in_to_date",ObjApplyLeave.to_date},
                                 {"in_reason",ObjApplyLeave.reason},
                                 {"in_no_of_days",ObjApplyLeave.no_of_days},
                                 {"in_leave_type",ObjApplyLeave.leave_type},
                                 {"in_calender_year",ObjApplyLeave.calender_year},
                                 {"in_CreatedBy",ObjApplyLeave.CreatedBy},
                                 };
            int i = ExecuteNonQuery("leave_details_insert_update", hst);
            return i;
        }
    }
}