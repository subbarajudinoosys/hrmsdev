using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using EntityManager;
using DataManager;
using System.Data;

public partial class admin_EmpBankDetails : System.Web.UI.Page
{

    clsBankDetails objclsBank = new clsBankDetails();
    DALBankDetails objBankDetails = new DALBankDetails();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Emp_id = Request.QueryString["Emp_id"];
            string Emp_firstnam = Request.QueryString["Emp_firstnam"];

            if (Emp_id != null & Emp_firstnam != null)
            {
                lblEmpIdName.Text = "ID-" + Emp_id + " ,  Name-" + Emp_firstnam;
                string EmployeebdId = Request.QueryString["Emp_id"];

                //GetBankDetails(EmployeebdId);
            }
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int EmployeebdId = Convert.ToInt32(Request.QueryString["empbd_id"]);
        InsertUpdateEmpBD(EmployeebdId);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeList.aspx", false);
    }

    #region private Methods
    private void InsertUpdateEmpBD(int EmployeebdId)
    {
        try
        {
            if (Convert.ToInt32(hf_emp_id.Value) > 0)

                objclsBank.OpName = "UPDATE";
            else
                objclsBank.OpName = "INSERT";
            objclsBank.empid = EmployeebdId;
            objclsBank.empbankname = txtBankName.Text;
            objclsBank.empaccno = txtAccountNo.Text;
            objclsBank.empacctype = ddlAccountType.SelectedItem.ToString();
            objclsBank.empifsccode = txtIFSCCode.Text;
            objclsBank.empbranchname = txtBranchName.Text;
            objclsBank.empbankcity = txtBankCity.Text;
            objclsBank.emppfaccno = txtPFAccountNo.Text;
            objclsBank.empUAN = txtUAN.Text;
            objclsBank.createdby = 0;
            objclsBank.empbdid = Convert.ToInt32(hf_emp_id.Value);
            int Result = objBankDetails.EmpBD_InsertUpdate(objclsBank);
            if (Result > 0)
            {
                labelError.Text = CommanClass.ShowMessage("success", "Success", "Bank Details Created successfully !!");
                Response.Redirect("EmployeeList.aspx", false);
            }
            else
            {
                labelError.Text = CommanClass.ShowMessage("info", "Info", "Bank Details not created please try again!!");
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Error", ex.Message);
        }
    }

    private void GetBankDetails(int EmployeebdId)
    {
        try
        {
            objclsBank.OpName = "SELECT";
            objclsBank.empbdid = EmployeebdId;
            objclsBank.empid = EmployeebdId;
            DataSet Objds = objBankDetails.GetEmpBD(objclsBank);
            if (Objds.Tables[0].Rows.Count > 0)
            {
                hf_emp_id.Value = Objds.Tables[0].Rows[0]["empbd_id"].ToString();
                txtBankName.Text = Objds.Tables[0].Rows[0]["emp_bankname"].ToString();
                txtAccountNo.Text = Objds.Tables[0].Rows[0]["emp_accno"].ToString();
                ddlAccountType.SelectedIndex = ddlAccountType.Items.IndexOf(ddlAccountType.Items.FindByText(Objds.Tables[0].Rows[0]["emp_acctype"].ToString()));
                txtIFSCCode.Text = Objds.Tables[0].Rows[0]["emp_ifsccode"].ToString();
                txtBranchName.Text = Objds.Tables[0].Rows[0]["emp_branchname"].ToString();
                txtBankCity.Text = Objds.Tables[0].Rows[0]["emp_bankcity"].ToString();
                txtPFAccountNo.Text = Objds.Tables[0].Rows[0]["emp_pfaccno"].ToString();
                txtUAN.Text = Objds.Tables[0].Rows[0]["emp_UAN"].ToString();
            }
        }
        catch (Exception e)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Error", e.Message);
        }
    }

    #endregion private Methods

}
