using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;

namespace DataManager
{
    /// <summary>
    /// Summary description for DALLocationList
    /// </summary>
    public class DALLocationList : DataUtilities
    {
        public DataSet GetLocationList(EmpLocation objLocList)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                        {"inLocationId",objLocList.LocationId},
                                                        {"inLocation",objLocList.Location},  
                                                        {"inCompanyCode",objLocList.CompanyCode},
                                                        {"inCountry",objLocList.Country},
                                                        {"inState",objLocList.State},
                                                        {"inCity",objLocList.City},
                                                        {"inAddress",objLocList.Address},
                                                        {"inPostalCode",objLocList.PostalCode},
                                                        {"inPhone",objLocList.Phone},
                                                        {"inFax",objLocList.Fax},
                                                        {"inNotes",objLocList.Notes},
                                                        {"in_OpName",objLocList.OpName},
                                                        
                                     };

            return ExecuteDataSet("LocationDetails", htParams);
        }
    }
}