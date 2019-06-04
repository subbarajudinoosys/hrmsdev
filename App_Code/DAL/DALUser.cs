using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
using DataManager;


/// <summary>
/// Summary description for DALUser
/// </summary>
/// 
namespace DataManager
{
    public class DALUser : DataUtilities
    {
        public int InsertUpdateUser(clsUser objclsUser)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                       {"inUserId",objclsUser.UserId},
                                                       {"inUsername",objclsUser.Username},
                                                       {"inPassword",objclsUser.Password},
                                                       {"inUserRole",objclsUser.UserRole},
                                                       {"inEmployeeName",objclsUser.EmployeeName},
                                                       {"inStatus",objclsUser.Status},
                                                       {"inOpName",objclsUser.OpName},
                                                        
                                     };
            return ExecuteNonQuery("user_insert_update", htParams);
        }

        public DataSet GetUser(clsUser objclsUser)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                       {"inUserId",objclsUser.UserId},
                                                       {"inUsername",objclsUser.Username},
                                                       {"inPassword",objclsUser.Password},
                                                       {"inUserRole",objclsUser.UserRole},
                                                       {"inEmployeeName",objclsUser.EmployeeName},
                                                       {"inStatus",objclsUser.Status},
                                                       {"inOpName",objclsUser.OpName},
                                                        
                                     };
            return ExecuteDataSet("user_insert_update", htParams);
        }

      
    }
}