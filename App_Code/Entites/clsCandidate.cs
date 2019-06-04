using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsCandidate
/// </summary>
/// 
namespace EntityManager
{
    public class clsCandidate
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string EmailID { get; set; }
        public string ContactNo { get; set; }
        public string JobVacancy { get; set; }
        public string Keyword { get; set; }
        public string Comments { get; set; }
        public string ApplicationDate { get; set; }
        public string CanResumeUpload { get; set; }
        public string CanResumeFilePath { get; set; }
        public string OpName { get; set; }
    }
}