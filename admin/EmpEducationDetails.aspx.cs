using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityManager;
using DataManager;
using System.Data;

public partial class admin_EmpEducationDetails : System.Web.UI.Page
{
    EmpEducation objEducation = new EmpEducation();
    DALEducation objDALEdu = new DALEducation();
    DALEducationList objDALEduList = new DALEducationList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindEducationDetails();

            CommanClass.Get_year(DropYear);
            string Emp_id = Request.QueryString["Emp_id"];
            string Emp_firstnam = Request.QueryString["Emp_firstnam"];

            if (Emp_id != null & Emp_firstnam != null)
            {
                lblEmpIdName.Text = "ID-" + Emp_id + " ,  Name-" + Emp_firstnam;
                string EmployeeEduId = Request.QueryString["Emp_id"];
              //  BindEducationDetails(EmployeeEduId);
               

            }
        }


    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertUpdateEducDetails();
        BindEducationDetails(Convert.ToInt32(Request.QueryString["Edu_Id"]));
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeList.aspx", false);
    }

    #region Private Methods
    private void InsertUpdateEducDetails()
    {
        try
        {
            if (Convert.ToInt32(hf_Edu_Id.Value) > 0)
                objEducation.OpName = "UPDATE";
            else

                objEducation.OpName = "INSERT";
            objEducation.Edu_Id = Convert.ToInt32(hf_Edu_Id.Value);
            objEducation.Emp_Id = Request.QueryString["Edu_Id"];
            objEducation.Edu_Type = DropEducationType.SelectedItem.ToString();
            objEducation.Edu_Level = DropEducationLevel.SelectedItem.ToString();
            objEducation.SchoolName = txtSchoolOrCollegeName.Text;
            objEducation.BoardName = txtBoardOrUniversityName.Text;
            objEducation.Specialization = txtSpecialization.Text;
            objEducation.YearOfPassing = DropYear.SelectedValue;
            objEducation.Percentage = txtPercentage.Text;
            objEducation.Category = ddlCategory.SelectedItem.ToString();
            objEducation.StartDate = txtStartDate.Text;
            objEducation.CompletedOn = txtCompletedOn.Text;


            int result = objDALEdu.InsertEmpEducation(objEducation);
            if (result > 0)
            {
                if (btnSubmit.Text == "Update")
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Education Details Updated Successfully");
                else
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Education Details Created Successfully");

                clearcontrols();
            }
            else
            {
                labelError.Text = CommanClass.ShowMessage("info", "Info", "Education Details was not created plase try again");
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    private void GetEduDetails(int EduId)
    {
        try
        {

            objEducation.OpName = "SELECT1";
            objEducation.Edu_Id = EduId;
            DataSet ds = objDALEdu.GetEmpEducation(objEducation);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hf_Edu_Id.Value = ds.Tables[0].Rows[0]["Edu_Id"].ToString();
                DropEducationType.SelectedIndex = DropEducationType.Items.IndexOf(DropEducationType.Items.FindByText(ds.Tables[0].Rows[0]["Edu_Type"].ToString()));
                DropEducationLevel.SelectedIndex = DropEducationLevel.Items.IndexOf(DropEducationLevel.Items.FindByText(ds.Tables[0].Rows[0]["Edu_Level"].ToString()));
                txtSchoolOrCollegeName.Text = ds.Tables[0].Rows[0]["SchoolName"].ToString();
                txtBoardOrUniversityName.Text = ds.Tables[0].Rows[0]["BoardName"].ToString();
                txtSpecialization.Text = ds.Tables[0].Rows[0]["Specialization"].ToString();
                DropYear.SelectedIndex = DropYear.Items.IndexOf(DropYear.Items.FindByValue(ds.Tables[0].Rows[0]["YearOfPassing"].ToString()));
                txtPercentage.Text = ds.Tables[0].Rows[0]["Percentage"].ToString();
                ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByText(ds.Tables[0].Rows[0]["Category"].ToString()));
                txtStartDate.Text = ds.Tables[0].Rows[0]["StartDate"].ToString();
                txtCompletedOn.Text = ds.Tables[0].Rows[0]["CompletedOn"].ToString();
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }

    }

    #endregion Private Methods
    protected void gvEducation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string EduId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit Record")
        {
            btnSubmit.Text = "Update";
            GetEduDetails(Convert.ToInt32(EduId));
        }
        else if (e.CommandName == "Delete Record")
        {
            DeleteEduDetails(Convert.ToInt32(EduId));
            BindEducationDetails(Convert.ToInt32(Request.QueryString["Edu_Id"]));
        }
    }

    protected void gvEducation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEducation.PageIndex = e.NewPageIndex;
        BindEducationDetails(Convert.ToInt32(hf_Edu_Id.Value));
    }

    private void BindEducationDetails(int EduId)
    {
        objEducation.OpName = "SELECTALL";
        objEducation.Emp_Id = EduId.ToString();
        DataSet ds = objDALEduList.GetEmpEducationList(objEducation);
        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvEducation.DataSource = ds;
                gvEducation.DataBind();
            }
            else
            {
                gvEducation.DataSource = null;
                gvEducation.DataBind();
            }
        }
        catch
        {

        }
    }

    void clearcontrols()
    {
        try
        {
            btnSubmit.Text = "Save";
            hf_Edu_Id.Value = "0";
            DropEducationType.SelectedIndex = -1;
            txtSchoolOrCollegeName.Text = "";
            txtBoardOrUniversityName.Text = "";
            DropEducationLevel.SelectedIndex = -1;
            txtSpecialization.Text = "";
            DropYear.SelectedIndex = -1;
            txtPercentage.Text = "";
            ddlCategory.SelectedIndex = -1;
            txtStartDate.Text = "";
            txtCompletedOn.Text = "";
        }
        catch { }
    }

    //void BindYear()
    //{

    //    int year = DateTime.Now.Year +2 - 100;

    //    for (int Y = year; Y <= DateTime.Now.Year + 2; Y++)
    //    {

    //        DropYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));

    //    }


    //}

    private void DeleteEduDetails(int EduId)
    {
        try
        {
            int result = objDALEdu.DeleteEmpEducation(EduId);
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    void BindEducationDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = objDALEdu.GetEduLevel(objEducation);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropEducationLevel.DataSource = ds.Tables[0];
                DropEducationLevel.DataTextField = "EduLevel_Name";
                DropEducationLevel.DataValueField = "EduLevel_Id";
                DropEducationLevel.DataBind();
            }
            else
            {
                DropEducationLevel.DataSource = null;
                DropEducationLevel.DataBind();
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);

        }

    }
}