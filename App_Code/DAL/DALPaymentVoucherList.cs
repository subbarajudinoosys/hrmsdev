using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using EntityManager;


/// <summary>
/// Summary description for DALPaymentVoucherList
/// </summary>
/// 

namespace DataManager
{
    public class DALPaymentVoucherList : DataUtilities
    {
        public DataSet GetEmployeePaymentVoucherList(clsEmployeePaymentVoucher objemp_payvouchList)
        {
            Hashtable htparams = new Hashtable{
                                              {"in_epm_id",objemp_payvouchList.epm_id},
                                              {"in_epm_debit",objemp_payvouchList.epm_debit},
                                              {"in_epm_paid",objemp_payvouchList.epm_paid},
                                              {"in_epm_amount",objemp_payvouchList.epm_amount},
                                              {"in_epm_payment_mode",objemp_payvouchList.epm_payment_mode},
                                              {"in_epm_towards",objemp_payvouchList.epm_towards},
                                              {"in_epm_date",objemp_payvouchList.epm_date},
                                              {"in_OpName",objemp_payvouchList.OpName}
                                            };
            return ExecuteDataSet("emp_pay_voucher_mst_insert", htparams);
        }
    }
}