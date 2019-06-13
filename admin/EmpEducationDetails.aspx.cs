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
    DAL_LevelByType objDALLevelType = new DAL_LevelByType();
    int emp_Id = 0;
    string Emp_id = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        Emp_id = Request.QueryString["emp_id"];
        string Emp_firstname = Request.QueryString["Emp_firstname"];
       // emp_Id = Convert.ToInt32(Request.QueryString["emp_id"]);
        if (!IsPostBack)
        {
            if (Emp_id=="" || Emp_id==null)
            {
                Response.Redirect("/login.aspx");
            }
                else
                {
                    BindEducationDetails(Emp_id);
                   // BindEducationLevelDetails();
           

            CommanClass.Get_year(DropYear);
            if (Emp_id != null & Emp_firstname != null)
            {
                lblEmpIdName.Text = "ID-" + Emp_id + " ,  Name-" + Emp_firstname;
                string EmployeeEduId = Request.QueryString["Emp_id"];

            }
                
            }
         
        }


    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertUpdateEducDetails();
        BindEducationDetails(Emp_id);
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
            if (Convert.ToInt32(hf_Sno.Value) > 0)
            {
                objEducation.OpName = "UPDATE";
                
            }

            else
            {
                objEducation.OpName = "INSERT";

            }
                
                objEducation.S_No = Convert.ToInt32(hf_Sno.Value);
                //objEducation.Emp_Id = Request.QueryString["Emp_Id"];
                objEducation.emp_id = Emp_id;
                objEducation.Edu_Type = DropEducationType.SelectedItem.ToString();
                objEducation.Edu_Level = DropEducationLevel.SelectedItem.ToString();
                objEducation.SchoolName = txtSchoolOrCollegeName.Text;
                objEducation.BoardName = txtBoardOrUniversityName.Text;
                objEducation.Specialization = txtSpecialization.Text;
                objEducation.YearOfPassing = DropYear.SelectedValue;
                objEducation.Percentage = txtPercentage.Text;
                objEducation.Category = ddlCategory.SelectedItem.ToString();
                objEducation.StartDate = txtStartDate.Text;
                objEducation.EndDate = txtEndDate.Text;
            

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

    public void GetEduDetails(int Srno)
    {
        try
        {

            objEducation.OpName = "SELECT1";
            objEducation.S_No = Srno;
            objEducation.emp_id = Emp_id;
            DataSet ds = objDALEdu.GetEmpEducation(objEducation);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hf_Sno.Value = ds.Tables[0].Rows[0]["S_No"].ToString();
                DropEducationType.SelectedIndex = DropEducationType.Items.IndexOf(DropEducationType.Items.FindByText(ds.Tables[0].Rows[0]["Edu_Type"].ToString()));
                DropEducationLevel.SelectedIndex = DropEducationLevel.Items.IndexOf(DropEducationLevel.Items.FindByText(ds.Tables[0].Rows[0]["Edu_Level"].ToString()));
                txtSchoolOrCollegeName.Text = ds.Tables[0].Rows[0]["SchoolName"].ToString();
                txtBoardOrUniversityName.Text = ds.Tables[0].Rows[0]["BoardName"].ToString();
                txtSpecialization.Text = ds.Tables[0].Rows[0]["Specialization"].ToString();
                DropYear.SelectedIndex = DropYear.Items.IndexOf(DropYear.Items.FindByValue(ds.Tables[0].Rows[0]["YearOfPassing"].ToString()));
                txtPercentage.Text = ds.Tables[0].Rows[0]["Percentage"].ToString();
                ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByText(ds.Tables[0].Rows[0]["Category"].ToString()));
                txtStartDate.Text = ds.Tables[0].Rows[0]["StartDate"].ToString();
                txtEndDate.Text = ds.Tables[0].Rows[0]["EndDate"].ToString();
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
        string S_No = e.CommandArgument.ToString();
        if (e.CommandName == "Edit Record")
        {
            btnSubmit.Text = "Update";
            //objEducation.SNo =
            GetEduDetails(Convert.ToInt32(S_No));


        }
        else if (e.CommandName == "Delete Record")
        {
            DeleteEduDetails(Emp_id);
            BindEducationDetails(Emp_id);
        }
    }

    protected void gvEducation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEducation.PageIndex = e.NewPageIndex;
        BindEducationDetails(hf_Sno.Value);
    }

    private void BindEducationDetails(string EmpId)
    {
        objEducation.OpName = "SELECTALL";
        objEducation.emp_id = EmpId.ToString();
        DataSet ds = objDALEduList.GetEmpEducationList(objEducation);
        try
        {
            lblcnt.Text = ds.Tables[0].Rows.Count.ToString();

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
            hf_Sno.Value = "0";
            DropEducationType.SelectedIndex = -1;
            txtSchoolOrCollegeName.Text = "";
            txtBoardOrUniversityName.Text = "";
            DropEducationLevel.SelectedIndex = -1;
            txtSpecialization.Text = "";
            DropYear.SelectedIndex = -1;
            txtPercentage.Text = "";
            ddlCategory.SelectedIndex = -1;
            txtStartDate.Text = "";
            txtEndDate.Text = "";
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

    private void DeleteEduDetails(string emp_id)
    {
        try
        {
            int result = objDALEdu.DeleteEmpEducation(emp_id);
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    void BindEducationLevelDetails()
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
                DropEducationLevel.SelectedValue = "EduType_Id";
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

    protected void DropEducationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = int.Parse(DropEducationType.SelectedItem.Value);
        if(id>0)
        {
            DropEducationLevel.Enabled = true;
        }
        DataSet ds = new DataSet();
        ds = objDALLevelType.GetLevelByType(id);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DropEducationLevel.DataSource = ds.Tables[0];
            DropEducationLevel.DataTextField = "EduLevel_Name";
            DropEducationLevel.DataValueField = "EduLevel_Id";
            //DropEducationLevel.SelectedValue = "EduType_Id";
            DropEducationLevel.DataBind();
        }
        else
        {
            DropEducationLevel.DataSource = null;
            DropEducationLevel.DataBind();
        }
    }
}