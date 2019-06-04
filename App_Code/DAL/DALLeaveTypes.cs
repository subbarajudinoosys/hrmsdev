using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
using DataManager;

/// <summary>
/// Summary description for DALLeaveTypes
/// </summary>
/// 
namespace DataManager
{
    public class DALLeaveTypes : DataUtilities
    {
        public int InsertLeaveTypes(ClsLeaveType objLeaveType)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                        {"inLeaveTypeId",objLeaveType.LeaveTypeId},
                                                        {"inLeaveType",objLeaveType.LeaveType},
                                                        {"inTotalLeaves",objLeaveType.TotalLeaves},
                                                        {"in_OpName",objLeaveType.OpName},
                                                        
                                     };
            return ExecuteNonQuery("applyleave_types", htParams);
        }

        public DataSet GetLeaveTypes(ClsLeaveType objLeaveType)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                        {"inLeaveTypeId",objLeaveType.LeaveTypeId},
                                                        {"inLeaveType",objLeaveType.LeaveType},
                                                        {"inTotalLeaves",objLeaveType.TotalLeaves},
                                                        {"in_OpName",objLeaveType.OpName},
                                                        
                                     };

            return ExecuteDataSet("applyleave_types", htParams);
        }

        public DataSet GetApplyLeaveTypes(ClsLeaveType objLeaveType)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                        {"inLeaveTypeId",objLeaveType.LeaveTypeId},
                                                        {"inLeaveType",objLeaveType.LeaveType},
                                                        {"inTotalLeaves",objLeaveType.TotalLeaves},
                                                        
                                                        
                                     };

            return ExecuteDataSet("get_leavetypes", htParams);
        }

    }
}