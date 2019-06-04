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

public partial class admin_EmpFamilyDetails : System.Web.UI.Page
{

    EmpFamilyDetails objEmpFam = new EmpFamilyDetails();
    DALFamilyDetails objDALFam = new DALFamilyDetails();
    DALFamliyList objDALFaList = new DALFamliyList();
    //int Emp_id;
    string Emp_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Emp_id = Request.QueryString["emp_id"];
        if (!IsPostBack)
        {

            Emp_id = Request.QueryString["emp_id"];
            string Emp_firstnam=Request.QueryString["Emp_firstnam"];

            if (Emp_id != null & Emp_firstnam != null)

           
            {
                lblEmpIdName.Text = "ID-" + Emp_id + " ,  Name-" + Emp_firstnam;

                BindFamilyDetails(Emp_id);

            }
        }
        Emp_id = Emp_id;
    }

    #region Events
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertFamDetails();
        BindFamilyDetails(Emp_id);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeList.aspx", false);
    }
    protected void gvFamilyDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFamilyDetails.PageIndex = e.NewPageIndex;
        BindFamilyDetails(Emp_id);
    }
    protected void gvFamilyDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string S_No = e.CommandArgument.ToString();
        if (e.CommandName == "Edit Family")
        {
            GetFamDetails(Convert.ToInt32( S_No), Emp_id);
            btnSubmit.Text = "Update";
        }

        if (e.CommandName == "Delete Family")
        {
            DeleteFamilyDetails(Convert.ToInt32(S_No), Emp_id);
            BindFamilyDetails(Emp_id);
        }
    }


    #endregion

    #region PrivateMethods

    private void InsertFamDetails()
    {
        try
        {

            if (Convert.ToInt32(hf_familyId.Value) > 0)

                objEmpFam.OpName = "UPDATE";
            else
                objEmpFam.OpName = "INSERT";


           // objEmpFam.Family_Id = Convert.ToInt32(hf_familyId.Value);
            objEmpFam.Emp_id = Emp_id;
            objEmpFam.Relationship = dropRelationship.SelectedValue;
            objEmpFam.LastName = txtRelLastName.Text;
            objEmpFam.FirstName = txtRelFirstName.Text;
            objEmpFam.Age = txtEmpAge.Text;
            objEmpFam.Employmentstatus = dropEmpStatus.SelectedValue;

            int Result = objDALFam.InsertFamilyDetails(objEmpFam);
            if (Result > 0)
            {
                if (btnSubmit.Text == "Save")
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Family Details created Successfully !!");
                else
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Family Details Updated Successfully !!");

                ClearControls();
            }
            else
            {
                labelError.Text = CommanClass.ShowMessage("info", "Info", "Family Details was not created plase try again");
            }
        }

        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }


    private void GetFamDetails(int S_No,string Emp_id)
    {
        try
        {
            objEmpFam.OpName = "SELECT1";
            objEmpFam.Emp_id =Emp_id.ToString();
            objEmpFam.S_No = S_No;
            DataSet objds = objDALFam.GetFamilyDetails(objEmpFam);
            if (objds.Tables.Count > 0)
            {
              //  hf_familyId.Value = objds.Tables[0].Rows[0]["Family_Id"].ToString();
                dropRelationship.SelectedIndex = dropRelationship.Items.IndexOf(dropRelationship.Items.FindByValue(objds.Tables[0].Rows[0]["Relationship"].ToString()));
                txtRelLastName.Text = objds.Tables[0].Rows[0]["LastName"].ToString();
                txtRelFirstName.Text = objds.Tables[0].Rows[0]["FirstName"].ToString();
                txtEmpAge.Text = objds.Tables[0].Rows[0]["Age"].ToString();
                dropEmpStatus.SelectedIndex = dropEmpStatus.Items.IndexOf(dropEmpStatus.Items.FindByValue(objds.Tables[0].Rows[0]["Employmentstatus"].ToString()));
            }

        }
        catch (Exception e)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", e.Message);
        }
    }

    private void BindFamilyDetails(string Emp_id)
    {
        try
        {
            objEmpFam.OpName = "SELECTALL";
            objEmpFam.Emp_id = Emp_id.ToString();
            DataSet ds = objDALFaList.GetFamilyList(objEmpFam);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvFamilyDetails.DataSource = ds;
                gvFamilyDetails.DataBind();
            }
            else
            {
                gvFamilyDetails.DataSource = null;
                gvFamilyDetails.DataBind();
            }
        }
        catch (Exception e)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", e.Message);
        }

    }

    void ClearControls()
    {
        try
        {
            btnSubmit.Text = "Save";
            hf_familyId.Value = "0";
            dropRelationship.SelectedIndex = -1;
            txtRelLastName.Text = "";
            txtRelFirstName.Text = "";
            txtEmpAge.Text = "";
            dropEmpStatus.SelectedIndex = -1;
        }
        catch { }

    }

    private void DeleteFamilyDetails(int S_No, string Emp_id)
    {
        try
        {
            int Result = objDALFam.DeleteFamDetails(S_No,Emp_id);
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }
    #endregion PrivateMethods


}