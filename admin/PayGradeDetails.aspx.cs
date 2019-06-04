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

public partial class admin_PayGradeDetails : System.Web.UI.Page
{
    clsPayGrade objclPay = new clsPayGrade();
    DALPayGrade objDAlPay = new DALPayGrade();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           BindPayGradeDetails();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertPayGrade();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("JobManagement.aspx", false);
    }

    private void InsertPayGrade()
    {
        try
        {
            if (Convert.ToInt32(hf_PayGrade_Id.Value) > 0)
            {
                objclPay.OpName = "UPDATE";
                btnSubmit.Text="Update";
            }
            else

                objclPay.OpName = "INSERT";

            objclPay.PayGradeId = Convert.ToInt32(hf_PayGrade_Id.Value);
            objclPay.PayGradeName = txtPaygradeName.Text;

            int Result = objDAlPay.InsertPayGrade(objclPay);
            if (Result > 0)
            {

                if (btnSubmit.Text == "Save")
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "PayGrade created Successfully");
                else
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "PayGrade Updated Successfully");
                BindPayGradeDetails();
                ClearControls();

            }
            else
            {
                labelError.Text = CommanClass.ShowMessage("info", "Info", "PayGrade was not created plase try again");
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    private void GetPayGrade(int paygradeid)
    {
        try
        {
        objclPay.OpName = "SELECT";
        objclPay.PayGradeId = paygradeid;
        DataSet ds = objDAlPay.GetPayGrade(objclPay);
        if (ds.Tables[0].Rows.Count > 0)
        {
            hf_PayGrade_Id.Value = ds.Tables[0].Rows[0]["PayGradeId"].ToString();
            txtPaygradeName.Text = ds.Tables[0].Rows[0]["PayGradeName"].ToString();
        }
        
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    
    }

    void ClearControls()
    {
        hf_PayGrade_Id.Value = "0";
        txtPaygradeName.Text = "";
        btnSubmit.Text = "Save";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("PayGradeDetails.aspx", false);
    }
    protected void gvPayGradeList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit PayGrade")
        {
            int paygradeid = Convert.ToInt32(e.CommandArgument);
            GetPayGrade(paygradeid);
            
        }
    }
    protected void gvPayGradeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPayGradeList.PageIndex = e.NewPageIndex;

        BindPayGradeDetails();
    }
    private void BindPayGradeDetails()
    {
        try
        {
            objclPay.OpName = "SELECTALL";
            objclPay.PayGradeName = "null";
            DataSet ds = objDAlPay.GetPayGrade(objclPay);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvPayGradeList.DataSource = ds;
            }
            else
            {
                gvPayGradeList.DataSource = null;
            }
            gvPayGradeList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvPayGradeList.DataBind();
        }
        catch(Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPayGradeDetails();
    }
}