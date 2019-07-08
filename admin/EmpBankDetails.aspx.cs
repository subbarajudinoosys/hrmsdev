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
        string Emp_firstname = Request.QueryString["Emp_firstnam"];
        if (!IsPostBack)
        {
            BindBankDetailsList(Emp_id);
            ViewState["ps"] = 5;
        }
        if (Emp_id != null & Emp_firstname != null)
        {
            lblempIdName.Text = "ID-" + Emp_id + " ,  Name-" + Emp_firstname;
            string EmployeeEduId = Request.QueryString["Emp_id"];

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

        InsertUpdateEmpBD();
        BindBankDetailsList(Emp_id);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeList.aspx", false);
    }

    #region private Methods
    private void InsertUpdateEmpBD()
    {
        try
        {
            if (Convert.ToInt32(hf_emp_ID.Value) > 0)
            {
                objclsBank.OpName = "UPDATE";
            }
            else
            {
                objclsBank.OpName = "INSERT";
            }
            objclsBank.S_No = Convert.ToInt32(hf_emp_ID.Value);
            objclsBank.empbankname = txtBankName.Text;
            objclsBank.empaccno = txtAccountNo.Text;
            objclsBank.empacctype = ddlAccountType.SelectedItem.ToString();
            objclsBank.empifsccode = txtIFSCCode.Text;
            objclsBank.empbranchname = txtBranchName.Text;
            objclsBank.empbankcity = txtBankCity.Text;
            objclsBank.emppfaccno = txtPFAccountNo.Text;
            objclsBank.empUAN = txtUAN.Text;
            objclsBank.createdby = 0;
            objclsBank.empid = Emp_id;
            int Result = objBankDetails.EmpBD_InsertUpdate(objclsBank);
            if (Result > 0)
            {
                if (btnSubmit.Text == "Update")
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Bank Details Updated Successfully");
                else
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Bank Details Created Successfully");

                clearcontrols();
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

    private void GetBankDetails(int srno)
    {
        try
        {
            objclsBank.OpName = "SELECT1";
            objclsBank.S_No = srno;
            objclsBank.empid = srno.ToString();
            DataSet Objds = objBankDetails.GetEmpBD(objclsBank);
            if (Objds.Tables[0].Rows.Count > 0)
            {
                hf_emp_ID.Value = Objds.Tables[0].Rows[0]["S_No"].ToString();
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
        GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
        int RowIndex = row.RowIndex;
        int S_No = Convert.ToInt32(((Label)row.FindControl("lblS_No")).Text);
        //int S_No = Convert.ToInt32( e.CommandArgument.ToString());
        if (e.CommandName == "EditB")
        {
            btnSubmit.Text = "Update";
            //GetBankDetails(Convert.ToInt32("S_No"));
            GetBankDetails(S_No);
        }
       
             else if (e.CommandName == "Delete Record")
        {
            //GetBankDetails(Convert.ToInt32(S_No));
           //BindBankDetailsList(Convert.ToInt32(Request.QueryString["empbd_id"]));
            //GetBankDetails(S_No);  
             DeleteBankDetails(S_No);
             BindBankDetailsList(Emp_id);
        }
    }
    protected void gvbank_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvbankdetailsList.PageIndex = e.NewPageIndex;
        BindBankDetailsList(Emp_id);
    }
    private void BindBankDetailsList(string Emp_id)
    {
        objclsBank.OpName = "SELECTALL";
        objclsBank.empid = Emp_id;
        DataSet ds = objBankDList.GetBankDetailsList(objclsBank);
        try
        {
            if (ds.Tables[0].Rows.Count == 1)
            {
                int ID = Convert.ToInt32(ds.Tables[0].Rows[0]["S_No"].ToString());
                int result = objacc.UpdatePrimaryAccount(ID, Emp_id);
                DataSet ds1 = objBankDList.GetBankDetailsList(objclsBank);
                gvbankdetailsList.DataSource = ds1;
                
            }
            else if (ds.Tables[0].Rows.Count > 0)
            {
                gvbankdetailsList.DataSource = ds;
            }
            else
            {
                gvbankdetailsList.DataSource = null;
            }
            gvbankdetailsList.DataBind();
        }
        catch
        {

        }
    }
    private void DeleteBankDetails(int S_No)
    {
        try
        {
            int result = objBankDetails.DeleteBankDetails(S_No);
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
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
            Label lblid = (Label)row.FindControl("lblS_No");
            int ID = Convert.ToInt32(lblid.Text);


            int result = objacc.UpdatePrimaryAccount(ID, Emp_id);
            if(result>0)
            {
                BindBankDetailsList(Emp_id);
            }
   
        }
       
    }
    void clearcontrols()
    {
        try
        {
            btnSubmit.Text = "Save";
            hf_emp_ID.Value = "0";
            ddlAccountType.SelectedIndex = -1;
            txtAccountNo.Text = "";
            txtBankCity.Text = "";
            txtBankName.Text = "";
            txtBranchName.Text = "";
            txtIFSCCode.Text = "";
            txtPFAccountNo.Text = "";
            txtUAN.Text = "";
        }
        catch { }
    }

    
}
    
    
