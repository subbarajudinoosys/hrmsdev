using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;

/// <summary>
/// Summary description for DALCandidate
/// </summary>
/// 
namespace DataManager
{
    public class DALCandidate : DataUtilities
    {
        public DataSet GetCandidateDetails(clsCandidate objCandidate)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                         {"inCandidateId",objCandidate.CandidateId},
                                                        {"inFirstName",objCandidate.FirstName},
                                                        {"inLastName",objCandidate.LastName},
                                                        {"inMiddleName",objCandidate.MiddleName},
                                                        {"inEmailID",objCandidate.EmailID},
                                                        {"inContactNo",objCandidate.ContactNo},
                                                        {"inJobVacancy",objCandidate.JobVacancy},
                                                        {"inKeyword",objCandidate.Keyword},
                                                        {"inComments",objCandidate.Comments},
                                                        {"inApplicationDate",objCandidate.ApplicationDate},
                                                        {"inCanResumeUpload",objCandidate.CanResumeUpload},
                                                        {"inCanResumeFilePath",objCandidate.CanResumeFilePath},
                                                        {"in_OpName",objCandidate.OpName},
                                                   };
            return ExecuteDataSet("candidate_insert_update", htparams);
        }


            public int InsertCandidateDetails(clsCandidate objCandidate)
            {
                 Hashtable htparams = new Hashtable
                                                   {
                                                        {"inCandidateId",objCandidate.CandidateId},
                                                        {"inFirstName",objCandidate.FirstName},
                                                        {"inLastName",objCandidate.LastName},
                                                        {"inMiddleName",objCandidate.MiddleName},
                                                        {"inEmailID",objCandidate.EmailID},
                                                        {"inContactNo",objCandidate.ContactNo},
                                                        {"inJobVacancy",objCandidate.JobVacancy},
                                                        {"inKeyword",objCandidate.Keyword},
                                                        {"inComments",objCandidate.Comments},
                                                        {"inApplicationDate",objCandidate.ApplicationDate},
                                                        {"inCanResumeUpload",objCandidate.CanResumeUpload},
                                                        {"inCanResumeFilePath",objCandidate.CanResumeFilePath},
                                                        {"in_OpName",objCandidate.OpName},
                                                   };
                return ExecuteNonQuery("candidate_insert_update", htparams);
            }
        public int DeleteCandidate(int Can_Id)
            {
                Hashtable hst = new Hashtable{
                {"@CandidateId",Can_Id}
            };
                return ExecuteNonQuery("Delete_Candidate", hst);
            }
    }
}