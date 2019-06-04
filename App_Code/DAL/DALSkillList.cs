using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;
/// <summary>
/// Summary description for DALSkillList
/// </summary>
/// 

namespace DataManager 
{
    public class DALSkillList : DataUtilities
    {

        public DataSet GetSkillList(clsSkillDetails objclsSkillDetails) 
        {

            Hashtable htparams = new Hashtable
            {
                 {"inSkillId",objclsSkillDetails.skillid},
                 {"inRoleName",objclsSkillDetails.rollname},
                 {"inSkillDetails",objclsSkillDetails.skilldetails},                                                                                                              
                 {"in_Opname",objclsSkillDetails.OpName},
            };
            return ExecuteDataSet("skill_insert_update", htparams);
        }




    }



}