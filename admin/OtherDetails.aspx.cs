using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_OtherDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
   
    protected void imgDepartment_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EmpDepartment.aspx", true);
    }
    protected void imgPayRoll_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EmployeePaySlip.aspx", true);
    }
    protected void imgMenuaccess_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect("EmpEducationDetails.aspx", true);
    }
}