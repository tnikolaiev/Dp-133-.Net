namespace Ras.DAL.Entity
{
    public partial class Students
    {
        public int Id { get; set; }
        public double? EngGram { get; set; }
        public double? EntryScore { get; set; }
        public double? ExpertScore { get; set; }
        public double? FinalBase { get; set; }
        public double? FinalLang { get; set; }
        public int? IncomingTest { get; set; }
        public double? IntermTestBase { get; set; }
        public double? IntermTestLang { get; set; }
        public string InterviewerComment { get; set; }
        public double? InterviewerScore { get; set; }
        public short? Removed { get; set; }
        public double? TeacherScore { get; set; }
        public double? Test8 { get; set; }
        public double? Test5 { get; set; }
        public double? Test4 { get; set; }
        public double? Test9 { get; set; }
        public double? Test1 { get; set; }
        public double? Test7 { get; set; }
        public double? Test6 { get; set; }
        public double? Test10 { get; set; }
        public double? Test3 { get; set; }
        public double? Test2 { get; set; }
        public int? AcademyId { get; set; }
        public int? EmployeeId { get; set; }
        public int? EnglishLevelId { get; set; }
        public int? ExpertStudentFeedbackId { get; set; }
        public int? StudentStatusId { get; set; }
        public int? TeacherStudentFeedbackId { get; set; }
        public int? UserId { get; set; }

        public Group Academy { get; set; }
        public Employee Employee { get; set; }
        public EnglishLevel EnglishLevel { get; set; }
        public Feedback ExpertStudentFeedback { get; set; }
        public StudentStatuses StudentStatus { get; set; }
        public Feedback TeacherStudentFeedback { get; set; }
        public User User { get; set; }
    }
}
