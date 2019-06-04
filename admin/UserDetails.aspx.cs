using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntityManager;
using DataManager;

public partial class admin_UserDetails : System.Web.UI.Page
{
    clsUser objclsUser = new clsUser();
    DALUser objDALUser = new DALUser();
    DALUserList objDALUserList = new DALUserList();
    clsUser objclsUserList= new clsUser();
    Employees _objEmp = new Employees();
    clsEmployee objclsEmployee = new clsEmployee();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEmployeeName();


            int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                BindUserDetails(UserId);
            
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertUpdateUser();
        BindUserDetails(Convert.ToInt32(Request.QueryString["UserId"]));
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserManagement.aspx", false);
    }

    #region Private Methods
    private void InsertUpdateUser()
    {
        try 
        { 


        if (Convert.ToInt32(hf_UserId.Value) > 0)
            objclsUser.OpName = "UPDATE";
        else
            objclsUser.OpName = "INSERT";
        objclsUser.UserId = Convert.ToInt32(hf_UserId.Value);
        objclsUser.Username = txtUsername.Text;
        objclsUser.Password = txtPassword.Text;
        objclsUser.UserRole = ddlRoleId.SelectedItem.ToString();
        objclsUser.EmployeeName = dropEmployeeName.SelectedValue;
        objclsUser.Status = ddlStatus.SelectedItem.ToString();
        int result = objDALUser.InsertUpdateUser(objclsUser);
        if (result > 0)
        {
            if (btnSubmit.Text == "Save")
            {
                lblError.Text = CommanClass.ShowMessage("success", "Success", "User Details Created Successfully !!");
            }
            else
            {
                lblError.Text = CommanClass.ShowMessage("success", "Success", "User Details Updated Successfully !!");
            }
            clearcontrols();
        }
        else
        {
            lblError.Text = CommanClass.ShowMessage("info", "Info", "User details not created please try again");
        }
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Error", ex.Message);
        }
        }

    private void GetUser(int userid)
    {
        try
        {

            objclsUser.OpName = "SELECT1";
            objclsUser.UserId = userid;
            DataSet ds = objDALUser.GetUser(objclsUser);

            if (ds.Tables[0].Rows.Count > 0)
            {
                hf_UserId.Value = ds.Tables[0].Rows[0]["UserId"].ToString();
                txtUsername.Text = ds.Tables[0].Rows[0]["Username"].ToString();
                ddlRoleId.SelectedIndex = ddlRoleId.Items.IndexOf(ddlRoleId.Items.FindByText(ds.Tables[0].Rows[0]["UserRole"].ToString()));
                dropEmployeeName.SelectedIndex = dropEmployeeName.Items.IndexOf(dropEmployeeName.Items.FindByValue(ds.Tables[0].Rows[0]["EmployeeName"].ToString()));
                ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText(ds.Tables[0].Rows[0]["Status"].ToString()));
                txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                Panel1.Visible = false;
            }
        }
        catch(Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }

    }
    #endregion Private Methods

    void clearcontrols()
    {
        btnSubmit.Text = "Save";
        txtUsername.Text = "";
        ddlRoleId.SelectedIndex = -1;
        dropEmployeeName.SelectedIndex = -1;
        ddlStatus.SelectedIndex = -1;
        txtPassword.Text = "";
        txtCnfmPassword.Text = "";
        hf_UserId.Value = "0";
    }
    protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string UserId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit Record")
        {
            btnSubmit.Text = "Update";
            GetUser(Convert.ToInt32(UserId));
        }
    }
    protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUser.PageIndex = e.NewPageIndex;
        BindUserDetails(Convert.ToInt32(hf_UserId.Value));
    }

    private void BindUserDetails(int userid)
    {
        objclsUser.OpName = "SELECTALL";
        //objclsUser.UserId = UserId;
        DataSet ds = objDALUserList.GetUserList(objclsUser);
        try
        {

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvUser.DataSource = ds;
                gvUser.DataBind();
            }
            else
            {
                gvUser.DataSource = null;
                gvUser.DataBind();
            }
        }
        catch
        {

        }
    }



    private void BindEmployeeName()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = _objEmp.GetHiringManager(objclsEmployee);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dropEmployeeName.Items.Add(new ListItem("-Select-", "-1"));
                dropEmployeeName.DataSource = ds.Tables[0];
                dropEmployeeName.DataTextField = "FullName";
                dropEmployeeName.DataValueField = "emp_id";
                dropEmployeeName.DataBind();
            }
            else
            {
                dropEmployeeName.DataSource = null;
                dropEmployeeName.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserDetails.aspx", false);
    }
}