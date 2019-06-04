using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsEmployeePaymentVoucher
/// </summary>
namespace EntityManager
{ 
public class clsEmployeePaymentVoucher
{
    public int epm_id { get; set; }
    public string epm_debit { get; set; }
    public string epm_paid { get; set; }
    public double epm_amount { get; set; }
    public string epm_payment_mode { get; set; }
    public string epm_towards { get; set; }
    public string epm_date { get; set; }
    public string OpName { get; set; }

}
}