using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsEmployeePaySlip
/// </summary>

namespace EntityManager
{
    public class clsEmployeePaySlip
    {

        public int esmid { get; set; }

        public string empid { get; set; }
		
		public string esm_emp_id {get; set;}
		
		

        public string apryr { get; set; }

        public string empband { get; set; }

        public double ctc { get; set; }

        public double gross { get; set; }

        public double basic { get; set; }

        public double hra { get; set; }

        public double conalw { get; set; }

        public double specialpay { get; set; }

        public double ptax { get; set; }

        public double deductions { get; set; }

        public double other_earnings { get; set; }

        public double loans { get; set; }

        public double totalpayable { get; set; }

        public string date { set; get; }

        public int createdby { set; get; }

        public double foodCoupons { get; set; }

        public double pf { get; set; }

        public double epf { get; set; }


    }

}