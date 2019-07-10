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



public partial class admin_EmployeeList : System.Web.UI.Page
{

    clsEmployee ObjEmpList = new clsEmployee();
    EmployeeList _ObjEmpList = new EmployeeList();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["ps"] = 5;
            BindEmployee();
        }

    }
    protected void gvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            string EmployeeId = e.CommandArgument.ToString();

            Response.Redirect("EmployeeDetails.aspx?emp_id=" + EmployeeId);


        }

        if (e.CommandName == "EditBankDetails")
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string emp_id = commandArgs[0];
            string emp_firstnam = commandArgs[1];
            Response.Redirect(String.Format("EmpBankDetails.aspx?emp_id={0}&emp_firstnam={1}", emp_id, emp_firstnam));

        }

        if (e.CommandName == "EditEduDetails")
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string emp_id = commandArgs[0];
            string emp_firstname = commandArgs[1];
            Response.Redirect(String.Format("EmpEducationDetails.aspx?emp_id={0}&emp_firstname={1}", emp_id, emp_firstname));
        }

        if (e.CommandName == "EditExeDetails")
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string emp_id = commandArgs[0];
            string emp_firstnam = commandArgs[1];
            Response.Redirect(String.Format("EmpExpDetails.aspx?emp_id={0}&emp_firstnam={1}", emp_id, emp_firstnam));
        }
        if (e.CommandName == "EditFamilyDetails")
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string emp_id = commandArgs[0];
            string emp_firstnam = commandArgs[1];

            Response.Redirect(String.Format("EmpFamilyDetails.aspx?emp_id={0}&emp_firstnam={1}", emp_id, emp_firstnam));

        }
    }



    protected void gvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SearchEmplyItemfromList(txtSearch.Text.Trim());
        gvEmployee.PageIndex = e.NewPageIndex;
        BindEmployee();
    }

    private void BindEmployee()
    {
        try
        {
            clsEmployee ObjEmpList = new clsEmployee();
            Employees _ObjEmpList = new Employees();
            ObjEmpList.OpName = "SELECTALL";
            DataSet ds = _ObjEmpList.GetEmpList(ObjEmpList);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvEmployee.DataSource = ds;
                Session["dt"] = ds.Tables[0];

            }
            else
            {
                gvEmployee.DataSource = null;

            }
            gvEmployee.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvEmployee.DataBind();
        }
        catch
        {

        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindEmployee();
    }

    protected void imgsearch_Click(object sender, ImageClickEventArgs e)
    {
        SearchEmplyItemfromList(txtSearch.Text.Trim());
    }
    void SearchEmplyItemfromList(string searchtext)
    {
        try
        {
            if (Session["dt"] != null)
            {
                DataTable dt = (DataTable)Session["dt"];
                DataRow[] dr = dt.Select("emp_firstname LIKE '%" + searchtext +
                    "%' OR emp_id LIKE '%" + searchtext +
                   "%' OR emp_lastname LIKE '%" + searchtext +
                   "%' OR Department LIKE '%" + searchtext +
                   "%' OR Designation LIKE'%" + searchtext + "%'");
                if (dr.Count() > 0)
                {
                    gvEmployee.DataSource = dr.CopyToDataTable();
                    gvEmployee.DataBind();
                }
            }
        }
        catch (Exception)
        {

        }
    }
}