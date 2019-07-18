using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using EntityManager;
using DataManager;
using System.Data;
using System.IO;

public partial class admin_EmployeeDetails : System.Web.UI.Page
{
    DALCommon objcommon = new DALCommon();


    Employees _objEmp = new Employees();
    DOUtility objDOUti = new DOUtility();
    clsEmployee objclsEmployee = new clsEmployee();
    DALDesignation objDALDesg = new DALDesignation();
    EmpDesignation objEmDesg = new EmpDesignation();
    EmpDepartment objEmpDepart = new EmpDepartment();
    EmpLocation objEmpLoc = new EmpLocation();
    DALLocation objDALLoc = new DALLocation();
    DALDepartment objDALDep = new DALDepartment();
    public string ResumeFileName = string.Empty;
    public string ImageFileName = string.Empty;
    string AutoPassword = null;
    bool issuccess;



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDepratment();
            BindLocation();


            if (!string.IsNullOrEmpty(Request.QueryString["emp_id"]))
            {
                string EmployeeId = Request.QueryString["emp_id"].ToString();
                if (EmployeeId == "profile")
                {
                    GetEmployeeDetails(Convert.ToString(Session["userid"].ToString()));
                }
                else
                {
                    GetEmployeeDetails(Convert.ToString(EmployeeId));
                }
                btnSubmit.Text = "Update";
                imgphoto.Visible = true;
            }
            else
            {
                imgphoto.Visible = false;
            }
        }



    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        InsertUpdateEmployeeDetails();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeList.aspx", false);
    }

    #region PrivateMethods

    private string GetFile(FileUpload FUName)
    {
        string fileName = string.Empty;
        if (FUName.HasFile)
        {
            string strPath = System.IO.Path.GetExtension(FUName.PostedFile.FileName);
            string date = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            fileName = date + strPath;
            FUName.SaveAs(Server.MapPath("~/admin/ResumeDoc/" + fileName));
            //lblResume.Text = fuResumeImage.FileName;
        }
        return fileName;
    }
    private string GetImage(FileUpload FUImageName)
    {
        string fileName = string.Empty;
        if (FUImageName.HasFile)
        {
            string strPath = System.IO.Path.GetExtension(FUImageName.PostedFile.FileName);
            string date = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            fileName = date + strPath;
            FUImageName.SaveAs(Server.MapPath("~/admin/EmployeeImages/" + fileName));
            //lblImage.Text = fuImageFile.FileName;
            //imgphoto.ImageUrl = "EmployeeImages/" + fuImageFile.FileName;
            //imgphoto.Visible = true;
        }
        return fileName;
    }

    private void InsertUpdateEmployeeDetails()
    {
        try
        {
            string filepath = string.Empty;
            string Imagepath = string.Empty;
            if (Convert.ToInt32(hf_S_No.Value) > 0)
            {
                objclsEmployee.OpName = "UPDATE";
                objclsEmployee.empPWD = string.Empty;
                if (lblResume.Text!="" && fuResumeImage.HasFile==false)
                {
                    objclsEmployee.ResumeFilePath = lblResume.Text;
                    //lblResume.Text = fuResumeImage.FileName;
                }
                else
                {
                    if(this.fuResumeImage.FileName!="")
                    {
                        fuResumeImage.SaveAs(Server.MapPath("~/admin/ResumeDoc/" + this.fuResumeImage.FileName));
                        filepath = Path.GetFileName(this.fuResumeImage.PostedFile.FileName);
                        objclsEmployee.ResumeFilePath = "~/ResumeDoc/" + filepath;
                    }
                    //filepath = GetFile(fuResumeImage);
                    else
                    {
                        objclsEmployee.ResumeFilePath = "";
                    }
                }
      
                 if (lblImage.Text != "" && fuImageFile.HasFile == false)
                 {
                     objclsEmployee.ImageFilePath = lblImage.Text;
                 }             
                 else
                {
                    if (this.fuImageFile.FileName != "")
                    {
                        fuImageFile.SaveAs(Server.MapPath("~/EmployeeImages/" + this.fuImageFile.FileName));
                        Imagepath = Path.GetFileName(this.fuImageFile.PostedFile.FileName);
                        objclsEmployee.ImageFilePath = "~/EmployeeImages/" + Imagepath;
                    }
                    else
                    {
                        objclsEmployee.ImageFilePath = "";
                    }
                }

            }
        
            else
            {
                objclsEmployee.empPWD = Password();
                objclsEmployee.OpName = "INSERT";
                DataSet ds = objcommon.ValidMail(txtEmailId.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    labelError.Text = objDOUti.ShowMessage("danger", "Danger", "UserMail already exists");
                    return;
                }
                if (fuResumeImage.HasFile)
                {
                    filepath = GetFile(fuResumeImage);
                    objclsEmployee.ResumeUpload = lblResume.Text;// fuResumeImage.FileName;
                    objclsEmployee.ResumeFilePath = GetFile(fuResumeImage);
                    
                }
                    
                else
                {
                    lblResume.Text = "";
                }
                   


                if (fuImageFile.HasFile)
                {
                    Imagepath = GetImage(fuImageFile);
                    objclsEmployee.ImageUpload = lblImage.Text;
                    objclsEmployee.ImageFilePath = GetImage(fuImageFile);
                   
                }
                    
                else
                {
                    lblImage.Text = "";
                }
                   
            }
         
                objclsEmployee.EmpID = txtEmployeeID.Text;
                objclsEmployee.empFtName = txtFirstName.Text;
                objclsEmployee.empMName = txtMiddleName.Text;
                objclsEmployee.empLName = txtLastName.Text;
                objclsEmployee.empJOD = txtDateOfJoining.Text;
                objclsEmployee.empDOB = txtDateOfBirth.Text;
                objclsEmployee.empDepartment = ddlDepartment.SelectedValue;
                objclsEmployee.empDesignation = ddlDesignation.SelectedValue;
                objclsEmployee.LoginId = txtEmployeeID.Text;
                objclsEmployee.empMobile = txtMobileNo.Text;
                objclsEmployee.empEmail = txtEmailId.Text;
            //objclsEmployee.empManager = txtManager.Text;
                objclsEmployee.empStatus = Convert.ToInt32(ddlStatus.SelectedValue);
                objclsEmployee.empPanNo = txtPanNo.Text;
                objclsEmployee.empAdharNo = txtAdharNo.Text;
                objclsEmployee.empAddress = txtAddress.Text;
                objclsEmployee.emppassportno = txtPassportNo.Text;
                objclsEmployee.emppasexpirydate = txtExpiryDate.Text;
               
                objclsEmployee.emplocation = ddlLocation.SelectedValue;
              
                objclsEmployee.CreatedBy = 0;
                int Result = _objEmp.Employee_InsertUpdate(objclsEmployee);
            if (Result == 1)
            {
                bool status = MailSending(txtEmployeeID.Text, AutoPassword, txtEmailId.Text);
                labelError.Text = CommanClass.ShowMessage("success", "Success", "Employee details updated Successfully");
                clearcontrols();
                Response.Redirect("EmployeeList.aspx", true);
                Session["status"] = status;
            }
            else
            {
                //labelError.Text = CommanClass.ShowMessage("info", "Info", "Employee Details was not created plase try again");

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Employee already exists ');", true);
            }
        }

        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }

    }
    private string Password()
    {

        try
        {
            int PassLength = 8;
            string allowedChars = "";

            allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";

            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";

            allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";

            char[] sep = { ',' };

            string[] arr = allowedChars.Split(sep);

            string passwordString = "";

            string temp = "";

            Random rand = new Random();

            for (int i = 0; i < PassLength; i++)
            {

                temp = arr[rand.Next(0, arr.Length)];

                passwordString += temp;

            }
            AutoPassword = passwordString;
            string EncryptedPass = objDOUti.Encrypts(passwordString, true);
            return EncryptedPass;

        }
        catch (Exception)
        {

            throw;
        }

    }



    private bool MailSending(string EmpID, string Password, string MailId)
    {

        try
        {
            string SmtpServer;
            int SmtpPort;
            string MailFrom;
            string DisplayNameFrom;
            string FromPassword = "";
            string MailTo;
            string DisplayNameTo;
            string MailCc = "subbaraju.vetukuri@gmail.com";
            string DisplayNameCc = "";
            string MailBcc = "";
            string Subject = "Invitation";
            string Attachment = "";
            string MailCc2 = "";
            string MailCc3 = "";


            //string name = Session["firstname"].ToString() + " " + Session["lastname"].ToString();

            // string leavedate = "Leave Date" + " : " + "From Date: " + fromdate + "&nbsp;&nbsp; To Date: " + todate;
            string MailText = "URL: " + "http://hrmsdev.dinoosystech.com/login.aspx " + "<br/>" + "LoginID:  " + EmpID + "<br/>" + "Password: " + Password + "<br/> " + "To change password please visit this URL" + "http://hrmsdev.dinoosystech.com/admin/ChangePassword.aspx";

            // MailCc2 = "subbaraju.vetukuri@gmail.com";


            SmtpServer = "smtp.gmail.com";
            SmtpPort = 25;
            MailFrom = "testingformail12@gmail.com";
            // MailFrom = "anmishakalidindi2851995@gmail.com";
            DisplayNameFrom = "Dinoosys Technologies";
            FromPassword = "testing123";
            //FromPassword = "anmisha143";
            //MailTo = Session["Email"].ToString();
            MailTo = MailId;


            DisplayNameTo = "";


            if (CommanClass.SendEmail(SmtpServer, SmtpPort, MailFrom, DisplayNameFrom, FromPassword, MailTo, DisplayNameTo, MailCc, MailCc2, MailCc3, DisplayNameCc, MailBcc, Subject, MailText, Attachment))
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Mail send successfully !!');", true);
                // ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage('Mail send successfully !!');", true);
                issuccess = true;
            }



            //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage();", true);  


            else
            {
                issuccess = false;
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Mail was not send please contact your admin!!');", true);
            }
            return issuccess;
        }
        catch (Exception)
        {

            throw;
        }
    }

    private void GetEmployeeDetails(string EmployeeId)
    {
        try
        {
            objclsEmployee.EmpID = EmployeeId;
            objclsEmployee.OpName = "SELECT1";
            DataSet Objds = _objEmp.GetEmployeeDetails(objclsEmployee);

            if (Objds.Tables[0].Rows.Count > 0)
            {
                hf_S_No.Value = Objds.Tables[0].Rows[0]["S_No"].ToString();
                txtEmployeeID.Text = Objds.Tables[0].Rows[0]["emp_id"].ToString();
                txtEmployeeID.Enabled = false;
                txtFirstName.Text = Objds.Tables[0].Rows[0]["emp_firstname"].ToString();
                txtMiddleName.Text = Objds.Tables[0].Rows[0]["emp_middlename"].ToString();
                txtLastName.Text = Objds.Tables[0].Rows[0]["emp_lastname"].ToString();
                txtDateOfJoining.Text = Objds.Tables[0].Rows[0]["emp_doj"].ToString();
                txtDateOfJoining.ReadOnly = true;
                txtDateOfBirth.Text = Objds.Tables[0].Rows[0]["emp_dob"].ToString();
                txtDateOfBirth.ReadOnly = true;
                ddlDepartment.SelectedIndex = ddlDepartment.Items.IndexOf(ddlDepartment.Items.FindByValue(Objds.Tables[0].Rows[0]["emp_dept"].ToString()));
                get_Depart_Desig(ddlDepartment, ddlDesignation);
                ddlDesignation.SelectedIndex = ddlDesignation.Items.IndexOf(ddlDesignation.Items.FindByValue(Objds.Tables[0].Rows[0]["emp_design"].ToString()));

                // ddlDepartment.SelectedIndex = ddlDepartment.Items.IndexOf(ddlDepartment.Items.FindByValue(Objds.Tables[0].Rows[0]["emp_design"].ToString()));

                //txtLoginId.Text = Objds.Tables[0].Rows[0]["emp_login"].ToString();
                //txtPassword.Text = Objds.Tables[0].Rows[0]["emp_pwd"].ToString();
                txtMobileNo.Text = Objds.Tables[0].Rows[0]["emp_mobile"].ToString();
                txtEmailId.Text = Objds.Tables[0].Rows[0]["emp_email"].ToString();
                txtEmailId.ReadOnly = true;
                //txtManager.Text = Objds.Tables[0].Rows[0]["emp_mgr"].ToString();
                //txtManager.Enabled = false;
                ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(Objds.Tables[0].Rows[0]["emp_status"].ToString()));
                txtPanNo.Text = Objds.Tables[0].Rows[0]["emp_panno"].ToString();
                txtAdharNo.Text = Objds.Tables[0].Rows[0]["emp_adharno"].ToString();
                txtAddress.Text = Objds.Tables[0].Rows[0]["emp_address"].ToString();
                txtPassportNo.Text = Objds.Tables[0].Rows[0]["emp_passportno"].ToString();
                txtExpiryDate.Text = Objds.Tables[0].Rows[0]["emp_pasexpirydate"].ToString();
                Panel1.Visible = false;
                //lblResume.Text = Objds.Tables[0].Rows[0]["ResumeUpload"].ToString();
                hfResumeFileName.Value = Objds.Tables[0].Rows[0]["ResumeFilePath"].ToString();
                //revfuResumeImage.Enabled = false;
                ddlLocation.SelectedIndex = ddlLocation.Items.IndexOf(ddlLocation.Items.FindByValue(Objds.Tables[0].Rows[0]["emp_location"].ToString()));
                ResumeFileName = Objds.Tables[0].Rows[0]["ResumeFilePath"].ToString();
                pdfView.Attributes["href"] = "ResumeDoc/" + ResumeFileName;
                lblResume.Text = Objds.Tables[0].Rows[0]["ResumeFilePath"].ToString();
                hf_ImageFile.Value = Objds.Tables[0].Rows[0]["ImageFilePath"].ToString();
                ImageFileName = Objds.Tables[0].Rows[0]["ImageFilePath"].ToString();
                imgphoto.ImageUrl = "EmployeeImages/" + ImageFileName;
                //imgphoto.ImageUrl = "EmployeeImages/" + fuImageFile.FileName;
                imgphoto.Visible = true;
                lblImage.Text = Objds.Tables[0].Rows[0]["ImageFilePath"].ToString();
           }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }
    #endregion PrivateMethods

    void clearcontrols()
    {
        txtEmployeeID.Text = "";
        txtDateOfJoining.Text = "";
        txtFirstName.Text = "";
        txtMiddleName.Text = "";
        txtLastName.Text = "";
        txtDateOfBirth.Text = "";
        txtMobileNo.Text = "";
        txtEmailId.Text = "";
        ddlDesignation.SelectedIndex = -1;
        ddlDepartment.SelectedIndex = -1;
        ddlStatus.SelectedIndex = -1;
        //txtManager.Text = "";
        txtPanNo.Text = "";
        txtAdharNo.Text = "";
        txtAddress.Text = "";
        txtPassportNo.Text = "";
        txtExpiryDate.Text = "";
        //txtLoginId.Text = "";
        //txtPassword.Text = "";
        lblResume.Text = "";
        ddlLocation.SelectedIndex = -1;

    }

    public static void get_Depart_Desig(DropDownList ddlDepartment, DropDownList ddlDesignation)
    {
        ddlDesignation.Items.Clear();

        DALDesignation objDALDesg = new DALDesignation();
        EmpDesignation objEmDesg = new EmpDesignation();

        DataSet ds = new DataSet();
        objEmDesg.DepartmentId = ddlDepartment.SelectedValue.ToString();
        ds = objDALDesg.GetDesigDetails(objEmDesg);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlDesignation.DataSource = ds.Tables[0];
            ddlDesignation.Items.Clear();
            ddlDesignation.Items.Add(new ListItem("-Select-", "-1"));
            ddlDesignation.DataTextField = "Designation";
            ddlDesignation.DataValueField = "Designation_Id";
            ddlDesignation.DataBind();


        }
        else
        {
            ddlDesignation.DataSource = null;
            ddlDesignation.DataBind();
        }


    }

    private void BindDepratment()
    {
        try
        {

            DataSet ds = new DataSet();
            ds = objDALDep.GetDepartDetails(objEmpDepart);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDepartment.DataSource = ds.Tables[0];
                ddlDepartment.DataTextField = "Department";
                ddlDepartment.DataValueField = "Department_Id";
                ddlDepartment.DataBind();
            }
            else
            {
                ddlDepartment.DataSource = null;
                ddlDepartment.DataBind();
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }


    void BindLocation()
    {
        try
        {


            DataSet ds = new DataSet();
            ds = objDALLoc.Get_Location(objEmpLoc);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLocation.DataSource = ds.Tables[0];
                ddlLocation.DataTextField = "Location";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataBind();
            }
            else
            {
                ddlLocation.DataSource = null;
                ddlLocation.DataBind();
            }
        }
        catch (Exception ex)
        {
            labelError.Text = CommanClass.ShowMessage("danger", "Danger", ex.Message);
        }
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        get_Depart_Desig(ddlDepartment, ddlDesignation);
    }


   

    //protected void txtEmailId_TextChanged1(object sender, EventArgs e)
    //{
    //    //int result = objcommon.ValidMail(txtEmailId.Text);
    //    //if (result > 0)
    //    //{
    //    //    labelError.Text = objDOUti.ShowMessage("danger", "Danger", "Mail Already exixts");
    //    //}
    //    DataSet ds = objcommon.ValidMail(txtEmailId.Text);
    //    if(ds.Tables[0].Rows.Count>0)
    //    {
    //        labelError.Text = objDOUti.ShowMessage("danger", "Danger", "Mail Already exists");
    //    }
    //    else
    //    {

    //    }

    
}

