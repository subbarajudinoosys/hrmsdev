using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;

/// <summary>
/// Summary description for DALVacancy
/// </summary>
/// 
namespace DataManager
{
    public class DALVacancy : DataUtilities
    {
        public DataSet GetVacancyDetails(clsVacancy objclVacancy)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                       {"invacancyId",objclVacancy.vacancyId},
                                                        {"inJobTitle",objclVacancy.JobTitle},
                                                        {"inVacancyName",objclVacancy.VacancyName},
                                                        {"inHiringManager",objclVacancy.HiringManager},
                                                        {"inNoOfPositions",objclVacancy.NoOfPositions},
                                                        {"inDescription",objclVacancy.Description},
                                                        {"inActive",objclVacancy.Active},
                                                        {"inActiveText",objclVacancy.ActiveText},
                                                        {"inUserDefinedFlag",objclVacancy.UserDefinedFlag},
                                                        {"inUserDefinedText",objclVacancy.UserDefinedText},
                                                        {"inUserDefinedFlag1",objclVacancy.UserDefinedFlag1},
                                                        {"inUserDefinedText1",objclVacancy.UserDefinedText1},
                                                        {"inUserDefinedFlag2",objclVacancy.UserDefinedFlag2},
                                                        {"inUserDefinedText2",objclVacancy.UserDefinedText2},
                                                        {"inUserDefinedFlag3",objclVacancy.UserDefinedFlag3},
                                                        {"inUserDefinedText3",objclVacancy.UserDefinedText3},
                                                        {"in_OpName",objclVacancy.OpName},
                                                   };
            return ExecuteDataSet("vacancy_insert_update", htparams);
        }


        public int InsertVacancyDetails(clsVacancy objclVacancy)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"invacancyId",objclVacancy.vacancyId},
                                                        {"inJobTitle",objclVacancy.JobTitle},
                                                        {"inVacancyName",objclVacancy.VacancyName},
                                                        {"inHiringManager",objclVacancy.HiringManager},
                                                        {"inNoOfPositions",objclVacancy.NoOfPositions},
                                                        {"inDescription",objclVacancy.Description},                                                        
                                                        {"inActive",objclVacancy.Active},
                                                        {"inActiveText",objclVacancy.ActiveText},
                                                        {"inUserDefinedFlag",objclVacancy.UserDefinedFlag},
                                                        {"inUserDefinedText",objclVacancy.UserDefinedText},
                                                        {"inUserDefinedFlag1",objclVacancy.UserDefinedFlag1},
                                                        {"inUserDefinedText1",objclVacancy.UserDefinedText1},
                                                        {"inUserDefinedFlag2",objclVacancy.UserDefinedFlag2},
                                                        {"inUserDefinedText2",objclVacancy.UserDefinedText2},
                                                        {"inUserDefinedFlag3",objclVacancy.UserDefinedFlag3},
                                                        {"inUserDefinedText3",objclVacancy.UserDefinedText3},
                                                        {"in_OpName",objclVacancy.OpName},
                                                   };
            return ExecuteNonQuery("vacancy_insert_update", htparams);
        }

        public DataSet GetVacancy(clsVacancy objclVacancy)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"invacancyId",objclVacancy.vacancyId},
                                                        {"inVacancyName",objclVacancy.VacancyName},
                                                        
                                                   };
            return ExecuteDataSet("get_vacancy", htparams);
        }
        public int DeleteVacancyDetails(int Vac_Id)
        {
            Hashtable htvd = new Hashtable{
            {"@vacancyId",Vac_Id}

            };
            return ExecuteNonQuery("Vacancy_Delete", htvd);
        }
    }
}