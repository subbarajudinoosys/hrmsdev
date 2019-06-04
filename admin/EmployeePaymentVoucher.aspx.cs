using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntityManager;
using DataManager;
public partial class admin_EmployeePaymentVoucher : System.Web.UI.Page
{
    clsEmployeePaymentVoucher obj_payvouch = new clsEmployeePaymentVoucher();
    EmployeePaymentVoucher objdal_payvouch = new EmployeePaymentVoucher();
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["epm_id"]))
            {
                int PaymentId = Convert.ToInt32(Request.QueryString["epm_id"]);
                GetPaymentDetails(PaymentId);
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertEmployeePaymentVoucher();
        
    }
    public void InsertEmployeePaymentVoucher()
    {
        try
        {
            if (Convert.ToInt32(hf_epm_id.Value) > 0)
            
                obj_payvouch.OpName = "UPDATE";
           
            else

               obj_payvouch.OpName = "INSERT";

            obj_payvouch.epm_id = Convert.ToInt32(hf_epm_id.Value);
           
            obj_payvouch.epm_debit = dropDebit.SelectedValue;
            obj_payvouch.epm_paid = txtPaidTo.Text.Trim();
            if (!string.IsNullOrEmpty(txtAmount.Text))
            {
                obj_payvouch.epm_amount = Convert.ToDouble(txtAmount.Text);
            }
            obj_payvouch.epm_payment_mode = dropPaymentMode.SelectedValue;
            obj_payvouch.epm_towards = txtTowards.Text.Trim();
            obj_payvouch.epm_date = txtDate.Text.Trim();
            int res = objdal_payvouch.EmployeePaymentVoucher_Insert(obj_payvouch);


            if (res > 0)
            {
                if (btnSubmit.Text == "Save")
                    lblMsg.Text = CommanClass.ShowMessage("success", "Success", "Pament Voucher Created Successfully");
                else
                    lblMsg.Text = CommanClass.ShowMessage("success", "Success", "Pament Voucher Updated Successfully");
                ClearText();
              Response.Redirect("PaymentVoucherList.aspx", true);
                
            }
            else
            {
                lblMsg.Text = CommanClass.ShowMessage("info", "Info", "Pament Voucher was not created plase try again");
            }
        }
        catch(Exception ex)
        {
            lblMsg.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
        
    }
    public void ClearText()
    {
        try
        {
            dropDebit.SelectedValue = "-1";
            txtPaidTo.Text = "";
            txtAmount.Text = "";
            dropPaymentMode.SelectedValue = "-1";
            txtTowards.Text = "";
            txtDate.Text = "";
        }
        catch { }
    }
    

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaymentVoucherList.aspx");
    }

    private void GetPaymentDetails(int PaymentId)
    {
        try
        {
            obj_payvouch.OpName = "SELECT1";
            
            obj_payvouch.epm_id = PaymentId;
            DataSet Objds = objdal_payvouch.GetEmployeePaymentVoucher(obj_payvouch);

            if (Objds.Tables[0].Rows.Count > 0)
            {
                hf_epm_id.Value = Objds.Tables[0].Rows[0]["epm_id"].ToString();
                dropDebit.SelectedIndex = dropDebit.Items.IndexOf(dropDebit.Items.FindByValue(Objds.Tables[0].Rows[0]["epm_debit"].ToString()));
                txtPaidTo.Text = Objds.Tables[0].Rows[0]["epm_paid"].ToString();
                txtAmount.Text = Objds.Tables[0].Rows[0]["epm_amount"].ToString();
                dropPaymentMode.SelectedIndex = dropPaymentMode.Items.IndexOf(dropPaymentMode.Items.FindByValue(Objds.Tables[0].Rows[0]["epm_payment_mode"].ToString()));
                txtTowards.Text = Objds.Tables[0].Rows[0]["epm_towards"].ToString();
                txtDate.Text = System.DateTime.Now.ToShortDateString();
            }

        }
        catch(Exception e)
        {
            lblMsg.Text = CommanClass.ShowMessage("danger", "Danger", e.Message);

        }
    }
}