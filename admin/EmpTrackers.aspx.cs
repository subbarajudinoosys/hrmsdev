using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataManager;
using EntityManager;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Text;

public partial class admin_EmpTrackers : System.Web.UI.Page
{

    clsEmpTrackers objempTracker = new clsEmpTrackers();
    DALEmpTrackers objDALTracker = new DALEmpTrackers();
    Employees _objEmp = new Employees();
    clsEmployee objclsEmployee = new clsEmployee();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEmployeeName();
            BindAvailableReview();
            
           int TrackerId = Convert.ToInt32(Request.QueryString["TrackerId"]);
           BindTrackerList();
        }
    }


 
    private void InsertEmpTracker()
    {
        try
        {
            if (Convert.ToInt32(hf_track_id.Value) > 0)
                objempTracker.OpName = "UPDATE";
            else
            objempTracker.OpName = "INSERT";

            objempTracker.TrackerId = Convert.ToInt32(hf_track_id.Value);
            objempTracker.TrackerName = txtTrackerName.Text;
            objempTracker.EmployeeName = dropEmployeeName.SelectedItem.Text;
            objempTracker.EmpId = Convert.ToInt32(dropEmployeeName.SelectedValue);
            objempTracker.AvailableReviewers = listAvailableReview.SelectedValue;
            objempTracker.AssignedReviewers = listAvailableReview.SelectedValue;

        }

      
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Error", ex.Message);
        }

    }



    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            listAssignedReview.Items.Add(listAvailableReview.SelectedItem.ToString());
            StringCollection sc = new StringCollection();
            foreach (ListItem item in listAssignedReview.Items)
            {
                if (item.Selected)
                {
                    sc.Add(listAssignedReview.Text);
                }
            }

            
        }
        catch (Exception ex)
        {

        }

    }

    private void GetTrackerDetails(int TrakerId)
    {
        try
        {
            objempTracker.OpName = "SELECT";
            objempTracker.TrackerId = TrakerId;
            DataSet ds = objDALTracker.GetEmpTracker(objempTracker);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hf_track_id.Value = ds.Tables[0].Rows[0]["TrackerId"].ToString();
                txtTrackerName.Text = ds.Tables[0].Rows[0]["TrackerName"].ToString();
                dropEmployeeName.SelectedIndex = dropEmployeeName.Items.IndexOf(dropEmployeeName.Items.FindByText(ds.Tables[0].Rows[0]["EmployeeName"].ToString()));
                listAvailableReview.SelectedIndex = listAvailableReview.Items.IndexOf(listAvailableReview.Items.FindByText(ds.Tables[0].Rows[0]["AvailableReviewers"].ToString()));
                listAvailableReview.SelectedValue = ds.Tables[0].Rows[0]["AvailableReviewers"].ToString();
                listAssignedReview.DataSource = ds;
                listAssignedReview.DataTextField = "fullname";
                listAssignedReview.DataValueField = "TrackerId";
                listAssignedReview.DataBind();
            }
        }
        catch (Exception e)
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            InsertEmpTracker();
            btnAdd_Click(sender, e);

            int Result = objDALTracker.InsertEmpTracker(objempTracker);

            if (Result > 0)
            {
                if (btnSubmit.Text == "Save")
                {
                    lblError.Text = CommanClass.ShowMessage("success", "Success", "Tracker Details Created Successfully !!");

                }
                else
                {
                    lblError.Text = CommanClass.ShowMessage("success", "Success", "Tracker Details Updated Successfully !!");
                }
                GetTracker();
                BindTrackerList();
                clearcontrols();

            }
            else
            {
                lblError.Text = CommanClass.ShowMessage("info", "Info", "Tracker details not created please try again");
            }
        }
        catch (Exception ex)
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


    private void BindAvailableReview()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = _objEmp.GetEmpByDesignation(objclsEmployee);

            if (ds.Tables[0].Rows.Count > 0)
            {
                listAvailableReview.DataSource = ds.Tables[0];
                listAvailableReview.DataTextField = "FullName";
                listAvailableReview.DataValueField = "emp_id";
                listAvailableReview.DataBind();
            }
            else
            {
                listAvailableReview.DataSource = null;
                listAvailableReview.DataBind();

            }

        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    private void GetTracker()
    {
        try
        {
            objempTracker.OpName = "SELECT1";

            objempTracker.EmpId = Convert.ToInt32(dropEmployeeName.SelectedValue);
            objempTracker.TrackerName = txtTrackerName.Text;
            DataSet ds = objDALTracker.GetEmpTracker(objempTracker);
            if (ds.Tables[0].Rows.Count > 0)
            {
                listAssignedReview.DataSource = ds;
                listAssignedReview.DataTextField = "fullname";
                listAssignedReview.DataValueField = "TrackerId";
                listAssignedReview.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }

    }

    private void DeleteTrackers(int TrackerId)
    {
        try
        {
            int Result = objDALTracker.DeleteTracker(TrackerId);
            if (Result > 0)
            {
                lblError.Text = CommanClass.ShowMessage("success", "Success", "Record Deleted Successfully !!");
            }
            else
            {
                lblError.Text = CommanClass.ShowMessage("info", "Info", "Record not deleted ");
            }
        }

        catch (Exception ex)
        {

        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            DeleteTrackers(Convert.ToInt32(listAssignedReview.SelectedValue));

            List<ListItem> deletedItems = new List<ListItem>();
            foreach (ListItem item in listAssignedReview.Items)
            {
                if (item.Selected)
                {
                    deletedItems.Add(item);
                }
            }
            foreach (ListItem item in deletedItems)
            {
                listAssignedReview.Items.Remove(item);
            }

            BindTrackerList();
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConfigureManagement.aspx", false);
    }

    


    
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmpTrackers.aspx", false);
    }


    private void BindTrackerList()
    {
        objempTracker.OpName = "SELECTALL";

        DataSet ds = objDALTracker.GetEmpTracker(objempTracker);
        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvTrackerList.DataSource = ds;
                gvTrackerList.DataBind();
            }
            else
            {
                gvTrackerList.DataSource = null;
                gvTrackerList.DataBind();
            }
            gvTrackerList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
        }
        catch
        {

        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTrackerList();
    }
    protected void gvTrackerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTrackerList.PageIndex = e.NewPageIndex;
        BindTrackerList();
    }
    protected void gvTrackerList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string trackId = e.CommandArgument.ToString();
        if(e.CommandName == "Edit Tracker")
        {
            GetTrackerDetails(Convert.ToInt32(trackId));
        }
    }

   
    void clearcontrols()
    {
        hf_track_id.Value = "0";
        txtTrackerName.Text = "";
        dropEmployeeName.SelectedIndex = -1;       
        listAssignedReview.Items.Clear();
    }
}