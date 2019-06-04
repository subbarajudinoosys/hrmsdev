using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;

namespace DataManager
{
    public class DALSkillDetail : DataUtilities
    {
        public int Skill_insertUpdate(clsSkillDetails objclsSkillDetails) 
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                         {"inSkillId",objclsSkillDetails.skillid},
                                                         {"inRoleName",objclsSkillDetails.rollname},
                                                         {"inSkillDetails",objclsSkillDetails.skilldetails},                                                                                                              
                                                         {"in_Opname",objclsSkillDetails.OpName},
                                                   };
            return ExecuteNonQuery("skill_insert_update", htparams);
        }

        public DataSet GetSkillDetails(clsSkillDetails objclsSkillDetails) 
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