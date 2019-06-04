using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using DataManager;
using System.Web.UI.WebControls;
using System.Net.Mail;

public class CommanClass
{
    public static string ShowMessage(string sOperation, string TitleMessage, string sMessage)
    {
        StringBuilder sbMessage = new StringBuilder();
        sbMessage.Append(" <div class='alert alert-" + sOperation + " fade in'>");
        sbMessage.Append("<a href='#' class='close' data-dismiss='alert'>&times;</a>   <strong>" + TitleMessage + "! </strong>" + sMessage + "</div>");
        return sbMessage.ToString();
    }

    public static string Get_year(DropDownList ddl_year)
    {
        ddl_year.Items.Clear();
        ddl_year.Items.Add(new ListItem("-Select-", "-1"));
        int yr = DateTime.Now.Year;
        int year_back = DateTime.Now.Year - 100;
        while (yr > year_back)
        {
            string year = yr.ToString();
            ddl_year.Items.Add(new ListItem(year, year));
            yr--;
        }

        return yr.ToString();
    }

    public static string Get_Month(string Mnt)
    {
        switch (Mnt)
        {
            case "1": Mnt = "January"; break;
            case "2": Mnt = "February"; break;
            case "3": Mnt = "March"; break;
            case "4": Mnt = "April"; break;
            case "5": Mnt = "May"; break;
            case "6": Mnt = "June"; break;
            case "7": Mnt = "July"; break;
            case "8": Mnt = "August"; break;
            case "9": Mnt = "September"; break;
            case "10": Mnt = "October"; break;
            case "11": Mnt = "November"; break;
            case "12": Mnt = "December"; break;
        }
        return Mnt;
    }

    public static string GetPageTitle(string PageName)
    {

        switch (PageName)
        {
            #region
            case "EmployeeDetails.aspx":

                return "Employee Details";
            case "EmployeeList.aspx":

                return "Employee List" + " > " + "<a href='EmployeeDetails.aspx' style='font-size: 15px;'> Add</a>";

            case "EmpBankDetails.aspx":

                return "Employee Bank Details";

            case "EmpExpDetails.aspx":

                return "Employee Experience Details";

            case "EmpDepartment.aspx":

                return "Employee Department Details";

            case "EmpDesignation.aspx":

                return "Employee Designation Details";

            case "EmpEducationDetails.aspx":

                return "Employee Education Details";

            case "EmpFamilyDetails.aspx":

                return "Employee Family Details";

            case "LocationDetails.aspx":

                return "Location Details";
            case "employeePaySlipList.aspx":

                return "PaySlip List";

            case "EmployeePaymentVoucher.aspx":
                return "Payment Voucher";

            case "apply_leave.aspx":
                return "Apply Leave";


            case "EmployeePaySlip.aspx":
                return "Payslip Details";

            case "CandidateDetails.aspx":
                return "Candidate Details";

            case "DocumentDetails.aspx":
                return "Document Details";

            case "EmployeeGrid.aspx":
                return "Employee Details";

            case "PayGradeDetails.aspx":
                return "PayGrade Details";

            case "PaymentVoucherList.aspx":
                return "Payment Voucher List" + " > " + "<a href='EmployeePaymentVoucher.aspx' style='font-size: 15px;'> Add</a>";

            case "UserDetails.aspx":
                return "User Details";

            case "VacancyDetails.aspx":
                return "Vacancy Details";

            case "WorkShiftDetails.aspx":
                return "Work Shift Details";

            case "OrganisationDetails.aspx":
                return "Organisation Details";

            case "OrganisationMangement.aspx":
                return "Organisation Management";

            case "JobManagement.aspx":
                return "Job Management";

            case "QualificationManagement.aspx":
                return "Qualification Management";

            case "UserManagement.aspx":
                return "User Management";

            case "OtherDetails.aspx":
                return "Other Details";

            case "LeaveTypes.aspx":
                return "Leave Types";

            case "ConfigureManagement.aspx":
                return "Configure Management";

            case "EmployeeKeyPerformance.aspx":
                return "Employee KeyPerformance";

            case "EmpTrackers.aspx":
                return "Employee Trackers";


            #endregion


            default:

                return "Home";
        }
    }



    public static bool SendEmail(string SmtpHost, int SmtpPort, string MailFrom, string DisplayNameFrom, string FromPassword, string MailTo, string DisplayNameTo, string MailCc, string MailCc2, string MailCc3, string DisplayNameCc, string MailBcc, string Subject, string MailText, string Attachment)
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
            if (MailCc2 != "")
                myMessage.CC.Add(new MailAddress(MailCc2, DisplayNameCc));
            if (MailCc3 != "")
                myMessage.CC.Add(new MailAddress(MailCc3, DisplayNameCc));

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