using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsOrganisationDetails
/// </summary>
namespace EntityManager
{
    public class clsOrganisationDetails
    {
        public int oim_id { set; get; }
        public string oim_org_name { set; get; }
        public string oim_tax_id { set; get; }
        public int oim_num_emp { set; get; }
        public string oim_reg_num { set; get; }
        public string oim_phone { set; get; }
        public string oim_fax { set; get; }
        public string oim_email { set; get; }
        public string oim_addr1 { set; get; }
        public string oim_addr2 { set; get; }
        public string oim_city { set; get; }
        public string oim_state { set; get; }
        public string oim_post_code { set; get; }
        public string oim_country { set; get; }
        public string oim_note { set; get; }
        public string OpName { get; set; }

      
    }

}