using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using EntityManager;

/// <summary>
/// Summary description for DALDocumentList
/// </summary>
/// 
namespace DataManager
{
    public class DALDocumentList : DataUtilities
    {
        public DataSet GetLocationList(clsDocumentUpload objDocList)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                        {"inDocumentId",objDocList.DocumentId},
                                                        {"inUploadFile",objDocList.UploadFile},  
                                                        {"inFilePath",objDocList.FilePath},
                                                        {"inComments",objDocList.Comments},
                                                        {"in_OpName",objDocList.OpName},
                                                        
                                     };

            return ExecuteDataSet("documents_insert_update", htParams);
        }
    }
}