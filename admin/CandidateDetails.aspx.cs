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


public partial class admin_CandidateDetails : System.Web.UI.Page
{
    clsCandidate objclCandidate = new clsCandidate();
    DALCandidate objDALCandidate = new DALCandidate();
    clsVacancy objVacancy = new clsVacancy();
    DALVacancy objDALVacancy = new DALVacancy();
    DALCandidateList objDALCanList = new DALCandidateList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindVacancy();
            int CandidateId = Convert.ToInt32(Request.QueryString["CandidateId"]);
            BindCandidateDetails();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertCandidate();
        BindCandidateDetails();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CandidateDetails.aspx", false);
    }
    private string GetFile(FileUpload FUName)
    {
        string fileName = string.Empty;
        if (FUName.HasFile)
        {
            string strPath = System.IO.Path.GetExtension(FUName.PostedFile.FileName);
            string date = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            fileName = date + strPath;
            FUName.SaveAs(Server.MapPath("~/Admin/CandidateResume/" + fileName));
        }
        return fileName;
    }
    private void InsertCandidate()
    {
        try
        {
            string filepath = string.Empty;
            if (Convert.ToInt32(hf_can_id.Value) > 0)
            {

                objclCandidate.OpName = "UPDATE";

                if (fuResumeImage.HasFile)
                    lblResume.Text = fuResumeImage.FileName;
                else
                    filepath = hfResumeFileName.Value;

            }
            else

                objclCandidate.OpName = "INSERT";
            filepath = GetFile(fuResumeImage);

            if (fuResumeImage.HasFile)
                lblResume.Text = fuResumeImage.FileName;
            else
                filepath = hfResumeFileName.Value;

            objclCandidate.CandidateId = Convert.ToInt32(hf_can_id.Value);
            objclCandidate.FirstName = txtFirstName.Text;
            objclCandidate.LastName = txtLastName.Text;
            objclCandidate.MiddleName = txtMiddleName.Text;
            objclCandidate.EmailID = txtEmailId.Text;
            objclCandidate.ContactNo = txtContactNo.Text;
            objclCandidate.JobVacancy = ddlJobVacancy.SelectedValue;
            objclCandidate.Keyword = txtKeyWords.Text;
            objclCandidate.Comments = txtComment.Text;
            objclCandidate.ApplicationDate = txtApplicationDate.Text;
            objclCandidate.CanResumeUpload = lblResume.Text;
            objclCandidate.CanResumeFilePath = GetFile(fuResumeImage);


            int Result = objDALCandidate.InsertCandidateDetails(objclCandidate);
            if (Result > 0)
            {

                if (btnSubmit.Text == "Save")
                {
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Candidate Details created Successfully");
                }
                else
                {
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Candidate Details Updated Successfully");
                }
                BindCandidateDetails();

                clearcontrols();

            }
            else
            {
                labelError.Text = CommanClass.ShowMessage("info", "Info", "Candidate was not created plase try again");
            }
        }
        catch (Exception e)
        {

        }
    }

    private void GetCandidate(int CandId)
    {
        try
        {
            objclCandidate.OpName = "SELECT1";
            objclCandidate.CandidateId = CandId;
            DataSet Objds = objDALCandidate.GetCandidateDetails(objclCandidate);

            if (Objds.Tables[0].Rows.Count > 0)
            {
                hf_can_id.Value = Objds.Tables[0].Rows[0]["CandidateId"].ToString();
                txtFirstName.Text = Objds.Tables[0].Rows[0]["FirstName"].ToString();
                txtMiddleName.Text = Objds.Tables[0].Rows[0]["MiddleName"].ToString();
                txtLastName.Text = Objds.Tables[0].Rows[0]["LastName"].ToString();
                txtEmailId.Text = Objds.Tables[0].Rows[0]["EmailID"].ToString();
                txtContactNo.Text = Objds.Tables[0].Rows[0]["ContactNo"].ToString();
                ddlJobVacancy.SelectedIndex = ddlJobVacancy.Items.IndexOf(ddlJobVacancy.Items.FindByValue(Objds.Tables[0].Rows[0]["JobVacancy"].ToString()));
                txtKeyWords.Text = Objds.Tables[0].Rows[0]["Keyword"].ToString();
                txtComment.Text = Objds.Tables[0].Rows[0]["Comments"].ToString();
                txtApplicationDate.Text = Objds.Tables[0].Rows[0]["ApplicationDate"].ToString();
                lblResume.Text = Objds.Tables[0].Rows[0]["CanResumeUpload"].ToString();
                hfResumeFileName.Value = Objds.Tables[0].Rows[0]["CanResumeFilePath"].ToString();
                //ResumeFileName = Objds.Tables[0].Rows[0]["FilePath"].ToString();
                //pdfView.Attributes["href"] = "FilesUpload/" + ResumeFileName;

            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }


    private void BindVacancy()
    {
        try
        {

            DataSet ds = new DataSet();
            ds = objDALVacancy.GetVacancy(objVacancy);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlJobVacancy.DataSource = ds.Tables[0];
                ddlJobVacancy.DataTextField = "VacancyName";
                ddlJobVacancy.DataValueField = "vacancyId";
                ddlJobVacancy.DataBind();
            }
            else
            {
                ddlJobVacancy.DataSource = null;
                ddlJobVacancy.DataBind();
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }


    private void BindCandidateDetails()
    {
        objclCandidate.OpName = "SELECTALL";

        DataSet ds = objDALCanList.GetCandidateList(objclCandidate);
        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvCandidateList.DataSource = ds;
                Session["dt"] = ds.Tables[0];
                gvCandidateList.DataBind();
            }
            else
            {
                gvCandidateList.DataSource = null;
                gvCandidateList.DataBind();
            }
            gvCandidateList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
        }
        catch
        {

        }
    }

    void clearcontrols()
    {
        hfResumeFileName.Value = "0";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtMiddleName.Text = "";
        txtEmailId.Text = "";
        txtContactNo.Text = "";
        txtComment.Text = "";
        txtKeyWords.Text = "";
        ddlJobVacancy.SelectedIndex = -1;
        txtApplicationDate.Text = "";
        lblResume.Text = "";
        hf_can_id.Value = "0";

    }
    protected void gvCandidateList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //string CandId = e.CommandArgument.ToString();
        if (e.CommandName != "Page")
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;

            int CandId = Convert.ToInt32(((Label)row.FindControl("lblCandidate_id")).Text);
            if (e.CommandName == "Edit Candidate")
            {
                btnSubmit.Text = "Update";
                GetCandidate(Convert.ToInt32(CandId));
            }
            else if (e.CommandName == "Delete Record")
            {
                DeleteCandidate(CandId);
                BindCandidateDetails();
            }

        }
    }
    protected void gvCandidateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCandidateList.PageIndex = e.NewPageIndex;
        BindCandidateDetails();
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCandidateDetails();
    }
    protected void imgsearch_Click(object sender, ImageClickEventArgs e)
    {
        SearchFromList(txtSearch.Text.Trim());
    }
    void SearchFromList(string Search)
    {
        try
        {
            if (Session["dt"] != null)
            {
                DataTable dt = (DataTable)Session["dt"];
                DataRow[] dr = dt.Select("FirstName LIKE '%" + Search +
                    "%' OR LastName LIKE '%" + Search +
                   "%' OR EmailID LIKE '%" + Search +
                   "%'");

                if (dr.Count() > 0)
                {
                    gvCandidateList.DataSource = dr.CopyToDataTable();
                    gvCandidateList.DataBind();
                }
            }
        }
        catch
        {

        }

    }
    public void DeleteCandidate(int CandidateId)
    {
        try
        {
            int result = objDALCandidate.DeleteCandidate(CandidateId);
            if (result == 1)
            {
                labelError.Text = CommanClass.ShowMessage("success", "Success", "Successfully Deleted");
            }
            else
            {
                labelError.Text = CommanClass.ShowMessage("danger", "Danger", "Vacancy details not deleted,Please try again");
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }

    }
}
    
