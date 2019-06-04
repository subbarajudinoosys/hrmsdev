using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
using DataManager;

/// <summary>
/// Summary description for DALPayGrade
/// </summary>
/// 
namespace DataManager
{
    public class DALPayGrade : DataUtilities
    {
        public int InsertPayGrade(clsPayGrade objPaygrade)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                       {"inPayGradeId",objPaygrade.PayGradeId},
                                                       {"inPayGradeName",objPaygrade.PayGradeName},
                                                       {"inOpName",objPaygrade.OpName},
                                                      
                                                        
                                     };
            return ExecuteNonQuery("paygrade_insert_update", htParams);
        }

        public DataSet GetPayGrade(clsPayGrade objPaygrade)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                      {"inPayGradeId",objPaygrade.PayGradeId},
                                                       {"inPayGradeName",objPaygrade.PayGradeName},
                                                       {"inOpName",objPaygrade.OpName},
                                                        
                                     };
            return ExecuteDataSet("paygrade_insert_update", htParams);
        }
    }
}