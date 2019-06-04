using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataManager;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["userid"] = "";
            Session["firstname"] = "";
            Session["lastname"] = "";
            Session["designation"] = "";
            Session["RoleId"] = "";
            Session["Email"] = "";
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            DALCommon ojbDALLogin = new DALCommon();
            DataSet ds = ojbDALLogin.UserLogIn(txtuserId.Text, txtPassword.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["userid"] = ds.Tables[0].Rows[0]["emp_id"].ToString();
                Session["firstname"] = ds.Tables[0].Rows[0]["emp_firstname"].ToString();
                Session["lastname"] = ds.Tables[0].Rows[0]["emp_lastname"].ToString();
                Session["designation"] = ds.Tables[0].Rows[0]["Designation"].ToString();
                Session["RoleId"] = ds.Tables[0].Rows[0]["RoleId"].ToString();
                Session["Email"] = ds.Tables[0].Rows[0]["emp_email"].ToString();
                 //Server.Execute("/admin/index.aspx");

                Response.Redirect("/admin/index.aspx",false);

            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Invalid User Credentials !!');", true);
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("login.aspx", false);
        }
    }
    
   
}