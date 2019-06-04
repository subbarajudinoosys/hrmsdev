using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
using DataManager;
/// <summary>
/// Summary description for DALEmpTrackers
/// </summary>
/// 
namespace DataManager
{
    public class DALEmpTrackers : DataUtilities
    {
        public int InsertEmpTracker(clsEmpTrackers objTracker)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                        {"inTrackerId",objTracker.TrackerId},
                                                        {"inTrackerName",objTracker.TrackerName},
                                                         {"inEmpId",objTracker.EmpId},
                                                        {"inEmployeeName",objTracker.EmployeeName},                                                        
                                                        {"inAssignedReviewers",objTracker.AssignedReviewers},
                                                        {"inAvailableReviewers",objTracker.AvailableReviewers},
                                                        {"in_OpName",objTracker.OpName},
                                                        
                                     };
            return ExecuteNonQuery("emp_trackers_insertupdate", htParams);
        }

        public DataSet GetEmpTracker(clsEmpTrackers objTracker)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                        {"inTrackerId",objTracker.TrackerId},
                                                        {"inTrackerName",objTracker.TrackerName},
                                                        {"inEmpId",objTracker.EmpId},
                                                        {"inEmployeeName",objTracker.EmployeeName},                                                        
                                                        {"inAssignedReviewers",objTracker.AssignedReviewers},
                                                        {"inAvailableReviewers",objTracker.AvailableReviewers},
                                                        {"in_OpName",objTracker.OpName},
                                                        
                                     };

            return ExecuteDataSet("emp_trackers_insertupdate", htParams);
        }


        public int DeleteTracker(int TrackerId)
        {
            Hashtable htParams = new Hashtable
                                     {
                                         {"inTrackerId",TrackerId},
                                     };
            return ExecuteNonQuery("deleteTracker", htParams);
        }
    }
}