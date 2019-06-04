using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

namespace DataManager
{
    public class DALMenu : DataUtilities
    {
        public DataSet Get_Menu(int role_id)
        {
            Hashtable hstable = new Hashtable
                                    {
                                       {"in_role_id",role_id}   
                                    };
            DataSet ds = ExecuteDataSet("get_menus", hstable);
            return ds;
        }
    }
}