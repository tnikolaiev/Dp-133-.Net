using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class Employee
    {
        public Employee()
        {
            GroupInfoTeachers = new HashSet<GroupInfoTeachers>();
            LoginUser = new HashSet<LoginUser>();
            Students = new HashSet<Students>();
        }

        public int EmployeeId { get; set; }
        public string FirstNameEng { get; set; }
        public string FirstNameUkr { get; set; }
        public string LastNameEng { get; set; }
        public string LastNameUkr { get; set; }
        public string SecondNameUkr { get; set; }

        public ICollection<GroupInfoTeachers> GroupInfoTeachers { get; set; }
        public ICollection<LoginUser> LoginUser { get; set; }
        public ICollection<Students> Students { get; set; }
    }
}
