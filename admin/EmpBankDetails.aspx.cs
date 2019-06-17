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
    DALBankDetailsList objBankDList = new DALBankDetailsList();
    DALPrimaryAccount objacc = new DALPrimaryAccount();

    string Emp_id = string.Empty;
      
    protected void Page_Load(object sender, EventArgs e)
    {
        Emp_id = Request.QueryString["emp_id"];
        string Emp_firstname = Request.QueryString["Emp_firstname"];
        if (!IsPostBack)
        {
            BindBankDetailsList(Emp_id);
            ViewState["ps"] = 5;
        }
            
         

            //getselectedRecord();
            //if (!string.IsNullOrEmpty(Request.QueryString["empbd_id"]))
            //{
            //    int EmployeebdId = Convert.ToInt32(Request.QueryString["empbd_id"]);

            //    GetBankDetails(EmployeebdId);
            //}
        

        

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //int EmployeebdId = Convert.ToInt32(Request.QueryString["S_No"]);

        InsertUpdateEmpBD(Emp_id);
        BindBankDetailsList(Emp_id);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeList.aspx", false);
    }

    #region private Methods
    private void InsertUpdateEmpBD(string Emp_id)
    {
        try
        {
            if (Convert.ToInt32(hf_emp_id.Value) > 0)
            {
                objclsBank.OpName = "UPDATE";
            }
            else
            {
                objclsBank.OpName = "INSERT";
            }
           
            objclsBank.empbankname = txtBankName.Text;
            objclsBank.empaccno = txtAccountNo.Text;
            objclsBank.empacctype = ddlAccountType.SelectedItem.ToString();
            objclsBank.empifsccode = txtIFSCCode.Text;
            objclsBank.empbranchname = txtBranchName.Text;
            objclsBank.empbankcity = txtBankCity.Text;
            objclsBank.emppfaccno = txtPFAccountNo.Text;
            objclsBank.empUAN = txtUAN.Text;
            objclsBank.createdby = 0;
            objclsBank.empid = hf_emp_id.Value;
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
            objclsBank.S_No = EmployeebdId;
            objclsBank.empid = EmployeebdId.ToString();
            DataSet Objds = objBankDetails.GetEmpBD(objclsBank);
            if (Objds.Tables[0].Rows.Count > 0)
            {
                hf_emp_id.Value = Objds.Tables[0].Rows[0]["emp_id"].ToString();
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



    protected void gvbank_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int S_No = Convert.ToInt32( e.CommandArgument.ToString());
        if(e.CommandName== "Edit")
        {
            btnSubmit.Text = "Update";
            GetBankDetails(Convert.ToInt32("S_No"));
        }
       
             else if (e.CommandName == "Delete Record")
        {
            GetBankDetails(Convert.ToInt32(S_No));
           //BindBankDetailsList(Convert.ToInt32(Request.QueryString["empbd_id"]));
        }
    }
    protected void gvbank_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvbankdetailsList.PageIndex = e.NewPageIndex;
        BindBankDetailsList(Emp_id);
    }
    private void BindBankDetailsList(string Emp_id)
    {
        DataSet ds = objBankDList.GetBankDetailsList(objclsBank);
        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvbankdetailsList.DataSource = ds;
                gvbankdetailsList.DataBind();
            }
            //else
            //{
            //    gvbankdetailsList.DataSource = null;
            //    gvbankdetailsList.DataBind();
            //}
        }
        catch
        {

        }
    }

   
    

    protected void rb1_CheckedChanged1(object sender, EventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        GridViewRow row = (GridViewRow)rb.NamingContainer;
        string strvalue = ((RadioButton)row.FindControl("rbBank")).Text;
        foreach (GridViewRow gvrow in gvbankdetailsList.Rows)
        {
            HiddenField hfPrimaryAcc = (HiddenField)gvrow.FindControl("hf_emp_id");
            RadioButton rbBank = (RadioButton)gvrow.FindControl("rbBank");
            if (hfPrimaryAcc.Value == strvalue)
                rbBank.Checked = false;
        }
        ((RadioButton)row.FindControl("rbBank")).Checked = true;





        if (((RadioButton)row.FindControl("rbBank")).Checked == true)
        {
            Label lblid = (Label)row.FindControl("lblbankid");
            int BankID = Convert.ToInt32(lblid.Text);
            objacc.UpdatePrimaryAccount(BankID);
        }
       
    }
    
}
    
    
