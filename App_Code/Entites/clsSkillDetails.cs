using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsSkillDetails
/// </summary>
/// 
namespace EntityManager
{
    public class clsSkillDetails
    {
        public int skillid { get; set; }
        public string Name { get; set; }

        public string rollname { get; set; }

        public string skilldetails { get; set; }

        public string OpName { get; set; }

        public int CreatedBy { get; set; }
    }
}