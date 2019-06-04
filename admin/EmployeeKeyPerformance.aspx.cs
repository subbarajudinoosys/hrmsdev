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
public partial class admin_EmployeeKeyPerformance : System.Web.UI.Page
{
    clsEmployeeKeyPerformance obj_emp_key = new clsEmployeeKeyPerformance();
    DALEmployeeKeyPerformance dalobj_emp_key = new DALEmployeeKeyPerformance();
    EmpDesignation objEmpDesg = new EmpDesignation();
    DALDesignation objDALDesg = new DALDesignation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getDesignation();
            BindPerformanceDetails();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertUpdateKeyPerformanceDetails();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConfigureManagement.aspx", false);
    }
    #region PrivateMethods
    public void getDesignation()
    {
        DataSet ds = objDALDesg.GetDesignationByDes(objEmpDesg);
        if (ds.Tables.Count > 0)
        {
            dropJobTitle.Items.Clear();
            dropJobTitle.Items.Add(new ListItem("-Select-", "-1"));
            dropJobTitle.DataSource = ds.Tables[0];
            dropJobTitle.DataValueField = "Designation_Id";
            dropJobTitle.DataTextField = "Designation";
            dropJobTitle.DataBind();
        }

    }
    private void InsertUpdateKeyPerformanceDetails()
    {
        try
        {
            if (Convert.ToInt32(hf_ekp_id.Value) > 0)
            {
                obj_emp_key.OpName = "UPDATE";
                btnSubmit.Text = "Update";

            }
            else
            {
                obj_emp_key.OpName = "INSERT";
            }
            obj_emp_key.ekp_id = Convert.ToInt32(hf_ekp_id.Value);
            obj_emp_key.ekp_job_title = dropJobTitle.SelectedItem.Text;
            obj_emp_key.ekp_key_performance_indicator = txtKeyPerformanceIndicator.Text.Trim();
            obj_emp_key.ekp_min_rating = txtMinimumRating.Text.Trim();
            obj_emp_key.ekp_max_rating = txtMaximumRating.Text.Trim();
            obj_emp_key.ekp_default_scale = Convert.ToInt32(chkMakeDefaultScale.Checked);
            int Result = dalobj_emp_key.EmployeeKeyPerformance_InsertUpdate(obj_emp_key);
            if (Result > 0)
            {

                if (btnSubmit.Text == "Save")
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Employee Key Performance Details created Successfully");
                else
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Employee Key Performance Details Updated Successfully");

                BindPerformanceDetails();
                clearcontrols();

            }
            else
            {
                labelError.Text = CommanClass.ShowMessage("info", "Info", "Employee Key Performance Details are not created plase try again");
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }
         void clearcontrols()
          {
              dropJobTitle.SelectedValue = "-1";
              rfvdropJobTitle.Enabled = false;
              txtKeyPerformanceIndicator.Text = "";
              txtMinimumRating.Text = "";
              txtMaximumRating.Text = "";
              chkMakeDefaultScale.Checked = false;
              btnSubmit.Text = "Save";
              hf_ekp_id.Value = "0";
          }
    #endregion


         protected void btnReset_Click(object sender, EventArgs e)
         {
             Response.Redirect("EmployeeKeyPerformance.aspx", false);
         }
         protected void gvPerformanceDetailsList_RowCommand(object sender, GridViewCommandEventArgs e)
         {
             if (e.CommandName == "Edit Performance Details") 
             {

                 int performid = Convert.ToInt32(e.CommandArgument);
                 GetPerformanceDetails(performid);
             
             }
         }
         protected void gvPerformanceDetailsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
         {
             gvPerformanceDetailsList.PageIndex = e.NewPageIndex;

             BindPerformanceDetails();
         }
         private void BindPerformanceDetails()
         {
             try 
             { 
             obj_emp_key.OpName = "SELECTALL";
             DataSet ds = dalobj_emp_key.getEmployeeKeyPerformanceDetails(obj_emp_key);
             if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
             {
                 gvPerformanceDetailsList.DataSource = ds;
             }
             else
             {
                 gvPerformanceDetailsList.DataSource = null;
             }
             gvPerformanceDetailsList.DataBind();
             gvPerformanceDetailsList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            }
             catch(Exception ex)
             {
                 labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
             }
         }
         private void GetPerformanceDetails(int performid)
         {
             try 
             {
                 obj_emp_key.OpName = "SELECT";
                 obj_emp_key.ekp_id = performid;
                 DataSet ds = dalobj_emp_key.getEmployeeKeyPerformanceDetails(obj_emp_key);
                 if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                 {
                     hf_ekp_id.Value = ds.Tables[0].Rows[0]["ekp_id"].ToString();
                     dropJobTitle.SelectedIndex = dropJobTitle.Items.IndexOf(dropJobTitle.Items.FindByText(ds.Tables[0].Rows[0]["ekp_job_title"].ToString()));
                     txtKeyPerformanceIndicator.Text = ds.Tables[0].Rows[0]["ekp_key_performance_indicator"].ToString();
                     txtMinimumRating.Text = ds.Tables[0].Rows[0]["ekp_min_rating"].ToString();
                     txtMaximumRating.Text = ds.Tables[0].Rows[0]["ekp_max_rating"].ToString();
                     chkMakeDefaultScale.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ekp_defaultscale"]);
                     
                 }
             }
             catch(Exception ex)
             {
                 labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
             }
         }
         protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
         {
             BindPerformanceDetails();
         }
}