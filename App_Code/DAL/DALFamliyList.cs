using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
/// <summary>

/// <summary>
/// Summary description for DALFamliyList
/// </summary>
/// 
namespace DataManager
{
    public class DALFamliyList : DataUtilities
    {
       public DataSet GetFamilyList(EmpFamilyDetails objFamilyList)
        {
            Hashtable htparams = new Hashtable{
                                           {"inS_No",objFamilyList.S_No},
                                           {"inEmp_id",objFamilyList.Emp_id},
                                           {"inRelationship",objFamilyList.Relationship},
                                           {"inLastName",objFamilyList.LastName},
                                           {"inFirstName",objFamilyList.FirstName},
                                           {"inAge",objFamilyList.Age},
                                           {"inEmploymentstatus",objFamilyList.Employmentstatus},
                                           {"inIsActive",objFamilyList.IsActive},
                                           {"in_OpName",objFamilyList.OpName},
           };
            return ExecuteDataSet("EmpFamilydetails", htparams);
        }
    }
}