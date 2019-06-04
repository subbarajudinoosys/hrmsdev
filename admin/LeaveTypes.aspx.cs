using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataManager;
using EntityManager;
using System.Data;

public partial class admin_LeaveTypes : System.Web.UI.Page
{
    ClsLeaveType objLeave = new ClsLeaveType();
    DALLeaveTypes objDALLeaveType = new DALLeaveTypes();
    DALLeaveTypeList objDALleaveList=new DALLeaveTypeList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                int LeavetypeId = Convert.ToInt32(Request.QueryString["LeaveTypeId"]);
                BindleaveType(LeavetypeId);
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertLeaveType();
        BindleaveType(Convert.ToInt32(Request.QueryString["LeaveTypeId"]));
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("LeaveTypes.aspx", false);
    }

    private void InsertLeaveType()
    {
        try
        {
            if (Convert.ToInt32(hf_LeaveTypeId.Value) > 0)
                objLeave.OpName = "UPDATE";
            else
                objLeave.OpName = "INSERT";

            objLeave.LeaveTypeId = Convert.ToInt32(hf_LeaveTypeId.Value);
            objLeave.LeaveType = txtLeaveTypes.Text;
            objLeave.TotalLeaves = txtAvailableLeaves.Text;


            int Result = objDALLeaveType.InsertLeaveTypes(objLeave);

            if (Result > 0)
            {
                if (btnSubmit.Text == "Save")
                {
                    lblError.Text = CommanClass.ShowMessage("success", "Success", "LeaveType Details Created Successfully !!");
                }
                else
                {
                    lblError.Text = CommanClass.ShowMessage("success", "Success", "LeaveType Details Updated Successfully !!");
                }
                clearcontrols();
            }
            else
            {
                lblError.Text = CommanClass.ShowMessage("info", "Info", "LeaveType details not created please try again");
            }
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Error", ex.Message);
        }

    }

    private void GetLeaveTypes(int leavetypeId)
    {
        try
        {
            objLeave.OpName = "SELECT1";
            objLeave.LeaveTypeId = leavetypeId;

            DataSet objDs = objDALLeaveType.GetLeaveTypes(objLeave);
            if (objDs.Tables[0].Rows.Count > 0)
            {
                hf_LeaveTypeId.Value = objDs.Tables[0].Rows[0]["LeaveTypeId"].ToString();
                txtLeaveTypes.Text = objDs.Tables[0].Rows[0]["LeaveType"].ToString();
                txtAvailableLeaves.Text = objDs.Tables[0].Rows[0]["TotalLeaves"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }


    void clearcontrols()
    {
        btnSubmit.Text = "Save";
        txtLeaveTypes.Text = "";
        hf_LeaveTypeId.Value = "0";
        txtAvailableLeaves.Text = "";
    }


    protected void gvLeaveType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string LeavetypeId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit Leave")
        {
            btnSubmit.Text = "Update";
            GetLeaveTypes(Convert.ToInt32(LeavetypeId));
        }
    }
    protected void gvLeaveType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLeaveType.PageIndex = e.NewPageIndex;
        BindleaveType(Convert.ToInt32(hf_LeaveTypeId.Value));
    }

    private void BindleaveType(int leavetypeId)
    {
        objLeave.OpName = "SELECTALL";
        DataSet ds = objDALleaveList.GetLeaveTypesList(objLeave);
        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvLeaveType.DataSource = ds;
                gvLeaveType.DataBind();
            }
            else
            {
                gvLeaveType.DataSource = null;
                gvLeaveType.DataBind();
            }
        }
        catch
        {

        }
    }



}