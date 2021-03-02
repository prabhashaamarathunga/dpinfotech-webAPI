using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMPWebAPI.Models
{
    public class EmployeeFamily
    {
        public string Code { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string EmpRelation { get; set; }
    }
}