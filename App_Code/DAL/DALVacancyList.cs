using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityManager;
using System.Data;
using System.Collections;


namespace DataManager
{
    public class DALVacancyList : DataUtilities
    {
      public DataSet GetVacancyList(clsVacancy objVacancyList)
        {
          Hashtable htparams=new Hashtable
                                       {
                                                        {"invacancyId",objVacancyList.vacancyId},
                                                        {"inJobTitle",objVacancyList.JobTitle},
                                                        {"inVacancyName",objVacancyList.VacancyName},
                                                        {"inHiringManager",objVacancyList.HiringManager},
                                                        {"inNoOfPositions",objVacancyList.NoOfPositions},
                                                        {"inDescription",objVacancyList.Description},
                                                        {"inActive",objVacancyList.Active},
                                                        {"inActiveText",objVacancyList.ActiveText},
                                                        {"inUserDefinedFlag",objVacancyList.UserDefinedFlag},
                                                        {"inUserDefinedText",objVacancyList.UserDefinedText},
                                                        {"inUserDefinedFlag1",objVacancyList.UserDefinedFlag1},
                                                        {"inUserDefinedText1",objVacancyList.UserDefinedText1},
                                                        {"inUserDefinedFlag2",objVacancyList.UserDefinedFlag2},
                                                        {"inUserDefinedText2",objVacancyList.UserDefinedText2},
                                                        {"inUserDefinedFlag3",objVacancyList.UserDefinedFlag3},
                                                        {"inUserDefinedText3",objVacancyList.UserDefinedText3},
                                                        {"in_OpName",objVacancyList.OpName},
                                       };
          return ExecuteDataSet("vacancy_insert_update", htparams);
        }
    }
}