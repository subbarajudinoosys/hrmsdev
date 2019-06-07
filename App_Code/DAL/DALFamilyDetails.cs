using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityManager;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for DALFamilyDetails
/// </summary>
/// 
namespace DataManager
{
    public class DALFamilyDetails : DataUtilities

    {
       public DataSet GetFamilyDetails(EmpFamilyDetails objFamily)
        {
            Hashtable htparams = new Hashtable{
                                           {"inS_No",objFamily.S_No},
                                           {"inEmp_id",objFamily.Emp_id},
                                           {"inRelationship",objFamily.Relationship},
                                           {"inLastName",objFamily.LastName},
                                           {"inFirstName",objFamily.FirstName},
                                           {"inAge",objFamily.Age},
                                           {"inEmploymentstatus",objFamily.Employmentstatus},
                                            {"inIsActive",objFamily.IsActive},
                                           {"in_OpName",objFamily.OpName},



                                           };
            return ExecuteDataSet("EmpFamilydetails", htparams);
        }

        public int InsertFamilyDetails(EmpFamilyDetails objFamily)
       {
            Hashtable htparams=new Hashtable{
                                           //{"inS_No",objFamily.S_No},
                                           {"inEmp_id",objFamily.Emp_id},
                                           {"inRelationship",objFamily.Relationship},
                                           {"inLastName",objFamily.LastName},
                                           {"inFirstName",objFamily.FirstName},
                                           {"inAge",objFamily.Age},
                                           {"inEmploymentstatus",objFamily.Employmentstatus},
                                           {"inIsActive",objFamily.IsActive},
                                           
                                           {"in_OpName",objFamily.OpName},
                                            };

        
            return ExecuteNonQuery("EmpFamilydetails", htparams);
       }

        public int DeleteFamDetails(int S_No,string Emp_id)
        {
            Hashtable htparams=new Hashtable{
                                            {"inS_No",S_No},
                                            {"inEmp_id",Emp_id}
                                            };

            return ExecuteNonQuery("delete_familyDetails", htparams);

        }
    }
}