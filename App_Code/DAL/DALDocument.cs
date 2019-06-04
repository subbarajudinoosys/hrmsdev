using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using EntityManager;
using DataManager;

/// <summary>
/// Summary description for DALDocument
/// </summary>
/// 
namespace DataManager
{
    public class DALDocument : DataUtilities
    {
        public int InsertUpdateDoc(clsDocumentUpload objDocUpload)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                       {"inDocumentId",objDocUpload.DocumentId},
                                                       {"inUploadFile",objDocUpload.UploadFile},
                                                       {"inFilePath",objDocUpload.FilePath},
                                                       {"inComments",objDocUpload.Comments},                                                     
                                                       {"in_Opname",objDocUpload.OpName},
                                                        
                                     };
            return ExecuteNonQuery("documents_insert_update", htParams);
        }

        public DataSet GetDocument(clsDocumentUpload objDocUpload)
        {
            Hashtable htParams = new Hashtable
                                     {
                                                      
                                                       {"inDocumentId",objDocUpload.DocumentId},
                                                       {"inUploadFile",objDocUpload.UploadFile},
                                                       {"inFilePath",objDocUpload.FilePath},
                                                       {"inComments",objDocUpload.Comments},                                                     
                                                       {"in_Opnames",objDocUpload.OpName},
                                                        
                                     };
            return ExecuteDataSet("documents_insert_update", htParams);
        }

    }
}