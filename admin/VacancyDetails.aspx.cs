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
using System.IO;

public partial class admin_VacancyDetails : System.Web.UI.Page
{

    clsVacancy objVacancy = new clsVacancy();
    DALVacancy objDALVacancy = new DALVacancy();
    EmpDesignation objEmDesg = new EmpDesignation();
    DALDesignation objDALDesg = new DALDesignation();
    Employees _objEmp = new Employees();
    clsEmployee objclsEmployee = new clsEmployee();
    DALVacancyList objDALVacancyList = new DALVacancyList();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindVacancyName();
            BindHiringManager();
            BindVacancyDetails();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertVacancy();
       
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("VacancyDetails.aspx", false);
    }

    private void InsertVacancy()
    {
        try
        {
            if (Convert.ToInt32(hf_vacancyId.Value) > 0)
                objVacancy.OpName = "UPDATE";
            else

            objVacancy.OpName = "INSERT";
            objVacancy.vacancyId =Convert.ToInt32(hf_vacancyId.Value);
            objVacancy.JobTitle = ddlJobTitle.SelectedValue;
            objVacancy.VacancyName = txtVacancyName.Text;
            objVacancy.HiringManager = dropHiringManager.SelectedValue;
            objVacancy.NoOfPositions = txtPositions.Text;
            objVacancy.Description = txtDescription.Text;

           
            if (chkActive.Checked)
                objVacancy.Active = Convert.ToInt32(chkActive.Checked);
            else
                objVacancy.ActiveText = txtActivText.Text.Trim();


            if (chkUserDefined1.Checked)
                objVacancy.UserDefinedFlag = Convert.ToInt32(chkUserDefined1.Checked);
            else
                objVacancy.UserDefinedText = txtUserDefined1.Text.Trim();

            if (chkUserDefined2.Checked)
                objVacancy.UserDefinedFlag1 = Convert.ToInt32(chkUserDefined2.Checked);
            else
                objVacancy.UserDefinedText1 = txtUserDefined2.Text.Trim();

            if (chkUserDefined3.Checked)
                objVacancy.UserDefinedFlag2 = Convert.ToInt32(chkUserDefined3.Checked);
            else
                objVacancy.UserDefinedText2 = txtUserDefined3.Text.Trim();


            if (chkUserDefined4.Checked)
                objVacancy.UserDefinedFlag3 = Convert.ToInt32(chkUserDefined4.Checked);
            else
                objVacancy.UserDefinedText3 = txtUserDefined4.Text.Trim();


            int Result = objDALVacancy.InsertVacancyDetails(objVacancy);
            if (Result > 0)
            {

                if (btnSubmit.Text == "Save")
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Vacancy created Successfully");
                else
                   
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "   Updated Successfully");
                BindVacancyDetails();

                clearcontrols();

            }
            else
            {
                labelError.Text = CommanClass.ShowMessage("info", "Info", "Vacancy was not created plase try again");
            }
        }
        catch (Exception e)
        {

        }
    }


    private void GetVacancy(int VacancyId)
    {
        objVacancy.OpName = "SELECT";
        objVacancy.vacancyId = VacancyId;
        DataSet ds = objDALVacancy.GetVacancyDetails(objVacancy);
        if (ds.Tables[0].Rows.Count > 0)
        {
            hf_vacancyId.Value = ds.Tables[0].Rows[0]["vacancyId"].ToString();
            ddlJobTitle.SelectedIndex = ddlJobTitle.Items.IndexOf(ddlJobTitle.Items.FindByValue(ds.Tables[0].Rows[0]["JobTitle"].ToString()));

            txtVacancyName.Text = ds.Tables[0].Rows[0]["VacancyName"].ToString();

            dropHiringManager.SelectedIndex = dropHiringManager.Items.IndexOf(dropHiringManager.Items.FindByValue(ds.Tables[0].Rows[0]["HiringManager"].ToString()));
            txtPositions.Text = ds.Tables[0].Rows[0]["NoOfPositions"].ToString();
            txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

            if (bool.Parse(ds.Tables[0].Rows[0]["Active"].ToString()))
            {
                chkActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Active"]);
                txtActivText.Enabled = false;
                
            }
            else
            {
                txtActivText.Text = ds.Tables[0].Rows[0]["ActiveText"].ToString().Trim();
            }

            if (bool.Parse(ds.Tables[0].Rows[0]["UserDefinedFlag"].ToString()))
            {
                chkUserDefined1.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["UserDefinedFlag"]);
                txtUserDefined1.Enabled = false;

            }
            else
            {
                txtUserDefined1.Text = ds.Tables[0].Rows[0]["UserDefinedText"].ToString().Trim();
            }

            if (bool.Parse(ds.Tables[0].Rows[0]["UserDefinedFlag1"].ToString()))
            {
                chkUserDefined2.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["UserDefinedFlag1"]);
                txtUserDefined2.Enabled = false;

            }
            else
            {
                txtUserDefined2.Text = ds.Tables[0].Rows[0]["UserDefinedText1"].ToString().Trim();
            }

            if (bool.Parse(ds.Tables[0].Rows[0]["UserDefinedFlag2"].ToString()))
            {
                chkUserDefined3.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["UserDefinedFlag2"]);
                txtUserDefined3.Enabled = false;

            }
            else
            {
                txtUserDefined3.Text = ds.Tables[0].Rows[0]["UserDefinedText2"].ToString().Trim();
            }

            if (bool.Parse(ds.Tables[0].Rows[0]["UserDefinedFlag3"].ToString()))
            {
                chkUserDefined4.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["UserDefinedFlag3"]);
                txtUserDefined4.Enabled = false;

            }
            else
            {
                txtUserDefined4.Text = ds.Tables[0].Rows[0]["UserDefinedText3"].ToString().Trim();
            }
        }
    }
    private void BindVacancyName()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = objDALDesg.GetDesignationByDes(objEmDesg);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlJobTitle.DataSource = ds.Tables[0];
                ddlJobTitle.DataTextField = "Designation";
                ddlJobTitle.DataValueField = "Designation_Id";
                ddlJobTitle.DataBind();
            }
            else
            {
                ddlJobTitle.DataSource = null;
                ddlJobTitle.DataBind();
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

     private void BindHiringManager()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = _objEmp.GetHiringManager(objclsEmployee);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dropHiringManager.DataSource = ds.Tables[0];
                dropHiringManager.DataTextField = "FullName";
                dropHiringManager.DataValueField = "emp_id";
                dropHiringManager.DataBind();
            }
            else
            {
                dropHiringManager.DataSource = null;
                dropHiringManager.DataBind();
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    void clearcontrols()
    {

        btnSubmit.Text = "Save";
        hf_vacancyId.Value = "0";
        ddlJobTitle.SelectedIndex = -1;
        txtVacancyName.Text = "";
        dropHiringManager.SelectedIndex = -1;
        txtPositions.Text = "";
        txtDescription.Text = "";
        chkActive.Checked = false;
        chkUserDefined1.Checked = false;
        chkUserDefined2.Checked = false;
        chkUserDefined3.Checked = false;
        chkUserDefined4.Checked = false;
        txtUserDefined1.Enabled = true;
        txtUserDefined2.Enabled = true;
        txtUserDefined3.Enabled = true;
        txtUserDefined4.Enabled = true;
        txtActivText.Enabled = true;
        txtActivText.Text = "";
        txtUserDefined1.Text = "";
        txtUserDefined2.Text = "";
        txtUserDefined3.Text = "";
        txtUserDefined4.Text = "";
    }
    protected void chkActive_CheckedChanged(object sender, EventArgs e)
    {
        if (chkActive.Checked)
        {
            txtActivText.Enabled = false;
            txtActivText.Text = string.Empty;
            
        }
        else
        {
            txtActivText.Enabled = true;
            
        }


    }
    protected void chkUserDefined1_CheckedChanged(object sender, EventArgs e)
    {
        if (chkUserDefined1.Checked)
        {
            txtUserDefined1.Enabled = false;
            txtUserDefined1.Text = string.Empty;

        }
        else
        {
            txtUserDefined1.Enabled = true;

        }
    }
    protected void chkUserDefined2_CheckedChanged(object sender, EventArgs e)
    {
        if (chkUserDefined2.Checked)
        {
            txtUserDefined2.Enabled = false;
            txtUserDefined2.Text = string.Empty;

        }
        else
        {
            txtUserDefined2.Enabled = true;

        }
    }
    protected void chkUserDefined3_CheckedChanged(object sender, EventArgs e)
    {
        if (chkUserDefined3.Checked)
        {
            txtUserDefined3.Enabled = false;
            txtUserDefined3.Text = string.Empty;

        }
        else
        {
            txtUserDefined3.Enabled = true;

        }
        
    }
    protected void chkUserDefined4_CheckedChanged(object sender, EventArgs e)
    {
        if (chkUserDefined4.Checked)
        {
            txtUserDefined4.Enabled = false;
            txtUserDefined4.Text = string.Empty;

        }
        else
        {
            txtUserDefined4.Enabled = true;

        }
    }
    protected void gvVacancy_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string VacancyId = e.CommandArgument.ToString();
        if(e.CommandName=="Edit Record")
        {
            btnSubmit.Text = "Update";
            GetVacancy(Convert.ToInt32(VacancyId));
        }
    }
    protected void gvVacancy_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVacancy.PageIndex = e.NewPageIndex;
        BindVacancyDetails();
    }

    private void BindVacancyDetails()
    {
        objVacancy.OpName = "SELECTALL";
        DataSet ds = objDALVacancyList.GetVacancyList(objVacancy);
        try
        {


            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvVacancy.DataSource = ds;
                gvVacancy.DataBind();
            }
            else
            {
                gvVacancy.DataSource = null;
                gvVacancy.DataBind();
            }
            gvVacancy.PageSize = Convert.ToInt32(DropPage.SelectedValue);
        }
        catch
        {

        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindVacancyDetails();
    }
}