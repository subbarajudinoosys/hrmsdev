using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;

namespace DataManager
{
    /// <summary>
    /// Summary description for DALBankDetails
    /// </summary>
    public class DALBankDetails:DataUtilities
    {
        #region Database Methods
        public DataSet GetEmpBD(clsBankDetails objclsBD)
        {
            Hashtable htparams = new Hashtable {
                                               {"in_S_No",objclsBD.S_No},
                                               {"in_emp_bankname",objclsBD.empbankname},
                                               {"in_emp_accno",objclsBD.empaccno},
                                               {"in_emp_acctype",objclsBD.empacctype},
                                               {"in_emp_ifsccode",objclsBD.empifsccode},
                                               {"in_emp_branchname",objclsBD.empbankname},
                                               {"in_emp_bankcity",objclsBD.empbankcity},
                                               {"in_createdby",objclsBD.createdby},
                                               {"in_OpName",objclsBD.OpName},
                                               {"in_emp_id",objclsBD.empid},
                                               {"in_emp_pfaccno",objclsBD.emppfaccno},
                                               {"in_emp_UAN",objclsBD.empUAN},
                                          };
            return ExecuteDataSet("EmpBankDetails", htparams);
        }

        public int EmpBD_InsertUpdate(clsBankDetails objclsBD)
        {
            Hashtable htparams = new Hashtable {
                                               {"in_S_No",objclsBD.S_No},
                                               {"in_emp_bankname",objclsBD.empbankname},
                                               {"in_emp_accno",objclsBD.empaccno},
                                               {"in_emp_acctype",objclsBD.empacctype},
                                               {"in_emp_ifsccode",objclsBD.empifsccode},
                                               {"in_emp_branchname",objclsBD.empbranchname},
                                               {"in_emp_bankcity",objclsBD.empbankcity},
                                               {"in_createdby",objclsBD.createdby},
                                               {"in_OpName",objclsBD.OpName},
                                               {"in_emp_id",objclsBD.empid},
                                               {"in_emp_pfaccno",objclsBD.emppfaccno},
                                               {"in_emp_UAN",objclsBD.empUAN},
                                          };
            return ExecuteNonQuery("EmpBankDetails", htparams);

        }
        public int DeleteBankDetails(int S_No)
        {
            Hashtable hst = new Hashtable{
                {"@inS_No",S_No}
            };
            return ExecuteNonQuery("EmpBankDetails_Delete", hst);
        }

        #endregion Database Methods
    }
}