using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataManager;
using EntityManager;
using System.Data;

public partial class admin_EmpDesignation : System.Web.UI.Page
{

    DALDesignation objDALDesg = new DALDesignation();
    EmpDepartment objEmpDep = new EmpDepartment();
    DALDepartment objDALDep = new DALDepartment();
    EmpDesignation objEmpDesg = new EmpDesignation();
    DALDesignationList objDALDesList = new DALDesignationList();
    EmpDesignation objEmpDesgList = new EmpDesignation();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDepartmentDetails();

            int DesId = Convert.ToInt32(Request.QueryString["Designation_Id"]);
            BindDesignationDetails(DesId);

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertEmpDesg();
        BindDesignationDetails(Convert.ToInt32(Request.QueryString["Designation_Id"]));
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("JobManagement.aspx", false);
    }

    #region PrivateMethods
    private void InsertEmpDesg()
    {
        try
        {

            if (Convert.ToInt32(hf_Designation_Id.Value) > 0)
                objEmpDesg.Op_Name = "UPDATE";
            else
                objEmpDesg.Op_Name = "INSERT";
            objEmpDesg.DesignationId = Convert.ToInt32(hf_Designation_Id.Value);
            objEmpDesg.DepartmentId = ddlDepartment.SelectedValue.ToString();
            objEmpDesg.Designation = txtDesignation.Text;
            objEmpDesg.CompanyCode = "1";
            objEmpDesg.Departmentdesc = ddlDepartment.SelectedItem.ToString();
            objEmpDesg.RoleId = Convert.ToInt32(ddlRoleId.SelectedValue);


            int Result = objDALDesg.InsertEmpDesg(objEmpDesg);
            if (Result > 0)
            {

                if (btnSubmit.Text == "Save")
                {
                    lblError.Text = CommanClass.ShowMessage("success", "Success", "Designation Details Created Successfully !!");
                }
                else
                {
                    lblError.Text = CommanClass.ShowMessage("success", "Success", "Designation Details Updated Successfully !!");
                }
                clearcontrols();
            }
            else
            {
                lblError.Text = CommanClass.ShowMessage("info", "Info", "Designation details not created please try again");
            }
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Error", ex.Message);
        }

    }

    private void GetEmpDesignation(int DesignationId)
    {
        try
        {
            objEmpDesg.Op_Name = "SELECT1";
            objEmpDesg.DesignationId = DesignationId;
            DataSet objDs = objDALDesg.GetDesignation(objEmpDesg);
            if (objDs.Tables[0].Rows.Count > 0)
            {
                hf_Designation_Id.Value = objDs.Tables[0].Rows[0]["Designation_Id"].ToString();
                txtDesignation.Text = objDs.Tables[0].Rows[0]["Designation"].ToString();
                ddlDepartment.SelectedIndex = ddlDepartment.Items.IndexOf(ddlDepartment.Items.FindByText(objDs.Tables[0].Rows[0]["Departmentdesc"].ToString()));
                ddlRoleId.SelectedValue = objDs.Tables[0].Rows[0]["RoleId"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }



    #endregion PrivateMethods
    void BindDepartmentDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = objDALDep.GetDepartDetails(objEmpDep);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDepartment.DataSource = ds.Tables[0];
                ddlDepartment.DataTextField = "Department";
                ddlDepartment.DataValueField = "Department_Id";
                ddlDepartment.DataBind();
            }
            else
            {
                ddlDepartment.DataSource = null;
                ddlDepartment.DataBind();
            }
        }
        catch { }
    }


    void clearcontrols()
    {
        try
        {
            btnSubmit.Text = "Save";
            hf_Designation_Id.Value = "0";
            ddlDepartment.SelectedIndex = -1;
            txtDesignation.Text = "";
            ddlRoleId.SelectedIndex = -1;
        }
        catch
        {
        }
    }

    protected void gvDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string DesId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit Record")
        {
            btnSubmit.Text = "Update";
            GetEmpDesignation(Convert.ToInt32(DesId));
        }
        else if (e.CommandName == "Delete Record")
        {
            DeleteDesigDetails(Convert.ToInt32(DesId));
            BindDesignationDetails(Convert.ToInt32(Request.QueryString["Designation_Id"]));
        }
    }
    protected void gvDesignation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDesignation.PageIndex = e.NewPageIndex;
        BindDesignationDetails(Convert.ToInt32(hf_Designation_Id.Value));
    }

    private void BindDesignationDetails(int DesId)
    {
        try
        {
            objEmpDesgList.Op_Name = "SELECTALL";
            objEmpDesgList.DesignationId = DesId;
           
            DataSet ds = objDALDesList.GetDesignationList(objEmpDesgList);
            if (ds.Tables.Count > 0 && ds.Tables.Count > 0)
            {
                gvDesignation.DataSource = ds;
                gvDesignation.DataBind();
            }
            else
            {
                gvDesignation.DataSource = null;
                gvDesignation.DataBind();
            }
        }
        catch
        {

        }
    }

    private void DeleteDesigDetails(int DesigId)
    {
        try
        {
            int result = objDALDesg.DeleteDesigDetails(DesigId);
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmpDesignation.aspx", false);
    }
}