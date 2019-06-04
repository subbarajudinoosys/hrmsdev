using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
using DataManager;

/// <summary>
/// Summary description for DALUserList
/// </summary>
/// 
namespace DataManager
{
    public class DALUserList : DataUtilities
    {
        public DataSet GetUserList(clsUser objclsUserList)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                       {"inUserId",objclsUserList.UserId},
                                                       {"inUsername",objclsUserList.Username},
                                                       {"inPassword",objclsUserList.Password},
                                                       {"inUserRole",objclsUserList.UserRole},
                                                       {"inEmployeeName",objclsUserList.EmployeeName},
                                                       {"inStatus",objclsUserList.Status},
                                                       {"inOpName",objclsUserList.OpName},
                                                        
                                     };
            return ExecuteDataSet("user_insert_update", htParams);
        }
    }
}