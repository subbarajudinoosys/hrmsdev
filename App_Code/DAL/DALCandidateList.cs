using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;

/// <summary>
/// Summary description for DALCandidateList
/// </summary>
/// 
namespace DataManager
{
    public class DALCandidateList : DataUtilities
    {
        public DataSet GetCandidateList(clsCandidate objCandList)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"inCandidateId",objCandList.CandidateId},
                                                        {"inFirstName",objCandList.FirstName},
                                                        {"inLastName",objCandList.LastName},
                                                        {"inMiddleName",objCandList.MiddleName},
                                                        {"inEmailID",objCandList.EmailID},
                                                        {"inContactNo",objCandList.ContactNo},
                                                        {"inJobVacancy",objCandList.JobVacancy},
                                                        {"inKeyword",objCandList.Keyword},
                                                        {"inComments",objCandList.Comments},
                                                        {"inApplicationDate",objCandList.ApplicationDate},
                                                        {"inCanResumeUpload",objCandList.CanResumeUpload},
                                                        {"inCanResumeFilePath",objCandList.CanResumeFilePath},
                                                        {"in_OpName",objCandList.OpName},
                                                   };
            return ExecuteDataSet("candidate_insert_update", htparams);
        }
    }
}