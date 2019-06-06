using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataManager
{
    public class DALCommon:DataUtilities
    {
        public DataSet UserLogIn(string UserId)
        {
            Hashtable hst=new Hashtable
                               {
                                   {"in_username",UserId},
                                   //{"in_password",Pwd}
                               };
            return ExecuteDataSet("user_login", hst);
        }


        public DataSet ForgotPassword(string emailid)
        {
            Hashtable htparam = new Hashtable
            {
                {"inemailid",emailid},
            };
            return ExecuteDataSet("forgot_password", htparam);
        }

    }
}