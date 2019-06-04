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

public partial class admin_DocumentDetails : System.Web.UI.Page
{
    clsDocumentUpload objclDoc = new clsDocumentUpload();
    DALDocument objDALDo = new DALDocument();
    DALDocumentList objDalDocList = new DALDocumentList();
    public string ResumeFileName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int documentid = Convert.ToInt32(Request.QueryString["DocumentId"]);
            BindDocumentDetails(documentid);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertDocument();
        BindDocumentDetails(Convert.ToInt32(Request.QueryString["DocumentId"]));
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("DocumentDetails.aspx", false);
    }

    private void InsertDocument()
    {
        string filepath = string.Empty;
        if (Convert.ToInt32(hf_Document.Value) > 0)
        {
            objclDoc.OpName = "UPDATE";
            if (fuDocFile.HasFile)
                lblFile.Text = fuDocFile.FileName;
            else
                filepath = GetFile(fuDocFile);
        }
        else

            objclDoc.OpName = "INSERT";
            objclDoc.DocumentId = Convert.ToInt32(hf_Document.Value);
            objclDoc.Comments = txtComments.Text;
            objclDoc.UploadFile = fuDocFile.FileName;
            objclDoc.FilePath = GetFile(fuDocFile);

            int result = objDALDo.InsertUpdateDoc(objclDoc);
            if (result > 0)
            {
                if (btnSubmit.Text == "Save")
                {
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Document  Created Successfully !!");
                }
                else
                {
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Document Updated Successfully !!");
                }
                ClearControls();
            }
            else
            {
                labelError.Text = CommanClass.ShowMessage("info", "Info", "Document not created please try again");
            }
        }
    

    private string GetFile(FileUpload FUName)
    {
        string fileName = string.Empty;
        if (FUName.HasFile)
        {
            string strPath = System.IO.Path.GetExtension(FUName.PostedFile.FileName);
            string date = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            fileName = date + strPath;
            FUName.SaveAs(Server.MapPath("~/Admin/FilesUpload/" + fileName));
            lblFile.Text = fuDocFile.FileName;
        }
        return fileName;
    }

    private void GetDocument(int DocID)
     {
         try
         {
             objclDoc.OpName = "SELECT1";
             objclDoc.DocumentId = DocID;
             DataSet Objds = objDALDo.GetDocument(objclDoc);

             if (Objds.Tables[0].Rows.Count > 0)
             {
                 txtComments.Text = Objds.Tables[0].Rows[0]["Comments"].ToString();
                 lblFile.Text = Objds.Tables[0].Rows[0]["UploadFile"].ToString();
                 hfDocFile.Value = Objds.Tables[0].Rows[0]["FilePath"].ToString();
                 ResumeFileName = Objds.Tables[0].Rows[0]["FilePath"].ToString();
                 //pdfView.Attributes["href"] = "FilesUpload/" + ResumeFileName;

             }
         }
         catch (Exception ex)
         {
             labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
         }
     }

    protected void gvDocumentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDocumentList.PageIndex = e.NewPageIndex;
        BindDocumentDetails(Convert.ToInt32(hf_Document.Value));
    }

    private void BindDocumentDetails(int DocID)
    {
        objclDoc.OpName = "SELECTALL";
        
        DataSet ds = objDalDocList.GetLocationList(objclDoc);
        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvDocumentList.DataSource = ds;
                gvDocumentList.DataBind();
            }
            else
            {
                gvDocumentList.DataSource = null;
                gvDocumentList.DataBind();
            }
        }
        catch
        {

        }
    }

    void ClearControls()
    {
        txtComments.Text = "";
        lblFile.Text = "";
        hf_Document.Value = "0";
    }
    
}