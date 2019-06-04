using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsVacancy
/// </summary>
/// 
namespace EntityManager
{
    public class clsVacancy
    {
        public int vacancyId { get; set; }
        public string JobTitle { get; set; }
        public string VacancyName { get; set; }
        public string HiringManager { get; set; }
        public string NoOfPositions { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public string ActiveText { get; set; }
        public int UserDefinedFlag { get; set; }
        public string UserDefinedText { get; set; }
        public int UserDefinedFlag1 { get; set; }
        public string UserDefinedText1 { get; set; }
        public int UserDefinedFlag2 { get; set; }
        public string UserDefinedText2 { get; set; }
        public int UserDefinedFlag3 { get; set; }
        public string UserDefinedText3 { get; set; }
        public string OpName { get; set; }

        public int TitleId { get; set; }
        public string JobTitleName { get; set; }
    }
}