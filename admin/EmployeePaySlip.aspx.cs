using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataManager;
using EntityManager;
public partial class admin_EmployeePaySlip : System.Web.UI.Page
{
    clsEmployeePaySlip objemp_payslip = new clsEmployeePaySlip();
    EmployeePaySlip objdal_emp_payslip = new EmployeePaySlip();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString.Count > 0)
                {
                    int EmployeeId = Convert.ToInt32(Request.QueryString["esm_emp_id"]);

                    GetEmployeePayslipDetails(EmployeeId.ToString());
                    btnSubmit.Text = "Update";


                }

            }

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        InsertEmployeePaySlip();
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        double gross = 0.0;
        double deductions = 0.0;
        double other_earnings = 0.0;
        double loans = 0.0;
        if (!string.IsNullOrEmpty(txtGross.Text))
        {
            gross = Convert.ToDouble(txtGross.Text);
        }
        double basic = gross * 0.4;
        double hra = basic * 0.6;
        double conveyanceallowance;
        double specialpay;
        double professionaltax;
        double total_amount_payable;

        if (gross > 0 && gross < 10000)
        {
            conveyanceallowance = 500;
        }
        else if (gross >= 10000 && gross < 50000)
        {
            conveyanceallowance = 700;
        }
        else if (gross == 0)
        {
            conveyanceallowance = 0;
        }
        else
        {
            conveyanceallowance = 1500;
        }
        specialpay = gross - basic - hra - conveyanceallowance;
        if (gross > 0 && gross < 10000)
        {
            professionaltax = 150;
        }
        else if (gross == 0)
        {
            professionaltax = 0;
        }
        else
        {
            professionaltax = 200;
        }


        txtBasic.Text = basic.ToString();
        txthra.Text = hra.ToString();
        txtConveyanceAllowance.Text = conveyanceallowance.ToString();
        txtSpecialPay.Text = specialpay.ToString();
        txtProfessionalTax.Text = professionaltax.ToString();
        if (!string.IsNullOrEmpty(txtDeductions.Text))
        {
            deductions = Convert.ToDouble(txtDeductions.Text);
        }
        if (!string.IsNullOrEmpty(txtOtherEarnings.Text))
        {
            other_earnings = Convert.ToDouble(txtOtherEarnings.Text);
        }
        if (!string.IsNullOrEmpty(txtLoans.Text))
        {
            loans = Convert.ToDouble(txtLoans.Text);
        }
        total_amount_payable = basic + hra + conveyanceallowance + specialpay - professionaltax - deductions + other_earnings - loans;

        txtTotalAmountPayable.Text = total_amount_payable.ToString();
    }
    public void InsertEmployeePaySlip()
    {


        objemp_payslip.esmid = Convert.ToInt32(hf_esm_id.Value);

        if (!string.IsNullOrEmpty(txtId.Text))
        {
            objemp_payslip.empid = txtId.Text;
        }
        if (!string.IsNullOrEmpty(txthra.Text))
        {
            objemp_payslip.hra = Convert.ToDouble(txthra.Text);
        }
        objemp_payslip.apryr = txtAppraisalYear.Text.Trim();
        if (!string.IsNullOrEmpty(dropBand.SelectedValue))
        {
            objemp_payslip.empband = dropBand.SelectedValue;
        }
        if (!string.IsNullOrEmpty(txtCtc.Text))
        {
            objemp_payslip.ctc = Convert.ToDouble(txtCtc.Text);
        }
        if (!string.IsNullOrEmpty(txtGross.Text))
        {
            objemp_payslip.gross = Convert.ToDouble(txtGross.Text);
        }
        if (!string.IsNullOrEmpty(txtBasic.Text))
        {
            objemp_payslip.basic = Convert.ToDouble(txtBasic.Text);
        }
        if (!string.IsNullOrEmpty(txthra.Text))
        {
            objemp_payslip.hra = Convert.ToDouble(txthra.Text);
        }
        if (!string.IsNullOrEmpty(txtConveyanceAllowance.Text))
        {
            objemp_payslip.conalw = Convert.ToDouble(txtConveyanceAllowance.Text);
        }
        if (!string.IsNullOrEmpty(txtSpecialPay.Text))
        {
            objemp_payslip.specialpay = Convert.ToDouble(txtSpecialPay.Text);
        }
        if (!string.IsNullOrEmpty(txtProfessionalTax.Text))
        {
            objemp_payslip.ptax = Convert.ToDouble(txtProfessionalTax.Text);
        }
        if (!string.IsNullOrEmpty(txtDeductions.Text))
        {
            objemp_payslip.deductions = Convert.ToDouble(txtDeductions.Text);
        }
        if (!string.IsNullOrEmpty(txtOtherEarnings.Text))
        {
            objemp_payslip.other_earnings = Convert.ToDouble(txtOtherEarnings.Text);
        }
        if (!string.IsNullOrEmpty(txtLoans.Text))
        {
            objemp_payslip.loans = Convert.ToDouble(txtLoans.Text);
        }
        if (!string.IsNullOrEmpty(txthra.Text))
        {
            objemp_payslip.totalpayable = Convert.ToDouble(txtTotalAmountPayable.Text.Trim());
        }
        int res = objdal_emp_payslip.EmployeePaySlip_InsertUpdate(objemp_payslip);

        if (res > 0)
        {
            if (btnSubmit.Text == "Save")
                lblMsg.Text = CommanClass.ShowMessage("success", "Success", "Employee PaySlip Details Created Successfully !!");
            else
                lblMsg.Text = CommanClass.ShowMessage("success", "Success", "Employee PaySlip Details Updated Successfully !!");
            ClearText();
            Response.Redirect("employeePaySlipList.aspx", true);

        }
        else
        {
            lblMsg.Text = "Employee PaySlip details are not created Successfully";
        }

    }

    public void GetEmployeePayslipDetails(string esm_emp_id)
    {
        EmployeePaySlip obj_emp_payslip = new EmployeePaySlip();
        //DataSet ds = obj_emp_payslip.GetEmployeePayslipDetails(esm_emp_id);
        DataSet ds = obj_emp_payslip.GetEmployeePayslipDetails(esm_emp_id);
        try
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                hf_esm_id.Value = ds.Tables[0].Rows[0]["esm_id"].ToString();
                txtId.Text = ds.Tables[0].Rows[0]["esm_emp_id"].ToString();
                txtAppraisalYear.Text = ds.Tables[0].Rows[0]["esm_apr_yr"].ToString();
                dropBand.SelectedValue = ds.Tables[0].Rows[0]["esm_emp_band"].ToString();
                txtCtc.Text = ds.Tables[0].Rows[0]["esm_ctc"].ToString();
                txtGross.Text = ds.Tables[0].Rows[0]["esm_gross"].ToString();
                txtBasic.Text = ds.Tables[0].Rows[0]["esm_basic"].ToString();
                txthra.Text = ds.Tables[0].Rows[0]["esm_hra"].ToString();
                txtConveyanceAllowance.Text = ds.Tables[0].Rows[0]["esm_con_alw"].ToString();
                txtSpecialPay.Text = ds.Tables[0].Rows[0]["esm_special_pay"].ToString();
                txtProfessionalTax.Text = ds.Tables[0].Rows[0]["esm_ptax"].ToString();
                txtDeductions.Text = ds.Tables[0].Rows[0]["esm_deductions"].ToString();
                txtOtherEarnings.Text = ds.Tables[0].Rows[0]["esm_other_earnings"].ToString();
                txtLoans.Text = ds.Tables[0].Rows[0]["esm_loans"].ToString();
                txtTotalAmountPayable.Text = ds.Tables[0].Rows[0]["esm_total_payable"].ToString();

            }
        }
        catch
        {

        }
    }
    public void ClearText()
    {
        btnSubmit.Text = "Save";
        txtId.Text = "";
        txtAppraisalYear.Text = "";
        dropBand.SelectedValue = "-1";
        txtCtc.Text = "";
        txtGross.Text = "";
        txtBasic.Text = "";
        txthra.Text = "";
        txtConveyanceAllowance.Text = "";
        txtSpecialPay.Text = "";
        txtProfessionalTax.Text = "";
        txtDeductions.Text = "";
        txtOtherEarnings.Text = "";
        txtLoans.Text = "";
        txtTotalAmountPayable.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("OtherDetails.aspx");
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeePaySlip.aspx", false);
    }
}
