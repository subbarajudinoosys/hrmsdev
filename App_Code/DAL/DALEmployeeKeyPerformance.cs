using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;
/// <summary>
/// Summary description for DALEmployeeKeyPerformance
/// </summary>
namespace DataManager
{
    public class DALEmployeeKeyPerformance : DataUtilities
    {
        #region Local Variables
        #endregion

        #region database methods

        #region employee key performance details
        public DataSet getEmployeeKeyPerformanceDetails(clsEmployeeKeyPerformance objclsempkey)
        {
            Hashtable htparams = new Hashtable
            {
                {"in_ekp_id",objclsempkey.ekp_id},
                {"in_ekp_job_title",objclsempkey.ekp_job_title},
                {"in_ekp_min_rating",objclsempkey.ekp_min_rating},
                {"in_ekp_max_rating",objclsempkey.ekp_max_rating},
                {"in_ekp_defaultscale",objclsempkey.ekp_default_scale},
                {"in_ekp_key_performance_indicator",objclsempkey.ekp_key_performance_indicator},
                {"in_OpName",objclsempkey.OpName}
            };
            return ExecuteDataSet("emp_key_performance_insert_update", htparams);
        }
        public int EmployeeKeyPerformance_InsertUpdate(clsEmployeeKeyPerformance objclsempkey)
        {
            Hashtable htparams = new Hashtable
            {
                {"in_ekp_id",objclsempkey.ekp_id},
                {"in_ekp_job_title",objclsempkey.ekp_job_title},
                {"in_ekp_min_rating",objclsempkey.ekp_min_rating},
                {"in_ekp_max_rating",objclsempkey.ekp_max_rating},
                {"in_ekp_defaultscale",objclsempkey.ekp_default_scale},
                {"in_ekp_key_performance_indicator",objclsempkey.ekp_key_performance_indicator},
                {"in_OpName",objclsempkey.OpName}
            };
            int IsSucess = ExecuteNonQuery("emp_key_performance_insert_update", htparams);

            return IsSucess;
        }
       
        #endregion
       
        #endregion
    }
}