using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using EntityManager;

/// <summary>
/// Summary description for EmployeePaymentVoucher
/// </summary>
namespace DataManager
{
    public class EmployeePaymentVoucher : DataUtilities
    {
        #region Local Variables
        #endregion
        #region Database Methods
        
        #region EmployeePaymentVoucher

        public int EmployeePaymentVoucher_Insert(clsEmployeePaymentVoucher objemp_payvouch)
        {
            Hashtable htparams = new Hashtable{
                                              {"in_epm_id",objemp_payvouch.epm_id},
                                              {"in_epm_debit",objemp_payvouch.epm_debit},
                                              {"in_epm_paid",objemp_payvouch.epm_paid},
                                              {"in_epm_amount",objemp_payvouch.epm_amount},
                                              {"in_epm_payment_mode",objemp_payvouch.epm_payment_mode},
                                              {"in_epm_towards",objemp_payvouch.epm_towards},
                                              {"in_epm_date",objemp_payvouch.epm_date},
                                              {"in_OpName",objemp_payvouch.OpName}
                                            };
            int IsSucess = ExecuteNonQuery("emp_pay_voucher_mst_insert", htparams);
            return IsSucess;
        }

  
        public DataSet GetEmployeePaymentVoucher(clsEmployeePaymentVoucher objemp_payvouch)
        {
            Hashtable htparams = new Hashtable{
                                              {"in_epm_id",objemp_payvouch.epm_id},
                                              {"in_epm_debit",objemp_payvouch.epm_debit},
                                              {"in_epm_paid",objemp_payvouch.epm_paid},
                                              {"in_epm_amount",objemp_payvouch.epm_amount},
                                              {"in_epm_payment_mode",objemp_payvouch.epm_payment_mode},
                                              {"in_epm_towards",objemp_payvouch.epm_towards},
                                              {"in_epm_date",objemp_payvouch.epm_date},
                                              {"in_OpName",objemp_payvouch.OpName}
                                            };
            return ExecuteDataSet("emp_pay_voucher_mst_insert", htparams);
        }
        
        #endregion
        
        #endregion

    }
}