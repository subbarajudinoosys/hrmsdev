using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_JobManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    protected void imgJobTitles_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("EmpDesignation.aspx", true);
    }
    protected void imgPayGrades_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PayGradeDetails.aspx", true);
    }
    protected void imgWorkShifts_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("WorkShiftDetails.aspx", true);
    }
}