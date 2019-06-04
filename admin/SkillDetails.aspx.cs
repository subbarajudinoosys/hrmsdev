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

public partial class admin_SkillDetails : System.Web.UI.Page
{
    clsSkillDetails objclsskil = new clsSkillDetails();
    DALSkillDetail objDALSkillDetail = new DALSkillDetail();
    DALSkillList objDALSkillList = new DALSkillList();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // BindVacancy();
            int SkillId = Convert.ToInt32(Request.QueryString["SkillId"]); 
             BindSkillDetails();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        insertSkillDetails();
    }


    private void insertSkillDetails()
    {
        try
        {
            if (Convert.ToInt32(hf_skill_id.Value) > 0)
            {
                objclsskil.OpName = "UPDATE";
                btnSubmit.Text = "Update";
            }
            else

                objclsskil.OpName = "INSERT";


            objclsskil.skillid = Convert.ToInt32(hf_skill_id.Value);
            objclsskil.rollname = txtRoleName.Text;
            objclsskil.skilldetails = txtSkillDetails.Text;
            

            objclsskil.CreatedBy = 0;

            int Result = objDALSkillDetail.Skill_insertUpdate(objclsskil);
            if (Result > 0)
            {
                labelError.Text = CommanClass.ShowMessage("success", "Success", "Skill Details created Successfully");
                clearcontrols();
                BindSkillDetails();
            }
            else
            {
                labelError.Text = CommanClass.ShowMessage("info", "Info", "Skill Details was not created plase try again");
            }

        }
        catch
        {

        }
    }

    private void Getskil(int SkillId)  
    {
        try
        {
            objclsskil.OpName = "SELECT1";
            objclsskil.skillid = SkillId; 
            DataSet Objds = objDALSkillDetail.GetSkillDetails(objclsskil);

            if (Objds.Tables[0].Rows.Count > 0)
            {
                hf_skill_id.Value = Objds.Tables[0].Rows[0]["SkillId"].ToString();
                txtRoleName.Text = Objds.Tables[0].Rows[0]["RoleName"].ToString();
                txtSkillDetails.Text = Objds.Tables[0].Rows[0]["SkillDetails"].ToString();                                
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }



    private void BindSkillDetails() 
    {
        objclsskil.OpName = "SELECTALL";

        DataSet ds = objDALSkillList.GetSkillList(objclsskil);
        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvSkillList.DataSource = ds;
                gvSkillList.DataBind();
            }
            else
            {
                gvSkillList.DataSource = null;
                gvSkillList.DataBind();
            }
            //gvPassportList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
        }
        catch
        {

        }
    }



    void clearcontrols()
    {

        txtRoleName.Text = "";
        txtSkillDetails.Text = "";                 
        hf_skill_id.Value = "0";
    }

    protected void gvSkillList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string skillid = e.CommandArgument.ToString();
        if (e.CommandName == "Edit Skill")
        {
            btnSubmit.Text = "Update";
            Getskil(Convert.ToInt32(skillid)); 
        }
    }
    protected void gvSkillList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}