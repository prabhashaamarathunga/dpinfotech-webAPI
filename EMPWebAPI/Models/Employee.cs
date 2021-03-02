using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMPWebAPI.Models
{
    public class Employee
    {
        public string Code { get; set; }
        public string Initials { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string EmpAddress { get; set; }
        public DateTime? DOB { get; set; }
        public string EmpStatus { get; set; }

    }
}