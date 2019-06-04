using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataManager;
using EntityManager;
using System.Data;


public partial class admin_LocationDetails : System.Web.UI.Page
{
    DALLocation objDALLoc = new DALLocation();
    EmpLocation objEmLoc = new EmpLocation();
    DALLocationList objDALLocList = new DALLocationList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int LocationId = Convert.ToInt32(Request.QueryString["LocationId"]);
            BindlocationDetails(LocationId);
            getCountry();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertUpdateLocation();
        BindlocationDetails(Convert.ToInt32(Request.QueryString["LocationId"]));

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganisationMangement.aspx", false);
    }

    #region PrivateMethods
    private void InsertUpdateLocation()
    {
        try
        {
            if (Convert.ToInt32(hf_LocationId.Value) > 0)
                objEmLoc.OpName = "UPDATE";
            else
                objEmLoc.OpName = "INSERT";
            objEmLoc.LocationId = Convert.ToInt32(hf_LocationId.Value);
            objEmLoc.Location = txtName.Text;
            objEmLoc.Country = dropCountry.SelectedItem.Text;
            objEmLoc.State = txtState.Text;
            objEmLoc.City = txtCity.Text;
            objEmLoc.Address = txtAddress.Text;
            objEmLoc.PostalCode = txtZip.Text;
            objEmLoc.Phone = txtPhone.Text;
            objEmLoc.Fax = txtFax.Text;
            objEmLoc.Notes = txtNotes.Text;
            objEmLoc.CompanyCode = "1";
            int Result = objDALLoc.InsertLocation(objEmLoc);

            if (Result > 0)
            {
                if (btnSubmit.Text == "Save")
                {
                    lblError.Text = CommanClass.ShowMessage("success", "Success", "Location Details Created Successfully !!");
                }
                else
                {
                    lblError.Text = CommanClass.ShowMessage("success", "Success", "Location Details Updated Successfully !!");
                }
                    clearcontrols();
            }
            else
            {
                lblError.Text = CommanClass.ShowMessage("info", "Info", "Location details not created please try again");
            }
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Error", ex.Message);
        }

    }

    private void GetLocation(int LocId)
    {
        try
        {
            objEmLoc.OpName = "SELECT1";
            objEmLoc.LocationId = LocId;
            DataSet objDs = objDALLoc.GetLocation(objEmLoc);
            if (objDs.Tables[0].Rows.Count > 0)
            {
                hf_LocationId.Value = objDs.Tables[0].Rows[0]["LocationId"].ToString();
                txtName.Text = objDs.Tables[0].Rows[0]["Location"].ToString();
                dropCountry.SelectedIndex = dropCountry.Items.IndexOf(dropCountry.Items.FindByText(objDs.Tables[0].Rows[0]["Country"].ToString()));
                //dropCountry.SelectedValue = objDs.Tables[0].Rows[0]["Country"].ToString();
                txtState.Text = objDs.Tables[0].Rows[0]["State"].ToString();
                txtCity.Text = objDs.Tables[0].Rows[0]["City"].ToString();
                txtAddress.Text = objDs.Tables[0].Rows[0]["Address"].ToString();
                txtZip.Text = objDs.Tables[0].Rows[0]["PostalCode"].ToString();
                txtPhone.Text = objDs.Tables[0].Rows[0]["Phone"].ToString();
                txtFax.Text = objDs.Tables[0].Rows[0]["Fax"].ToString();
                txtNotes.Text = objDs.Tables[0].Rows[0]["Notes"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }

    #endregion PrivateMethods
    void clearcontrols()
    {
        btnSubmit.Text = "Save";
        txtName.Text = "";
        dropCountry.SelectedValue = "-1";
        txtState.Text = "";
        txtCity.Text = "";
        txtAddress.Text = "";
        txtZip.Text = "";
        txtPhone.Text = "";
        txtFax.Text = "";
        txtNotes.Text = "";
        rfvdropCountry.Enabled = false;
        hf_LocationId.Value = "0";
    }
    protected void gvLocation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string LocationId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit Record")
        {
            btnSubmit.Text = "Update";
            GetLocation(Convert.ToInt32(LocationId));
        }
        else if (e.CommandName == "Delete Record")
        {
            DeleteLocDetails(Convert.ToInt32(LocationId));
            BindlocationDetails(Convert.ToInt32(Request.QueryString["LocationId"]));
        }
    }
    protected void gvLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLocation.PageIndex = e.NewPageIndex;
        BindlocationDetails(Convert.ToInt32(hf_LocationId.Value));
    }

    private void BindlocationDetails(int LocId)
    {
        objEmLoc.OpName = "SELECTALL";
        DataSet ds = objDALLocList.GetLocationList(objEmLoc);
        try
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvLocation.DataSource = ds;
                gvLocation.DataBind();
            }
            else
            {
                gvLocation.DataSource = null;
                gvLocation.DataBind();
            }
        }
        catch
        {

        }
    }

    private void DeleteLocDetails(int LocationId)
    {
        try
        {
            int result = objDALLoc.DeleteLocation(LocationId);
        }
        catch (Exception ex)
        {
            lblError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }
    public void getCountry()
    {
        DataSet ds = objDALLoc.getcountry();
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
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("LocationDetails.aspx", false);
    }
}
