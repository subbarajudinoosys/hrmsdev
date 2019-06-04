using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;
/// <summary>
/// Summary description for DALLeaveTypeList
/// </summary>
/// 
namespace DataManager
{
    public class DALLeaveTypeList : DataUtilities
    {
        public DataSet GetLeaveTypesList(ClsLeaveType objLeaveTypeList)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                        {"inLeaveTypeId",objLeaveTypeList.LeaveTypeId},
                                                        {"inLeaveType",objLeaveTypeList.LeaveType},
                                                        {"inTotalLeaves",objLeaveTypeList.TotalLeaves},
                                                        {"in_OpName",objLeaveTypeList.OpName},
                                                        
                                     };

            return ExecuteDataSet("applyleave_types", htParams);
        }
    }
}