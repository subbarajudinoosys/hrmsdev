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

public partial class admin_PassportDetails : System.Web.UI.Page
{

    PassportDetails objpass = new PassportDetails();
    DALPassport objDALPassport = new DALPassport();
    DALPassportList objDALpassportList = new DALPassportList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // BindVacancy();
            int PassportId = Convert.ToInt32(Request.QueryString["PassportId"]);
            BindPassportDetails();
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        insertPassportDetails();
    }

    private string GetFile(FileUpload FUName)
    {
        string fileName = string.Empty;
        if (FUName.HasFile)
        {
            string strPath = System.IO.Path.GetExtension(FUName.PostedFile.FileName);
            string date = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            fileName = date + strPath;
            FUName.SaveAs(Server.MapPath("~/Admin/PassportImages/" + fileName));
           //lblPassport.Text = fileName;
        }
        return fileName;
    }

    private void insertPassportDetails()
    {
        try
        {
            string filepath = string.Empty;
            string Imagepath = string.Empty;
            if (Convert.ToInt32(hf_pass_id.Value) > 0)
            {
                objpass.OpName = "UPDATE";
                if (fuPassportImage.HasFile)
                    lblPassport.Text = fuPassportImage.FileName;
                else
                    filepath = GetFile(fuPassportImage);

              
            }
            else
                objpass.OpName = "INSERT";
            if (fuPassportImage.HasFile)
                lblPassport.Text = fuPassportImage.FileName;
            else
                filepath = GetFile(fuPassportImage);

                    


            objpass.passportid = Convert.ToInt32(hf_pass_id.Value);
            objpass.EmployeeName = txtEmployeeName.Text;
            objpass.PassportNumber = txtPassportNumber.Text;
            objpass.PassportIssueDate = txtPassportIssuedate.Text;
            objpass.PassportEXpiryDate = txtPassportExpirydate.Text;


            objpass.Pannumber = txtPanNo.Text;
            objpass.Adharnumber = txtAdharNo.Text;
            objpass.ImageUpload = lblPassport.Text;
            objpass.ImageFilePath = GetFile(fuPassportImage);             

            //objpass.ImageUpload = lblImage.Text;
            //objpass.ImageFilePath = GetImage(fuImageFile);



            objpass.CreatedBy = 0;

            int Result = objDALPassport.Passport_insertUpdate(objpass);
            if (Result > 0)
            {
                labelError.Text = CommanClass.ShowMessage("success", "Success", "Passport Details created Successfully");
                clearcontrols();
                BindPassportDetails();
            }
            else
            {
                labelError.Text = CommanClass.ShowMessage("info", "Info", "Passport Details was not created plase try again");
            }


        }
        catch
        {

        }
    }


    private void GetPassport(int PassId) 
    {
        try
        {
            objpass.OpName = "SELECT1";
            objpass.passportid = PassId;
            DataSet Objds = objDALPassport.GetPassportDetails(objpass);

            if (Objds.Tables[0].Rows.Count > 0)
            {
                hf_pass_id.Value = Objds.Tables[0].Rows[0]["PassportId"].ToString();
                txtEmployeeName.Text = Objds.Tables[0].Rows[0]["EmployeeName"].ToString();
                txtPassportNumber.Text = Objds.Tables[0].Rows[0]["PasportNumber"].ToString();
                txtPassportIssuedate.Text = Objds.Tables[0].Rows[0]["PassportIssuedate"].ToString();
                txtPassportIssuedate.Text = Objds.Tables[0].Rows[0]["PassportExpiryDate"].ToString();
                txtPanNo.Text = Objds.Tables[0].Rows[0]["PanNumber"].ToString();
                txtAdharNo.Text = Objds.Tables[0].Rows[0]["AdharNumber"].ToString();
                lblPassport.Text = Objds.Tables[0].Rows[0]["ImageUpload"].ToString();
                hfPassportFileName.Value = Objds.Tables[0].Rows[0]["ImageFilePath"].ToString();
                //ResumeFileName = Objds.Tables[0].Rows[0]["FilePath"].ToString();
                //pdfView.Attributes["href"] = "FilesUpload/" + ResumeFileName;

            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    private void BindPassportDetails() 
    {
        objpass.OpName = "SELECTALL";

        DataSet ds = objDALpassportList.GetPassportList(objpass);
        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvPassportList.DataSource = ds;
                gvPassportList.DataBind();
            }
            else
            {
                gvPassportList.DataSource = null;
                gvPassportList.DataBind();
            }
            //gvPassportList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
        }
        catch
        {

        }
    }

    void clearcontrols()
    {
        hfPassportFileName.Value = "0";
        txtEmployeeName.Text = "";
        txtPassportNumber.Text = "";
        txtPassportIssuedate.Text = "";
        txtPassportExpirydate.Text = "";
        txtPanNo.Text = "";
        txtAdharNo.Text = "";      
        lblPassport.Text = "";
        hf_pass_id.Value = "0";

    }

    protected void gvPassportList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string PassId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit Passport")
        {
            btnSubmit.Text = "Update";
            GetPassport(Convert.ToInt32(PassId));
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    //protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
    protected void gvPassportList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
   
}