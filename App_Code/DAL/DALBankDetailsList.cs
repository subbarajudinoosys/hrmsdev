using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;
/// <summary>
/// Summary description for DALBankDetailsList
/// </summary>
namespace DataManager
{
    public class DALBankDetailsList:DataUtilities
    {
        public DataSet GetBankDetailsList(clsBankDetails objBankList)
        {
            Hashtable htparams=new Hashtable{
                                               {"in_S_No",objBankList.S_No},
                                               {"in_emp_bankname",objBankList.empbankname},
                                               {"in_emp_accno",objBankList.empaccno},
                                               {"in_emp_acctype",objBankList.empacctype},
                                               {"in_emp_ifsccode",objBankList.empifsccode},
                                               {"in_emp_branchname",objBankList.empbankname},
                                               {"in_emp_bankcity",objBankList.empbankcity},
                                               {"in_createdby",objBankList.createdby},
                                               {"in_OpName",objBankList.OpName},
                                               {"in_emp_id",objBankList.empid},
                                               {"in_emp_pfaccno",objBankList.emppfaccno},
                                               {"in_emp_UAN",objBankList.empUAN},
                                          };
            return ExecuteDataSet("EmpBankDetails", htparams);
        
            }
        }
    }
