using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmpLocation
/// </summary>
/// 

namespace EntityManager
{


    public class EmpLocation
    {
        public int LocationId { get; set; }
        public string Location { get; set; }
        public string CompanyCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Notes { get; set; }
        public string OpName { get; set; }
        
    }
}