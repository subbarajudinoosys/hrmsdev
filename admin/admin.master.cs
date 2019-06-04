using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataManager;


public partial class admin_admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["userid"].ToString() == null || Session["userid"].ToString() == "")
            {
                Response.Redirect("../login.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {
                    lblusername.Text = Session["firstname"].ToString().Trim() + " " + Session["lastname"].ToString().Trim() + "(" + Session["designation"].ToString().Trim() + ")";
                    string s = Session["firstname"].ToString();
                    GetMenu();
                    GetTitle();
                }
            }
        }
        catch
        {
            Response.Redirect("../login.aspx", false);
        }
    }

    private void GetTitle()
    {
        string PageName = HttpContext.Current.Request.Url.AbsolutePath.Substring(HttpContext.Current.Request.Url.AbsolutePath.LastIndexOf('/') + 1);
        string strTitel = CommanClass.GetPageTitle(PageName);
        Page.Title = strTitel;
        lblTitle.Text = strTitel;

    }

    private void GetMenu()
    {
        DALMenu ObjDALMenu = new DALMenu();
        string strMenu = string.Empty;
        int RoleId = Convert.ToInt32(Session["RoleId"]);

        DataSet objdsmenu = ObjDALMenu.Get_Menu(RoleId);
        if (objdsmenu.Tables[0].Rows.Count > 0)
        {
            strMenu = " <ul class='nav' id='side-menu'>";

            foreach (DataRow mainItem in objdsmenu.Tables[0].Rows)
            {
                if (mainItem["MenuName"].ToString() == "Dashboard" || mainItem["MenuName"].ToString() == "Go For Bookings" || mainItem["MenuName"].ToString() == "View Latest File")
                {
                    strMenu += "<li class='active'><a href=" + mainItem["Url"].ToString() + "><i class='fa fa-dashboard fa-fw'></i>" + mainItem["MenuName"].ToString() + "<span class='fa arrow'></span>" + "</a>";
                }
                else
                {
                    strMenu += "<li><a href='#'>" + mainItem["MenuIcon"].ToString() + " " + mainItem["MenuName"].ToString() + "<span class='fa arrow'></span>" + "</a>";
                }
                DataRow[] lstSubMenu;
                lstSubMenu = objdsmenu.Tables[1].Select("ParentMenuId='" + mainItem["MenuId"] + "'");

                if (lstSubMenu.Length > 0)
                {
                    strMenu += "<ul class='nav nav-second-level'>";
                    foreach (var subMenuItem in lstSubMenu)
                    {
                        strMenu += "<li><a href=" + subMenuItem["Url"].ToString() + ">" + subMenuItem["MenuName"].ToString() + "</a></li>";
                    }
                    strMenu += "</ul>";
                }

                strMenu += "</li>";
            }
            strMenu += "</ul>";
        }
        sidebar.InnerHtml = strMenu;
    }
}