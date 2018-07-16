using Ras.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ras.BLL.DTO
{
    public class EmployeeDTO
    {
        public EmployeeDTO(Employee employee, GroupInfoTeacher teacher)
        {
            EmployeeId = employee.EmployeeId;
            FirstNameUkr = employee.FirstNameUkr;
            LastNameUkr = employee.LastNameUkr;
            FirstNameEng = employee.FirstNameEng;
            LastNameEng = employee.LastNameEng;

            GroupId = (int)teacher.AcademyId;
            Involved = teacher.Involved;
            TeacherTypeId = (int) teacher.TeacherTypeId;
        }

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
