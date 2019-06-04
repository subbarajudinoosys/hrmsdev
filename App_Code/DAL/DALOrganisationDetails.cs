using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;
/// <summary>
/// Summary description for DALOrganisationDetails
/// </summary>
namespace DataManager
{
    public class DALOrganisationDetails : DataUtilities
{
    #region Local Variables
    #endregion

    #region database methods
    
    #region employee details
    public DataSet getOrganisationDetails(clsOrganisationDetails objclsOrgDetails)
          {
              Hashtable htparams = new Hashtable
              {
                  {"@in_oim_id",objclsOrgDetails.oim_id},
                  {"@in_oim_org_name",objclsOrgDetails.oim_org_name},
                  {"@in_oim_tax_id",objclsOrgDetails.oim_tax_id},
                  {"@in_oim_num_emp",objclsOrgDetails.oim_num_emp},
                  {"@in_oim_reg_num",objclsOrgDetails.oim_reg_num},
                  {"@in_oim_phone",objclsOrgDetails.oim_phone},
                  {"@in_oim_fax",objclsOrgDetails.oim_fax},
                  {"@in_oim_email",objclsOrgDetails.oim_email},
                  {"@in_oim_addr1",objclsOrgDetails.oim_addr1},
                  {"@in_oim_addr2",objclsOrgDetails.oim_addr2},
                  {"@in_oim_city",objclsOrgDetails.oim_city},
                  {"@in_oim_state",objclsOrgDetails.oim_state},
                  {"@in_oim_post_code",objclsOrgDetails.oim_post_code},
                  {"@in_oim_country",objclsOrgDetails.oim_country},
                  {"@in_oim_note",objclsOrgDetails.oim_note},
                  {"@in_OpName",objclsOrgDetails.OpName}
              };
              return ExecuteDataSet("org_info_insert_update", htparams);
          }

    public int Organisation_InsertUpdate(clsOrganisationDetails objclsOrgDetails)
    {
        Hashtable htparams = new Hashtable
              {
                  {"in_oim_id",objclsOrgDetails.oim_id},
                  {"in_oim_org_name",objclsOrgDetails.oim_org_name},
                  {"in_oim_tax_id",objclsOrgDetails.oim_tax_id},
                  {"in_oim_num_emp",objclsOrgDetails.oim_num_emp},
                  {"in_oim_reg_num",objclsOrgDetails.oim_reg_num},
                  {"in_oim_phone",objclsOrgDetails.oim_phone},
                  {"in_oim_fax",objclsOrgDetails.oim_fax},
                  {"in_oim_email",objclsOrgDetails.oim_email},
                  {"in_oim_addr1",objclsOrgDetails.oim_addr1},
                  {"in_oim_addr2",objclsOrgDetails.oim_addr2},
                  {"in_oim_city",objclsOrgDetails.oim_city},
                  {"in_oim_state",objclsOrgDetails.oim_state},
                  {"in_oim_post_code",objclsOrgDetails.oim_post_code},
                  {"in_oim_country",objclsOrgDetails.oim_country},
                  {"in_oim_note",objclsOrgDetails.oim_note},
                  {"in_OpName",objclsOrgDetails.OpName}
              };
        
        int IsSucess = ExecuteNonQuery("org_info_insert_update", htparams);
        
        return IsSucess;
    }
    public DataSet getcountry()
    {
        return ExecuteDataSet("country_master_get");
    }
    #endregion

    #endregion
}

}