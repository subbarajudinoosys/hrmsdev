using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsDocumentUpload
/// </summary>
/// 
namespace EntityManager
{
    public class clsDocumentUpload
    {
        public int DocumentId { get; set; }
        public string UploadFile { get; set; }
        public string FilePath { get; set; }
        public string Comments { get; set; }
        public string OpName { get; set; }
    }
}