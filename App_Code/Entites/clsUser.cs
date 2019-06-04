using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsUser
/// </summary>
/// 
namespace EntityManager
{
    public class clsUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string EmployeeName { get; set; }
        public string Status { get; set; }
        public string OpName { get; set; }
    }
}