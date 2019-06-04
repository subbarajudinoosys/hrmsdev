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


public partial class admin_EmployeeGrid : System.Web.UI.Page
{
    clsEmployee ObjEmpList = new clsEmployee();
    Employees _ObjEmpList = new Employees();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEmployee();
        }
    }
   
    protected void gvEmployeelist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeelist.PageIndex = e.NewPageIndex;
        BindEmployee();
    }

    private void BindEmployee()
    {
        try
        {
            clsEmployee ObjEmpList = new clsEmployee();
            EmployeeList _ObjEmpList = new EmployeeList();
            ObjEmpList.OpName = "SELECTALL";
            DataSet ds = _ObjEmpList.GetEmpList(ObjEmpList);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvEmployeelist.DataSource = ds;

            }
            else
            {
                gvEmployeelist.DataSource = null;

            }
            gvEmployeelist.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvEmployeelist.DataBind();
        }
        catch
        {

        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindEmployee();
    }
}