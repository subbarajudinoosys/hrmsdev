using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntityManager;
using System.Data.SqlClient;
using DataManager;
using System.Drawing;

public partial class admin_PaymentVoucherList : System.Web.UI.Page
{

    clsEmployeePaymentVoucher objclsPay = new clsEmployeePaymentVoucher();
    EmployeePaymentVoucher objPayment = new EmployeePaymentVoucher();
    DALPaymentVoucherList objpaymentList = new DALPaymentVoucherList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindPaymentList();
        }

    }

    protected void gvVoucherList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit Payment")
        {
            string PaymentId = e.CommandArgument.ToString();
            Response.Redirect("EmployeePaymentVoucher.aspx?epm_id=" + PaymentId);
        }
    }
    protected void gvVoucherList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVoucherList.PageIndex = e.NewPageIndex;

        BindPaymentList();
    }

    private void BindPaymentList()
    {
        try
        {
            objclsPay.OpName = "SELECTALL";

            DataSet ds = objpaymentList.GetEmployeePaymentVoucherList(objclsPay);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvVoucherList.DataSource = ds;
            }
            else
            {
                gvVoucherList.DataSource = null;
            }
            gvVoucherList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvVoucherList.DataBind();
        }
        catch
        {
        }

    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPaymentList();
    }
}
