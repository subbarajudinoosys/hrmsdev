using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityManager;
using DataManager;
using System.Data;

public partial class admin_EmpDepartment : System.Web.UI.Page
{
    DALDepartment objDALDep = new DALDepartment();
    EmpDepartment objEmpDep = new EmpDepartment();
    DALDepartmentList objDALDepList = new DALDepartmentList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int DepId = Convert.ToInt32(Request.QueryString["Department_Id"]);
            BindDepartmentDetails(DepId);

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertUpdateEmpDepart();
        BindDepartmentDetails(Convert.ToInt32(Request.QueryString["Department_Id"]));
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("OtherDetails.aspx", false);
    }

    #region PrivateMethods
    private void InsertUpdateEmpDepart()
    {
        try
        {
            if (Convert.ToInt32(hf_Department_Id.Value) > 0)
                objEmpDep.OpName = "UPDATE";
            else
                objEmpDep.OpName = "INSERT";
            objEmpDep.DepartmentId = Convert.ToInt32(hf_Department_Id.Value);

            objEmpDep.Department = txtDepartDesc.Text;

            int Result = objDALDep.InsertEmpDep(objEmpDep);
            if (Result > 0)
            {
                if (btnSubmit.Text == "Save")
                {
                    lblError.Text = CommanClass.ShowMessage("success", "Success", "Department Details Created Successfully !!");
                }
                else
                {
                    lblError.Text = CommanClass.ShowMessage("success", "Success", "Department Details Updated Successfully !!");
                }
                clearcontrols();
            }
            else
            {
                lblError.Text = CommanClass.ShowMessage("info", "Info", "Department details not created please try again");
            }

        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Error", ex.Message);
        }
    }

    private void GetEmpDep(int DepId)
    {
        try
        {
            objEmpDep.OpName = "SELECT1";
            objEmpDep.DepartmentId = DepId;
            DataSet objDs = objDALDep.GetDepart(objEmpDep);
            if (objDs.Tables[0].Rows.Count > 0)
            {
                hf_Department_Id.Value = objDs.Tables[0].Rows[0]["Department_Id"].ToString();
                txtDepartDesc.Text = objDs.Tables[0].Rows[0]["Department"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }
    #endregion PrivateMethods

    protected void gvDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string DepId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit Record")
        {
            btnSubmit.Text = "Update";
            GetEmpDep(Convert.ToInt32(DepId));
        }
        else if (e.CommandName == "Delete Record")
        {
            DeleteDepDetails(Convert.ToInt32(DepId));
            BindDepartmentDetails(Convert.ToInt32(Request.QueryString["Department_Id"]));
        }
    }
    protected void gvDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDepartment.PageIndex = e.NewPageIndex;
        BindDepartmentDetails(Convert.ToInt32(hf_Department_Id.Value));
    }

    private void BindDepartmentDetails(int DepId)
    {
        objEmpDep.OpName = "SELECTALL";
        DataSet ds = objDALDepList.GetDepartList(objEmpDep);
        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvDepartment.DataSource = ds;
                gvDepartment.DataBind();
            }
            else
            {
                gvDepartment.DataSource = null;
                gvDepartment.DataBind();
            }
        }
        catch
        {

        }
    }

    private void DeleteDepDetails(int DepId)
    {
        try
        {
            int result = objDALDep.DeleteDepDetails(DepId);
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    void clearcontrols()
    {
        btnSubmit.Text = "Save";
        txtDepartDesc.Text = "";
        hf_Department_Id.Value = "0";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmpDepartment.aspx",false);
    }
}