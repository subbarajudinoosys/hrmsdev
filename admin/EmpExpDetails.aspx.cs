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
public partial class admin_EmpExpDetails : System.Web.UI.Page
{
    EmpExperience objEmpExp = new EmpExperience();
    DALExperience objDAlExp = new DALExperience();
    DALExeperienceList objExpList = new DALExeperienceList();
    string EmployeeId;
    string Emp_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Emp_id = Request.QueryString["emp_id"];
        if (!IsPostBack)
        {
            Emp_id = Request.QueryString["emp_id"];
            string Emp_firstnam = Request.QueryString["Emp_firstnam"];

            if (Emp_id != null & Emp_firstnam != null)
            {
                lblEmpIdName.Text = "ID-" + Emp_id + " ,  Name-" + Emp_firstnam;
                EmployeeId = Emp_id;
                BindExperience(Emp_id);
            }
        }
    }

    #region Events
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertExperience();
        BindExperience(Emp_id);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeList.aspx", false);
    }
    protected void gvEmpExp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string S_No = e.CommandArgument.ToString();
        if (e.CommandName == "Edit Exp")
        {
            GetExperience(Convert.ToInt32(S_No));
            btnSubmit.Text = "Update";
        }

        if (e.CommandName == "Delete Exp")
        {
            DeleteEducationDetails(Convert.ToInt32(S_No));
            BindExperience(Emp_id);
        }
    }
    protected void gvEmpExp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmpExp.PageIndex = e.NewPageIndex;
        BindExperience(Emp_id);
    }

    #endregion

    #region PrivateMethods
    private void InsertExperience()
    {
        try
        {
            if (Convert.ToInt32(hf_S_No.Value) > 0)

                objEmpExp.OpName = "UPDATE";

            else

                objEmpExp.OpName = "INSERT";


            objEmpExp.S_No = Convert.ToInt32(hf_S_No.Value);
            objEmpExp.Emp_id = Emp_id;
            objEmpExp.CompanyName = txtCompanyName.Text;
            objEmpExp.FromDate =txtFromDate.Text;
            objEmpExp.ToDate =txtToDate.Text;
            objEmpExp.Designation = txtEmpDesignation.Text;
            objEmpExp.Technology = txtTechnology.Text;
            objEmpExp.ProjectTitles = txtProjectDetails.Text;

            int result = objDAlExp.InsertEmpExperience(objEmpExp);
            if (result > 0)
            {
                if(btnSubmit.Text=="Save")
                labelError.Text = CommanClass.ShowMessage("success", "Success", "Experience Details created Successfully");
                else
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Experience Details Updated Successfully");
                clearcontrols();
            }

            else
            {
                labelError.Text = CommanClass.ShowMessage("info", "Info", "Experience Details was not created plase try again");
            }
        }

        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }

    }

    private void GetExperience(int Expid)
    {
        try
        {

            objEmpExp.OpName = "SELECT1";
            objEmpExp.S_No = Expid;
            DataSet objds = objDAlExp.GetEmpExperience(objEmpExp);
            if (objds.Tables.Count > 0)
            {
                hf_S_No.Value = objds.Tables[0].Rows[0]["S_No"].ToString();
                txtCompanyName.Text = objds.Tables[0].Rows[0]["CompanyName"].ToString();
                txtFromDate.Text = objds.Tables[0].Rows[0]["FromDate"].ToString();
                txtToDate.Text = objds.Tables[0].Rows[0]["ToDate"].ToString();
                txtEmpDesignation.Text = objds.Tables[0].Rows[0]["Designation"].ToString();
                txtTechnology.Text = objds.Tables[0].Rows[0]["Technology"].ToString();
                txtProjectDetails.Text = objds.Tables[0].Rows[0]["ProjectTitles"].ToString();

            }
        }

        catch (Exception e)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", e.Message);
        }
    }


    private void BindExperience(string Empid)
    {
        try
        {
            objEmpExp.OpName = "SELECTALL";
            objEmpExp.Emp_id = Empid.ToString();
            DataSet ds = objExpList.GetEmpExperienceList(objEmpExp);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvEmpExp.DataSource = ds;
                gvEmpExp.DataBind();
            }
            else
            {
                gvEmpExp.DataSource = null;
                gvEmpExp.DataBind();
            }
        }
        catch (Exception e)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", e.Message);
        }
    }

    void clearcontrols()
    {
        btnSubmit.Text = "Save";
        hf_S_No.Value = "0";
        txtCompanyName.Text = "";
        txtFromDate.Text = "";
        txtToDate.Text = "";
        txtEmpDesignation.Text = "";
        txtTechnology.Text = "";
        txtProjectDetails.Text = "";
    }


    private void DeleteEducationDetails(int S_No)
    {
        try
        {
            int result = objDAlExp.DeleteEmpExp(S_No);
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    #endregion PrivateMethods


   
}