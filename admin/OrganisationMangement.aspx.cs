﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_OrganisationMangement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void imgOrganisationInfo_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("OrganisationDetails.aspx", true);
    }
    protected void imgLocations_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("LocationDetails.aspx", true);
    }
}