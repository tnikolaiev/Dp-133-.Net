using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class GroupInfoTeacher
    {
        [Key]
        public int Id { get; set; }

        public int? ContributedHours { get; set; }
        public int Involved { get; set; }
        public int? AcademyId { get; set; }
        public int? EmployeeId { get; set; }
        public int? TeacherTypeId { get; set; }

        public virtual Group Academy { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual TeacherType TeacherType { get; set; }
    }
}