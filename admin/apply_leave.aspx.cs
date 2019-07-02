using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

using DataManager;
using EntityManager;
public partial class admin_holiday_list : System.Web.UI.Page
{
    DALApplyLeave objDal = new DALApplyLeave();
    ClsLeaveType objLeave = new ClsLeaveType();
    DALLeaveTypes objDALLeaveType = new DALLeaveTypes();
    string Emp_id = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindLeaveType();
            try
            {
                if (Session["userid"].ToString() == null || Session["userid"].ToString() == "")
                {
                    Response.Redirect("../login.aspx", false);
                }
                else
                {
                    int Emp_Id = Convert.ToInt32(Session["userid"].ToString());
                    ViewState["ps"] = 5;
                    Bing_Leaves(Emp_Id);
                    hf_Emp_id.Value = Emp_Id.ToString();
                }

                txtCalYear.Text = DateTime.Now.Year.ToString();
            }
            catch
            {
                Response.Redirect("../login.aspx", false);
            }
        }
    }



    private void Bing_Leaves(int emp_Id)
    {
        try
        {
            DataSet ds = objDal.Get_Leaves_By_Emp(emp_Id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvRemainingLeaves.DataSource = ds.Tables[0];
               
                gvRemainingLeaves.DataBind();
            }
            else
            {
                gvRemainingLeaves.DataSource = null;
                gvRemainingLeaves.DataBind();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                gvLeaveList.DataSource = ds.Tables[1];
                Session["dt"] = ds.Tables[1];
                gvLeaveList.DataBind();
            }
            else
            {
                gvLeaveList.DataSource = null;
                gvLeaveList.DataBind();
            }
            gvLeaveList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            
        }
        catch
        {

        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        divApplyleave.Visible = true;
        divbtn.Visible = false;
    }


    protected void cmdSave_Click(object sender, EventArgs e)
    {
        Apply_Leave_Insert_Update();
    }

    private void Apply_Leave_Insert_Update()
    {
        try
        {
            DateTime D1 = DateTime.ParseExact(txtToDate.Text, "yyyy-MM-dd", null);
            DateTime D2 = DateTime.ParseExact(txtFromDate.Text, "yyyy-MM-dd", null);


            TimeSpan ts = D1 - D2;
            TimeSpan time1 = TimeSpan.FromDays(1);
            ts = ts.Add(time1);

            ApplyLeaveEntity _objEntity = new ApplyLeaveEntity
            {
                leave_id = Convert.ToInt32(hf_id.Value.ToString()),
                emp_id = Convert.ToInt32(hf_Emp_id.Value.ToString()),
                //emp_id = Emp_id, 
                to_date = txtToDate.Text.Trim(),
                from_date = txtFromDate.Text.Trim(),
                calender_year = txtCalYear.Text.Trim(),
                no_of_days = ts.Days.ToString(),
                leave_type = dropleaveType.SelectedValue.Trim(),
                reason = txtReason.Text.Trim(),
                CreatedBy = hf_Emp_id.Value.ToString()
            };

            int IsSuccess = objDal.Apply_Leave_Insert_Update(_objEntity);
            if (IsSuccess > 0)
            {
                lblMsg.Text = CommanClass.ShowMessage("success", "Success", "Leave applyed successfully !!");
                SendMail(txtReason.Text, txtFromDate.Text, txtToDate.Text);
                Clear_text();
            }
            else
            {
                lblMsg.Text = CommanClass.ShowMessage("info", "Info", "Leave was applyed please try again!!");
            }
            Bing_Leaves(Convert.ToInt32(hf_Emp_id.Value.ToString()));
        }

        catch (Exception ex)
        {
            lblMsg.Text = CommanClass.ShowMessage("danger", "Error", ex.Message);
        }
    }

    private void Clear_text()
    {
        txtFromDate.Text = "";
        txtReason.Text = "";
        dropleaveType.SelectedIndex = -1;
        txtToDate.Text = "";
    }

    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        divbtn.Visible = true;
        divApplyleave.Visible = false;
    }
    protected void gvLeaveList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLeaveList.PageIndex = e.NewPageIndex;
        Bing_Leaves(Convert.ToInt32(hf_Emp_id.Value.ToString()));

    }


    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bing_Leaves(Convert.ToInt32(hf_Emp_id.Value.ToString()));
    }


    public void SendMail(string reason, string fromdate, string todate)
    {
        string SmtpServer;
        int SmtpPort;
        string MailFrom;
        string DisplayNameFrom;
        string FromPassword;
        string MailTo;
        string DisplayNameTo;
        string MailCc = "";
        string DisplayNameCc = "";
        string MailBcc = "";
        string Subject = "Leave Request";
        string Attachment = "";
        string MailCc2 = "";
        string MailCc3 = "";

        string name = Session["firstname"].ToString() + " " + Session["lastname"].ToString();

        string leavedate = "Leave Date" +  " : " + "From Date: " + fromdate + "&nbsp;&nbsp; To Date: " + todate;
        string MailText = "Hi Team," + "<br/><br/>" + leavedate + "<br/>"+ "Reason:  "  + reason + "<br/><br/>" + "Thank you," + "<br/>" + name;

       // MailCc2 = "subbaraju.vetukuri@gmail.com";
        //MailCc3 = "budagavichandra@gmail.com";

        SmtpServer = "smtp.gmail.com";
        SmtpPort = 587;
       // MailFrom = "testingformail12@gmail.com";
        MailFrom = "tejuindukuri@gmail.com";
        DisplayNameFrom = "Dinoosys Technologies";
       // FromPassword = "testing123";
        FromPassword = "btechcompleted";
        //MailTo = Session["Email"].ToString();
        MailTo = "sriprathyusha1997@gmail.com";

        DisplayNameTo = name;


        if (CommanClass.SendEmail(SmtpServer, SmtpPort, MailFrom, DisplayNameFrom, FromPassword, MailTo, DisplayNameTo, MailCc,MailCc2,MailCc3, DisplayNameCc, MailBcc, Subject, MailText, Attachment))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Mail send successfully !!');", true);
        }

        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Mail was not send please contact your admin!!');", true);
        }

    }

    private void BindLeaveType()
    {
        try
        {

            DataSet ds = new DataSet();
            ds = objDALLeaveType.GetApplyLeaveTypes(objLeave);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dropleaveType.DataSource = ds.Tables[0];
                dropleaveType.DataTextField = "LeaveType";
                dropleaveType.DataValueField = "LeaveTypeId";
                dropleaveType.DataBind();
            }
            else
            {
                dropleaveType.DataSource = null;
                dropleaveType.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }


    protected void imgsearch_Click(object sender, ImageClickEventArgs e)
    {
        SearchItemfromList(txtSearch.Text.Trim());
    }
    void SearchItemfromList(string searchtext)
    {
        try
        {
            if (Session["dt"] != null)
            {
                DataTable dt = (DataTable)Session["dt"];
                DataRow[] dr = dt.Select("LeaveType LIKE '%" + searchtext +
                    "' OR reason LIKE '%" + searchtext +
                   
                   "%'");
                if (dr.Count() > 0)
                {
                    gvLeaveList.DataSource = dr.CopyToDataTable();
                    gvLeaveList.DataBind();
                }
            }
        }
        catch (Exception)
        {

        }

    }
}