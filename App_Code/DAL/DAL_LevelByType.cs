using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityManager;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for DAL_LevelByType
/// </summary>
namespace DataManager
{
    public class DAL_LevelByType:DataUtilities
    {
        public DataSet GetLevelByType(int Edu_id)
        {
            Hashtable htparams = new Hashtable
            {
                {"@EduType_id",Edu_id},
                //{"@EduType_Name",objEmpEdu.EduType_Name}
            };
            return ExecuteDataSet("Education_Levelbytype", htparams);
        }
    }
}