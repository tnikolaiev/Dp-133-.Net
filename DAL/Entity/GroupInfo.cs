namespace Ras.DAL.Entity
{
    public partial class GroupInfo
    {
        public int GroupInfoId { get; set; }
        public string GroupName { get; set; }
        public int StudentsPlannedToEnrollment { get; set; }
        public int StudentsPlannedToGraduate { get; set; }
        public int AcademyId { get; set; }
        public int? ProfileId { get; set; }

        public Group Academy { get; set; }
        public ProfileInfo Profile { get; set; }
    }
}
