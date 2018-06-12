namespace Ras.DAL.Entity
{
    public partial class GroupInfoTeachers
    {
        public int Id { get; set; }
        public int? ContributedHours { get; set; }
        public int Involved { get; set; }
        public int? AcademyId { get; set; }
        public int? EmployeeId { get; set; }
        public int? TeacherTypeId { get; set; }

        public Group Academy { get; set; }
        public Employee Employee { get; set; }
        public TeacherTypes TeacherType { get; set; }
    }
}
