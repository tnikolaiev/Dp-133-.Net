using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ras.Web.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstNameUkr { get; set; }
        public string LastNameUkr { get; set; }
        public string FirstNameEng { get; set; }
        public string LastNameEng { get; set; }

        public int GroupId { get; set; }
        public int Involved { get; set; }
        public int TeacherTypeId { get; set; }
    }
}
