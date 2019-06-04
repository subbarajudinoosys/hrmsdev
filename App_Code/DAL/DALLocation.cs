using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
using DataManager;

/// <summary>
/// Summary description for DALLocation
/// </summary>
/// 
namespace DataManager
{
    public class DALLocation : DataUtilities
    {
        public int InsertLocation(EmpLocation objEmpLoc)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                        {"inLocationId",objEmpLoc.LocationId},
                                                        {"inLocation",objEmpLoc.Location},   
                                                        {"inCompanyCode",objEmpLoc.CompanyCode},
                                                        {"inCountry",objEmpLoc.Country},
                                                        {"inState",objEmpLoc.State},
                                                        {"inCity",objEmpLoc.City},
                                                        {"inAddress",objEmpLoc.Address},
                                                        {"inPostalCode",objEmpLoc.PostalCode},
                                                        {"inPhone",objEmpLoc.Phone},
                                                        {"inFax",objEmpLoc.Fax},
                                                        {"inNotes",objEmpLoc.Notes},
                                                        {"in_OpName",objEmpLoc.OpName},
                                                        
                                     };
            return ExecuteNonQuery("LocationDetails", htParams);
        }

        public DataSet GetLocation(EmpLocation objEmpLoc)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                        {"inLocationId",objEmpLoc.LocationId},
                                                        {"inLocation",objEmpLoc.Location},  
                                                        {"inCompanyCode",objEmpLoc.CompanyCode},                                                       
                                                        {"inCountry",objEmpLoc.Country},
                                                        {"inState",objEmpLoc.State},
                                                        {"inCity",objEmpLoc.City},
                                                        {"inAddress",objEmpLoc.Address},
                                                        {"inPostalCode",objEmpLoc.PostalCode},
                                                        {"inPhone",objEmpLoc.Phone},
                                                        {"inFax",objEmpLoc.Fax},
                                                        {"inNotes",objEmpLoc.Notes},
                                                        {"in_OpName",objEmpLoc.OpName},
                                                        
                                     };

            return ExecuteDataSet("LocationDetails", htParams);
        }

        public int DeleteLocation(int LocationId)
        {
            Hashtable htParams = new Hashtable
                                     {
                                         {"inLocationId",LocationId},
                                     };
            return ExecuteNonQuery("LocationDetails_Delete", htParams);
        }

        public DataSet Get_Location(EmpLocation objEmpLoc)
        {
            //Hashtable htParams = new Hashtable
            //                         {
            //                                            {"inLocationId",objEmpLoc.LocationId},
            //                                            {"inLocation",objEmpLoc.Location},   
            //                                            {"inCompanyCode",objEmpLoc.CompanyCode},
            //                                            {"inCountry",objEmpLoc.Country},
            //                                            {"inState",objEmpLoc.State},
            //                                            {"inCity",objEmpLoc.City},
            //                                            {"inAddress",objEmpLoc.Address},
            //                                            {"inPostalCode",objEmpLoc.PostalCode},
            //                                            {"inPhone",objEmpLoc.Phone},
            //                                            {"inFax",objEmpLoc.Fax},
            //                                            {"inNotes",objEmpLoc.Notes},
                                                        
                                                        
            //                         };

            return ExecuteDataSet("get_Location");
        }
        public DataSet getcountry()
        {
            return ExecuteDataSet("country_master_get");
        }
    }
}