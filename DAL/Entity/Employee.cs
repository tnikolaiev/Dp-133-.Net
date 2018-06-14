using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class Employee
    {
        public Employee()
        {
            GroupInfoTeachers = new HashSet<GroupInfoTeacher>();
            LoginUser = new HashSet<LoginUser>();
            Students = new HashSet<Student>();
        }

        [Key]
        public int EmployeeId { get; set; }

        public string FirstNameEng { get; set; }
        public string FirstNameUkr { get; set; }
        public string LastNameEng { get; set; }
        public string LastNameUkr { get; set; }
        public string SecondNameUkr { get; set; }

        public ICollection<GroupInfoTeacher> GroupInfoTeachers { get; set; }
        public ICollection<LoginUser> LoginUser { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}