using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using EntityManager;
/// <summary>
/// Summary description for EmployeePaySlip
/// </summary>
namespace DataManager
{
    public class EmployeePaySlip : DataUtilities
    {
        #region Local Variables
        #endregion

        #region Database Methods
        
        #region EmployeePaySlip
        
        public int EmployeePaySlip_InsertUpdate(clsEmployeePaySlip objemp_payslip)
        {
            Hashtable htparams = new Hashtable{
                                              {"in_esm_id",objemp_payslip.esmid},
                                              {"in_esm_emp_id",objemp_payslip.empid},
                                              {"in_esm_apr_yr",objemp_payslip.apryr},
                                              {"in_esm_emp_band",objemp_payslip.empband},
                                              {"in_esm_ctc",objemp_payslip.ctc},
                                              {"in_esm_gross",objemp_payslip.gross},
                                              {"in_esm_basic",objemp_payslip.basic},
                                              {"in_esm_hra",objemp_payslip.hra},
                                              {"in_esm_con_alw",objemp_payslip.conalw},
                                              {"in_esm_special_pay",objemp_payslip.specialpay},
                                              {"in_esm_ptax",objemp_payslip.ptax},
                                              {"in_esm_deductions",objemp_payslip.deductions},
                                              {"in_esm_other_earnings",objemp_payslip.other_earnings},
                                              {"in_esm_loans",objemp_payslip.loans},
                                              {"in_esm_total_payable",objemp_payslip.totalpayable},
                                              //{"in_esm_date",objemp_payslip.date},
                                              {"in_esm_createdby",objemp_payslip.createdby},
                                              {"in_esm_food_coupons",objemp_payslip.foodCoupons},
                                              {"in_esm_pf",objemp_payslip.pf},
                                              {"in_esm_epf",objemp_payslip.epf}
                                            };
            int IsSucess = ExecuteNonQuery("emp_sal_mst_insert_update", htparams);
            return IsSucess;
        }
        
        public DataSet GetEmployeePayslipDetails(int esm_emp_id)
        {
            Hashtable htParams = new Hashtable
                                     {
                                         {"in_esm_emp_id",esm_emp_id},
                                          
                                     };
            return ExecuteDataSet("emp_sal_mst_get", htParams);
        }
 }

        
        
        #endregion

        #endregion
}

