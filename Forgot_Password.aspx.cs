using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataManager;
using System.Net.Mail;
using System.Globalization;
using System.Configuration;

public partial class Forgot_Password : System.Web.UI.Page
{
    DOUtility objDOUty = new DOUtility();
    string emp_id = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }
    
    protected void btnForgot_Click(object sender, EventArgs e)
    {
        try
        {
            DALCommon ojbDALLogin = new DALCommon();
            DataSet ds = ojbDALLogin.ForgotPassword(txtemailId.Text);
            if (ds.Tables.Count >= 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //DataSet ds = objBALUsers.GetConfig();
                    //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    //{

                    //Session["mailEmpId"] = ds.Tables[0].Rows[0]["emp_id"].ToString();
                    string emp_id=ds.Tables[0].Rows[0]["emp_id"].ToString();
                    string SmtpServer = "smtp.gmail.com";
                    int SmtpPort = 25;
                    // string SmtpServer = "";
                    //int SmtpPort = Convert.ToInt32(ds.Tables[0].Rows[0]["con_smtp_port"].ToString());
                    string MailFrom = "testingformail12@gmail.com";
                    string DisplayNameFrom = "HRMS";
                    string FromPassword = "testing123";
                    string MailTo = txtemailId.Text.Trim();
                    string DisplayNameTo = string.Empty;
                    string MailCc = "mounikadandu35@gmail.com";
                    string DisplayNameCc = string.Empty;
                    string MailBcc = string.Empty;
                    string Subject = "HRMS";
                    string body = "/admin//ChangePassword.aspx";
                    string MailText;
                    string Attachment = string.Empty;
                    string Password=ds.Tables[0].Rows[0][0].ToString().Trim();
                    MailCc = string.Empty;
                    string Url = ConfigurationManager.AppSettings["redirectURL"];
                    
                    MailText = "<table align='center' border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse; width: 100%; max-width: 600px;' class='content'>"
                    + "<tr>"
                    + "<td style='padding: 15px 10px 15px 10px;'>"
                    + "<table border='0' cellpadding='0' cellspacing='0' width='100%'>"
                        + " </table>"
                     + "</td>"
                 + "</tr>"
                 + "<tr>"
                   + "  <td align='center' bgcolor='#a1c3da' style='padding: 25px 20px 25px 20px; color: #ffffff; back font-family: Arial, sans-serif; font-size: 36px; font-weight: bold;height:113px !important;'>"
                      + "   <img src='images/logo-dinoosys.png' alt='HRMS DINOOSYS' width='260' height='110' style='display:block;' />"
                    + " </td>"
               + "  </tr>"
               + "  <tr>"
                    + " <td align='center' bgcolor='#ffffff' style='padding: 75px 20px 40px 20px; color: #555555; font-family: Arial, sans-serif; font-size: 20px; line-height: 30px; border-bottom: 1px solid #f6f6f6;'>"
                    + "     <b>You Credentials is </b><br/>"
                        //+ "    and One Of The Advisor We Will Contact To You."
                     + "Login Id : " + ds.Tables[0].Rows[0][1].ToString().Trim() + "<br/>" + " Password: " + objDOUty.Decrypts( Password,true)
                     + "<br/> To change password click <a href='" + Url + "admin/ChangePassword.aspx?test=" + objDOUty.Encrypts(emp_id, true) + "'target='_blank'>here</a>"
                    + " </td>"
                 + "</tr>"
                + " <tr>"
                   //+ "  <td align='center' bgcolor='#f9f9f9' style='padding: 30px 20px 30px 20px; font-family: Arial, sans-serif;'>"
                    //+ "     <table bgcolor='#1ABC9C' border='0' cellspacing='0' cellpadding='0' class='buttonwrapper'>"
                          + "   <tr>"
                            //+ "     <td align='center' height='50' style=' padding: 0 25px 0 25px; font-family: Arial, sans-serif; font-size: 16px; font-weight: bold; background-color: #bd1f2d;' class='button'>"
                                   
                              + "   </td>"
                          + "   </tr>"
                       + "  </table>"
                   + "  </td>"
               + "  </tr>"
               + "   <tr>"
                        //+ "     <td align='center' bgcolor='#dddddd' style='padding: 15px 10px 15px 10px; color: #555555; font-family: Arial, sans-serif; font-size: 12px; line-height: 18px;'>"
                        //  + "       <b>HRMS.</b><br/>38 Jonsson Ln, Durban Central, Durban, 4001, South Africa"
                        // + "    </td>"
               + "   </tr>"
            + " </table>";

                    SendMail(SmtpServer, SmtpPort, MailFrom, DisplayNameFrom, FromPassword, MailTo, DisplayNameTo, MailCc, "","", "", DisplayNameCc,"", Subject,MailText, Attachment,body);

                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Please check your mail ');", true);
                   txtemailId.Text = "";

                }
                else
                {
                    lblerror.Text = "Email ID Not Exists";
                }
            }
            else
            {


            }

        }
        catch
        {

        }
        finally
        {
        }

    }




    public static bool SendMail(string SmtpHost, int SmtpPort, string MailFrom, string DisplayNameFrom, string FromPassword, string MailTo, string DisplayNameTo, string MailCc, string mailCc2, string mailCc3, string mailCc4, string DisplayNameCc, string MailBcc, string Subject, string MailText, string Attachment ,string body)
    {

        MailMessage myMessage = new MailMessage();
        
        bool IsSucces = false;
        
        try
        {
            myMessage.From = new MailAddress(MailFrom, DisplayNameFrom);
            if (MailTo != "")
                myMessage.To.Add(new MailAddress(MailTo, DisplayNameTo));
            if (MailCc != "")
                myMessage.CC.Add(new MailAddress(MailCc, DisplayNameCc));
            if (mailCc2 != "")
                myMessage.CC.Add(new MailAddress(mailCc2, DisplayNameCc));
            if (mailCc3 != "")
                myMessage.CC.Add(new MailAddress(mailCc3, DisplayNameCc));
            if (mailCc4 != "")
                myMessage.CC.Add(new MailAddress(mailCc4, DisplayNameCc));

            if (MailBcc != "")
                myMessage.Bcc.Add(MailBcc);

            myMessage.Subject = Subject;
            myMessage.IsBodyHtml = true;
            myMessage.Body = MailText;

            //create Alrternative HTML view
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(MailText, null, "text/html");



            //Add view to the Email Message
            myMessage.AlternateViews.Add(htmlView);

            if (Attachment != "")
            {
                Attachment a = new Attachment(Attachment);
                myMessage.Attachments.Add(a);
            }
            SmtpClient mySmtpClient = new SmtpClient(SmtpHost, SmtpPort);
            mySmtpClient.Credentials = new System.Net.NetworkCredential(MailFrom, FromPassword);
            mySmtpClient.EnableSsl = true;
            mySmtpClient.Send(myMessage);
            IsSucces = true;
        }
        catch
        {
            IsSucces = false;
        }
        finally
        {
            myMessage = null;
        }
        return IsSucces;

    }


}
