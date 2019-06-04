using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;


namespace DataManager
{
    public class DALPassport : DataUtilities
    {

        public int Passport_insertUpdate(PassportDetails objPassportDetails)   
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"inPassportId",objPassportDetails.passportid},
                                                        {"inEmployeeName",objPassportDetails.EmployeeName},
                                                        {"inPasportNumber",objPassportDetails.PassportNumber},
                                                        {"inPassportIssuedate",objPassportDetails.PassportIssueDate},
                                                        {"inPassportExpiryDate",objPassportDetails.PassportEXpiryDate},
                                                        {"inPanNumber",objPassportDetails.Pannumber},
                                                        {"inAdharNumber",objPassportDetails.Adharnumber},                                                       
                                                        {"inImageUpload",objPassportDetails.ImageUpload},
                                                        {"inImageFilePath",objPassportDetails.ImageFilePath},
                                                        {"in_OpName",objPassportDetails.OpName},
                                                   };
            return ExecuteNonQuery("Passport_insert_update", htparams);
        }


        public DataSet GetPassportDetails(PassportDetails objPassportDetails) 
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                       {"inPassportId",objPassportDetails.passportid},
                                                        {"inEmployeeName",objPassportDetails.EmployeeName},
                                                        {"inPasportNumber",objPassportDetails.PassportNumber},
                                                        {"inPassportIssuedate",objPassportDetails.PassportIssueDate},
                                                        {"inPassportExpiryDate",objPassportDetails.PassportEXpiryDate},
                                                        {"inPanNumber",objPassportDetails.Pannumber},
                                                        {"inAdharNumber",objPassportDetails.Adharnumber},                                                       
                                                        {"inImageUpload",objPassportDetails.ImageUpload},
                                                        {"inImageFilePath",objPassportDetails.ImageFilePath},
                                                        {"in_OpName",objPassportDetails.OpName},
                                                   };
            return ExecuteDataSet("Passport_insert_update", htparams);
        }

    }
}