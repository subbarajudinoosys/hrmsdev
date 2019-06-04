using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
using DataManager;


/// <summary>
/// Summary description for DALWorkShift
/// </summary>
/// 
namespace DataManager
{
    public class DALWorkShift : DataUtilities
    {
        public DataSet GetWorkShift(clsWorkShift objWorkShift)
        {
            Hashtable htparams = new Hashtable
                                                   {
                                                        {"inShiftId",objWorkShift.ShiftId},
                                                        {"inShiftName",objWorkShift.ShiftName},
                                                        {"inFromDate",objWorkShift.FromDate},
                                                        {"inToDate",objWorkShift.ToDate},
                                                        {"inDuration",objWorkShift.Duration},
                                                        {"inOpName",objWorkShift.OpName},
                                                        
                                                        
                                                   };
            return ExecuteDataSet("workshift_insert_update", htparams);
        }

        public int InsertUpdateWorkShift(clsWorkShift objWorkShift)
        {

            Hashtable htParams = new Hashtable
                                                   {
                                                        {"inShiftId",objWorkShift.ShiftId},
                                                        {"inShiftName",objWorkShift.ShiftName},
                                                        {"inFromDate",objWorkShift.FromDate},
                                                        {"inToDate",objWorkShift.ToDate},
                                                        {"inDuration",objWorkShift.Duration},
                                                        {"inOpName",objWorkShift.OpName},
                                                        
                                                        
                                                   };
            return ExecuteNonQuery("workshift_insert_update", htParams);
        }
    }
}