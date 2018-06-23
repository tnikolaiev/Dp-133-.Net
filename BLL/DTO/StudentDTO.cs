using System;
using System.Collections.Generic;
using Ras.DAL.Entity;

namespace Ras.BLL.DTO
{
    public class StudentDTO
    {
        public StudentDTO() { }
        public StudentDTO(Student dStudent)
        {
            Id = dStudent.Id;
            UserDTO = new UserDTO(dStudent.User);
            GroupId = dStudent.Group.Id;

            var tests = new List<double?>
            {
                dStudent.Test1,
                dStudent.Test2,
                dStudent.Test3,
                dStudent.Test4,
                dStudent.Test5,
                dStudent.Test6,
                dStudent.Test7,
                dStudent.Test8,
                dStudent.Test9,
                dStudent.Test10
            };

            Tests = tests;
            FinalBase = dStudent.FinalBase;
            FinalLang = dStudent.FinalLang;
            IncomingTest = dStudent.IncomingTest;
            IntermTestBase = dStudent.IntermTestBase;
            IntermTestLang = dStudent.IntermTestLang;
            InterviewerScore = dStudent.InterviewerScore;
            TeacherScore = dStudent.TeacherScore;
            InterviewerComment = dStudent.InterviewerComment;
            EnglishGrammar = dStudent.EngGram;
            EntryScore = dStudent.EntryScore;
            ExpertScore = dStudent.ExpertScore;
            EmployeeId = dStudent.EmployeeId;
            if (dStudent.UserId == null)
            {
                throw new ArgumentException("UserId can not be null");
            }

            UserId = (int) dStudent.UserId;
            ExpertFeedbackDTO = dStudent.ExpertStudentFeedback is null ? new FeedbackDTO() : new FeedbackDTO(dStudent.ExpertStudentFeedback);
            TeacherFeedbackDTO = dStudent.TeacherStudentFeedback is null ? new FeedbackDTO() : new FeedbackDTO(dStudent.TeacherStudentFeedback);
            EnglishLevel = dStudent.EnglishLevel?.Name;
            StudentStatus = dStudent.StudentStatus?.Name;
        }

        public int Id { get; set; }
        public UserDTO UserDTO { get; set; }
        public int GroupId { get; set; }
        public List<double?> Tests { get; set; }
        public double? FinalBase { get; set; }
        public double? FinalLang { get; set; }
        public double? IncomingTest { get; set; }
        public double? IntermTestBase { get; set; }
        public double? IntermTestLang { get; set; }
        public double? InterviewerScore { get; set; }
        public double? TeacherScore { get; set; }
        public string InterviewerComment { get; set; }
        public double? EnglishGrammar { get; set; }
        public double? EntryScore { get; set; }
        public double? ExpertScore { get; set; }
        public int? EmployeeId { get; set; }
        public int UserId { get; set; }
        public FeedbackDTO ExpertFeedbackDTO { get; set; }
        public FeedbackDTO TeacherFeedbackDTO { get; set; }
        public string EnglishLevel { get; set; }
        public string StudentStatus { get; set; }
    }
}