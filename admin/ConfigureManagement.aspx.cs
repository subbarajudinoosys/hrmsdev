using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ConfigureManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

    }
    protected void imgTracker_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EmpTrackers.aspx", true);
    }
    protected void imgKPI_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EmployeeKeyPerformance.aspx", true);
    }
}