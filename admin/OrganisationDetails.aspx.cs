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


public partial class admin_OrganisationDetails : System.Web.UI.Page
{
    clsOrganisationDetails objorg_det = new clsOrganisationDetails();
    DALOrganisationDetails dalobjorg_det = new DALOrganisationDetails();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
        getCountry();
        BindOrganisationDetails();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
       InsertUpdateOrganisationDetails();
      
     
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

        Response.Redirect("OrganisationMangement.aspx", false);
    }
    #region PrivateMethods
    private void InsertUpdateOrganisationDetails()
    {
        try
        {

            if (Convert.ToInt32(hf_oim_id.Value) > 0)
            {
                objorg_det.OpName = "UPDATE";
                btnSubmit.Text = "Update";
            }
            else
            {
                objorg_det.OpName = "INSERT";
            }
            
            //if (Convert.ToInt32(hf_oim_id.Value) > 0)
            //{
            //    objorg_det.OpName = "UPDATE";
            //    btnSubmit.Text = "Update";
            //}
            //else
            //{
            //    objorg_det.OpName = "INSERT";
            //}
                        
            objorg_det.oim_id = Convert.ToInt32(hf_oim_id.Value);
            objorg_det.oim_org_name = txtOrganisationName.Text.Trim();
            objorg_det.oim_tax_id = txtTaxID.Text.Trim();
            objorg_det.oim_num_emp = Convert.ToInt32(txtNumberOfEmployees.Text);
            objorg_det.oim_reg_num = txtRegistrationNumber.Text.Trim();
            objorg_det.oim_phone = txtPhone.Text.Trim();
            objorg_det.oim_fax = txtFax.Text.Trim();
            objorg_det.oim_email = txtEmail.Text.Trim();
            objorg_det.oim_addr1 = txtAddressStreet1.Text.Trim();
            objorg_det.oim_addr2 = txtAddressStreet2.Text.Trim();
            objorg_det.oim_city = txtCity.Text.Trim();
            objorg_det.oim_state = txtState.Text.Trim();
            objorg_det.oim_post_code = txtZip.Text.Trim();
            objorg_det.oim_country = dropCountry.SelectedItem.Text;
            objorg_det.oim_note = txtNote.Text.Trim();
            int Result = dalobjorg_det.Organisation_InsertUpdate(objorg_det);
            if (Result > 0)
            {

                if (btnSubmit.Text == "Save")
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Organisation Details created Successfully");
                else
                    labelError.Text = CommanClass.ShowMessage("success", "Success", "Organisation Details Updated Successfully");
                BindOrganisationDetails();
                clearcontrols();

            }
            else
            {
                labelError.Text = CommanClass.ShowMessage("info", "Info", "Organisation Details are not created plase try again");
            }
                       

        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    void clearcontrols()
    {
        hf_oim_id.Value = "0";
        txtOrganisationName.Text = "";
        txtTaxID.Text = "";
        txtNumberOfEmployees.Text = "";
        txtRegistrationNumber.Text = "";
        txtPhone.Text = "";
        txtFax.Text = "";
        txtEmail.Text = "";
        txtAddressStreet1.Text = "";
        txtAddressStreet2.Text = "";
        txtCity.Text = "";
        txtState.Text = "";
        txtZip.Text = "";
        dropCountry.SelectedValue = "-1";
        txtNote.Text = "";
        rfvdropCountry.Enabled =false;
        btnSubmit.Text = "Save";
    }


    public void getCountry()
    {
        DataSet ds = dalobjorg_det.getcountry();
        if (ds.Tables.Count > 0)
        {
            dropCountry.Items.Clear();
            dropCountry.Items.Add(new ListItem("-Select-", "-1"));
            dropCountry.DataSource = ds.Tables[0];
            dropCountry.DataValueField = "CountryId";
            dropCountry.DataTextField = "CountryName";
            dropCountry.DataBind();
        }

    }


    #endregion
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganisationDetails.aspx", false);
    }
    protected void gvOrganisationDetailsList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if(e.CommandName == "Edit Organisation Details")
        {
            int orgid = Convert.ToInt32(e.CommandArgument);
            GetOrganisationDetails(Convert.ToInt32(orgid));
        }
    }

   
    protected void gvOrganisationDetailsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOrganisationDetailsList.PageIndex = e.NewPageIndex;

        BindOrganisationDetails();
    }   


   private void BindOrganisationDetails()
   {
       try
       {
           objorg_det.OpName = "SELECTALL";
          
           DataSet ds = dalobjorg_det.getOrganisationDetails(objorg_det);
           if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
           {
               gvOrganisationDetailsList.DataSource = ds;
               gvOrganisationDetailsList.DataBind();
           }
           else
           {
               gvOrganisationDetailsList.DataSource = null;
               gvOrganisationDetailsList.DataBind();
           }
           gvOrganisationDetailsList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
           

       }
       catch(Exception ex) 
       {
           labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
       }
   }
  



    private void GetOrganisationDetails(int orgid)
    {
        try 
        {
            
            objorg_det.OpName = "SELECT";
            objorg_det.oim_id = orgid;
            DataSet ds = dalobjorg_det.getOrganisationDetails(objorg_det);
            if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hf_oim_id.Value = ds.Tables[0].Rows[0]["oim_id"].ToString();
                txtOrganisationName.Text = ds.Tables[0].Rows[0]["oim_org_name"].ToString();
                txtTaxID.Text = ds.Tables[0].Rows[0]["oim_tax_id"].ToString();
                txtNumberOfEmployees.Text = ds.Tables[0].Rows[0]["oim_num_emp"].ToString();
                txtRegistrationNumber.Text = ds.Tables[0].Rows[0]["oim_reg_num"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["oim_phone"].ToString();
                txtFax.Text = ds.Tables[0].Rows[0]["oim_fax"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["oim_email"].ToString();
                txtAddressStreet1.Text = ds.Tables[0].Rows[0]["oim_addr1"].ToString();
                txtAddressStreet2.Text = ds.Tables[0].Rows[0]["oim_addr2"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["oim_city"].ToString();
                txtState.Text = ds.Tables[0].Rows[0]["oim_state"].ToString();
                txtZip.Text = ds.Tables[0].Rows[0]["oim_post_code"].ToString();
                dropCountry.SelectedIndex = dropCountry.Items.IndexOf(dropCountry.Items.FindByText(ds.Tables[0].Rows[0]["oim_country"].ToString()));
                txtNote.Text = ds.Tables[0].Rows[0]["oim_note"].ToString();
            }
        }
        catch(Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindOrganisationDetails();
    }
}