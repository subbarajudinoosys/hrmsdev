using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityManager;
using System.Collections;

/// <summary>
/// Summary description for DALPrimaryAccount
/// </summary>
namespace DataManager
{
    public class DALPrimaryAccount:DataUtilities
    {
        public int UpdatePrimaryAccount(int S_No,string emp_id)
        {
            Hashtable htupdate = new Hashtable {
                {"@inS_No",S_No},
                {"@inemp_id",emp_id}
            };
            return ExecuteNonQuery("UpdateBankIsprimary",htupdate);
        }
    }
}