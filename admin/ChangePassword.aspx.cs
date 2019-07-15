using DataManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ChangePassword : System.Web.UI.Page
{
    DALCommon objcommon = new DALCommon();
    DOUtility objutility = new DOUtility();
    string emp_id = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        emp_id = Request.QueryString["key"].ToString();
        if (!IsPostBack)
        {

        }
    }
    protected void confirm_Click(object sender, EventArgs e)
    {
        try
        {
            int i = objcommon.ChangePassword(objutility.Decrypts(emp_id, true), objutility.Encrypts(txtnewpass.Text, true));

            //int i = objcommon.ChangePassword();
            if (i > 0)
            {
                string Url = ConfigurationManager.AppSettings["redirectURL"];
                Response.Write("<script language='javascript'>window.alert('Password Updated Successfully');window.location='"+Url+"login.aspx';</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Updation Failed');</script>");
            }
        }
        catch(Exception ex)
        {

        }

    }

    public string Encrypts(string toEncrypt, bool useHashing)
    {
        byte[] keyArray;
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
        // Get the key from config file
        string key = "hrms_test";
        //System.Windows.Forms.MessageBox.Show(key);
        if (useHashing)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
        }
        else
            keyArray = UTF8Encoding.UTF8.GetBytes(key);

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateEncryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        tdes.Clear();
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        string ResultString = string.Empty;
        try
        {
            byte[] encData_byte = new byte[toEncrypt.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(toEncrypt);
            ResultString = Convert.ToBase64String(encData_byte);
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to encrypt.");
        }
        return ResultString;
    }
    
}





  
