using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using EntityManager;
using System.Data.SqlClient;
using DataManager;
using System.Drawing;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using System.Globalization;
public partial class admin_employeePaySlipList : System.Web.UI.Page
{

    clsEmployeePaySlip objemp_payslip = new clsEmployeePaySlip();
    EmployeePaySlip objdal_emp_payslip = new EmployeePaySlip();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindEmployeePaySlip();

        }
    }


    protected void gvEmployeePaySlip_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeePaySlip.PageIndex = e.NewPageIndex;
        BindEmployeePaySlip();
    }

    protected void gvEmployeePaySlip_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            int EmployeeId = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("employeePaySlip.aspx?esm_emp_id=" + EmployeeId);


        }
        if (e.CommandName == "printpdf")
        {
            
            int esm_id = Convert.ToInt32(e.CommandArgument);
            DataSet ds = objdal_emp_payslip.GetEmployeePayslipDetails(esm_id);
            if (ds.Tables.Count > 0)
            {
                string TempFile = Guid.NewGuid() + ".pdf";
                string FileName = Path.Combine(Server.MapPath("../temp"), TempFile);

                PrintPaySlip(ds, FileName);
                Response.Redirect("../temp/" + TempFile, false);
            }
        }
    }
    private void BindEmployeePaySlip()
    {
        int EmpId = objemp_payslip.empid;
        DataSet ds = objdal_emp_payslip.GetEmployeePayslipDetails(EmpId);
        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvEmployeePaySlip.DataSource = ds;
                gvEmployeePaySlip.DataBind();
            }
            else
            {
                gvEmployeePaySlip.DataSource = null;
                gvEmployeePaySlip.DataBind();
            }
        }
        catch
        {

        }
    }
    private void PrintPaySlip(DataSet ds, string ActualFile)
    {
        string TemplateFile = Path.Combine(Server.MapPath("pdfs"), "PaySlip.pdf");
        string Date = System.DateTime.Now.ToShortDateString().ToString();
        PdfReader pdfReader = new PdfReader(TemplateFile);
        PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(ActualFile, FileMode.Create));
        AcroFields pdfFormFields = pdfStamper.AcroFields;
        if (ds.Tables[0].Rows.Count > 0)
        {
            decimal basic = Convert.ToDecimal(ds.Tables[0].Rows[0]["esm_basic"]);
            decimal hra = Convert.ToDecimal(ds.Tables[0].Rows[0]["esm_hra"]);
            decimal special_earnings = Convert.ToDecimal(ds.Tables[0].Rows[0]["esm_special_pay"]);
            decimal other_earnings = Convert.ToDecimal(ds.Tables[0].Rows[0]["esm_other_earnings"]);
            decimal total_earnings = basic + hra + special_earnings + other_earnings;
            string totalearnings = total_earnings.ToString();
            decimal professional_tax = Convert.ToDecimal(ds.Tables[0].Rows[0]["esm_ptax"]);
            decimal loans = Convert.ToDecimal(ds.Tables[0].Rows[0]["esm_loans"]);
            decimal other_deductions = Convert.ToDecimal(ds.Tables[0].Rows[0]["esm_deductions"]);
            decimal total_deductions = professional_tax + loans + other_deductions;
            string totaldeductions = total_deductions.ToString();
            int net_payable = Convert.ToInt32(ds.Tables[0].Rows[0]["esm_total_payable"]);
            string netpayable = NumberToWords(net_payable);

            string month = System.DateTime.Now.Month.ToString();
            string year = System.DateTime.Now.Year.ToString();
            month = CommanClass.Get_Month(month);

            pdfFormFields.SetField("Month", month + " " + year);
            pdfFormFields.SetField("EmpCode", ds.Tables[0].Rows[0]["emp_code"].ToString());
            pdfFormFields.SetField("Name", ds.Tables[0].Rows[0]["emp_firstname"].ToString() + " " + ds.Tables[0].Rows[0]["emp_middlename"].ToString() + " " + ds.Tables[0].Rows[0]["emp_lastname"].ToString());
            pdfFormFields.SetField("Designation", ds.Tables[0].Rows[0]["Designation"].ToString());
            pdfFormFields.SetField("Department", ds.Tables[0].Rows[0]["Department"].ToString());
            pdfFormFields.SetField("Location", ds.Tables[0].Rows[0]["Location"].ToString());
            pdfFormFields.SetField("AcctNo", ds.Tables[0].Rows[0]["emp_accno"].ToString());
            pdfFormFields.SetField("BankName", ds.Tables[0].Rows[0]["emp_bankname"].ToString());
            pdfFormFields.SetField("PANNo", ds.Tables[0].Rows[0]["emp_panno"].ToString());
            pdfFormFields.SetField("PFAcctNo", ds.Tables[0].Rows[0]["emp_pfaccno"].ToString());
            pdfFormFields.SetField("UAN", ds.Tables[0].Rows[0]["emp_UAN"].ToString());
            pdfFormFields.SetField("Basic&DA", ds.Tables[0].Rows[0]["esm_basic"].ToString());
            pdfFormFields.SetField("HRA", ds.Tables[0].Rows[0]["esm_hra"].ToString());
            pdfFormFields.SetField("SpecialAllowance", ds.Tables[0].Rows[0]["esm_special_pay"].ToString());
            pdfFormFields.SetField("OtherEarnings", ds.Tables[0].Rows[0]["esm_other_earnings"].ToString());
            pdfFormFields.SetField("TotalEarnings", totalearnings);
            pdfFormFields.SetField("ProfessionalTax", ds.Tables[0].Rows[0]["esm_ptax"].ToString());
            pdfFormFields.SetField("Loans/Advance", ds.Tables[0].Rows[0]["esm_loans"].ToString());
            pdfFormFields.SetField("OtherDeductions", ds.Tables[0].Rows[0]["esm_deductions"].ToString());
            pdfFormFields.SetField("TotalDeductions", totaldeductions);
            pdfFormFields.SetField("NetAmount", ds.Tables[0].Rows[0]["esm_total_payable"].ToString());
            pdfFormFields.SetField("InWords1", netpayable + " " + "Only");
            pdfFormFields.SetField("Date", Date);


        }

        pdfStamper.FormFlattening = true;
        pdfStamper.Close();

    }

    public static string NumberToWords(int number)
    {
        string words = "";
        try
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 100000) + " Lakh ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

           
        }
        catch { }
        return words;
    }
}
