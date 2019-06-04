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
        //    if (Session["status"].ToString() != null || Session["status"].ToString() != "")
        //    {
        //        string status = string.IsNullOrEmpty(Session["status"].ToString()) ? "" : Session["status"].ToString();
        //        //string status=ViewState["issuccess"].ToString();
        //        if (status == "True")
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Mail has sent successfully to Employee');", true);
        //        }
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Mail was not send');", true);
        //    }
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


          //  Response.Redirect("EmpBankDetails.aspx?empbd_id=" + EmployeebdId);

        }

        if (e.CommandName == "EditEduDetails")
         {
             string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
             string emp_id = commandArgs[0];
             string emp_firstnam = commandArgs[1];
             Response.Redirect(String.Format("EmpEducationDetails.aspx?emp_id={0}&emp_firstnam={1}", emp_id, emp_firstnam));

           // Response.Redirect("EmpEducationDetails.aspx?Edu_Id=" + EmployeeEduId);

        }

        if (e.CommandName == "EditExeDetails")
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string emp_id = commandArgs[0];
            string emp_firstnam = commandArgs[1];
            Response.Redirect(String.Format("EmpExpDetails.aspx?emp_id={0}&emp_firstnam={1}", emp_id, emp_firstnam));
          //  Response.Redirect("EmpExpDetails.aspx?Exp_id=" + EmployeeExeId);
        }
        if (e.CommandName == "EditFamilyDetails")
        {
            //string Emp_Id = e.CommandArgument.ToString();
           // string emp_firstnam =e.CommandArgument.ToString();
            //Session["EmpID"]=ds.Tables[]
          //  Response.Redirect("EmpFamilyDetails.aspx?Emp_id=" + Emp_Id);
           // Response.Redirect(String.Format("EmpFamilyDetails.aspx?Emp_id={0}&emp_firstnam={1}", Emp_Id,emp_firstnam));

            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string emp_id = commandArgs[0];
            string emp_firstnam=commandArgs[1];

            Response.Redirect(String.Format("EmpFamilyDetails.aspx?emp_id={0}&emp_firstnam={1}", emp_id, emp_firstnam));
        }
    }



    protected void gvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
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
             ds = _ObjEmpList.GetEmpList(ObjEmpList);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvEmployee.DataSource = ds;
               
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
}