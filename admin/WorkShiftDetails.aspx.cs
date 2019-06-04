using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityManager;
using DataManager;
using System.Data;

public partial class admin_WorkShiftDetails : System.Web.UI.Page
{
    clsWorkShift objWorkShift = new clsWorkShift();
    DALWorkShift objDALWorkShift = new DALWorkShift();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {          
            BindShiftDetails();           
        }
    }

   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertUpdateWorkShift();
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("JobManagement.aspx", false);
    }

    #region Private Methods
    private void InsertUpdateWorkShift()
    {
        try
        {
            if (Convert.ToInt32(hf_Shift_Id.Value) > 0)
            {
                objWorkShift.OpName = "UPDATE";
                btnSubmit.Text = "Update";
            }
            else
        objWorkShift.OpName = "INSERT";
        objWorkShift.ShiftId = Convert.ToInt32(hf_Shift_Id.Value);
        objWorkShift.ShiftName = txtShiftName.Text;
        objWorkShift.FromDate =TimeSpan.Parse (ddlFrom.SelectedValue);
        objWorkShift.ToDate = TimeSpan.Parse(ddlTo.SelectedValue);
        objWorkShift.Duration = txtDuration.Text;
        int result = objDALWorkShift.InsertUpdateWorkShift(objWorkShift);
        if(result > 0)
        {
        if (btnSubmit.Text == "Save")
                {
                    lblError.Text = CommanClass.ShowMessage("success", "Success", "WorkShift Details Created Successfully !!");
                
                }
                else
                {
                    lblError.Text = CommanClass.ShowMessage("success", "Success", "WorkShift Details Updated Successfully !!");
                }
            BindShiftDetails();        
            clearcontrols();
         }
            else
            {
                lblError.Text = CommanClass.ShowMessage("info", "Info", "WorkShift details not created please try again");
            }
             
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    private void GetWorkShift(int shiftid)
    {
        try
        { 
        objWorkShift.OpName = "SELECT1";
        objWorkShift.ShiftId = shiftid;
        DataSet ds = objDALWorkShift.GetWorkShift(objWorkShift);
        if(ds.Tables[0].Rows.Count > 0)
        {
            hf_Shift_Id.Value = ds.Tables[0].Rows[0]["ShiftId"].ToString();
            txtShiftName.Text = ds.Tables[0].Rows[0]["ShiftName"].ToString();
            ddlFrom.SelectedIndex = ddlFrom.Items.IndexOf(ddlFrom.Items.FindByValue(ds.Tables[0].Rows[0]["FromDate"].ToString()));
            ddlTo.SelectedIndex = ddlTo.Items.IndexOf(ddlTo.Items.FindByValue(ds.Tables[0].Rows[0]["ToDate"].ToString()));
            txtDuration.Text = ds.Tables[0].Rows[0]["Duration"].ToString();
           
        }
       }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    #endregion Private Methods

    void clearcontrols()
    {
        txtShiftName.Text = "";
        ddlFrom.SelectedIndex = -1;
        ddlTo.SelectedIndex = -1;
        txtShiftName.Text = "";
        txtDuration.Text = "";
        btnSubmit.Text = "Save";
        hf_Shift_Id.Value = "0";
    }

  
    private void duration()
    {       
        DateTime d1 = Convert.ToDateTime(ddlFrom.SelectedValue);
        DateTime d2 = Convert.ToDateTime(ddlTo.SelectedValue);
        if (d2 < d1)
            d2 = d2.AddDays(1);
        TimeSpan ts = d2.Subtract(d1);
        txtDuration.Text = ts.ToString(@"hh\:mm");      
    }


    protected void ddlTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        duration();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkShiftDetails.aspx", false);
    }
    protected void gvWorkShiftList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit Work Shift Details")
        {
            int shiftid = Convert.ToInt32(e.CommandArgument);
            GetWorkShift(shiftid);

        }
    }
    protected void gvWorkShiftList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvWorkShiftList.PageIndex = e.NewPageIndex;

        BindShiftDetails();
    }
    private void BindShiftDetails()
    {

        try
        {
            objWorkShift.OpName = "SELECTALL";
            objWorkShift.ShiftName = "null";
        //    objWorkShift.FromDate =
        //objWorkShift.ToDate={00:00:00};
            DataSet ds = objDALWorkShift.GetWorkShift(objWorkShift);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvWorkShiftList.DataSource = ds;
            }
            else
            {
                gvWorkShiftList.DataSource = null;
            }
            gvWorkShiftList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvWorkShiftList.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);

        }
    }

    private void BindShiftDetailss()
    {
        try
        {
            objWorkShift.OpName = "SELECTALL";
            DataSet ds = objDALWorkShift.GetWorkShift(objWorkShift);
            if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count >0)
            {
                gvWorkShiftList.DataSource = ds;
            }
            else
            {
                gvWorkShiftList.DataSource =null;
            }
            gvWorkShiftList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvWorkShiftList.DataBind();

        }
        catch
        {

        }
    }




    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindShiftDetails();
    }
}