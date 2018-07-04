﻿using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class Student
    {
        [Key]
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
        public int? GroupId { get; set; }
        public int? EmployeeId { get; set; }
        public int? EnglishLevelId { get; set; }
        public int? ExpertStudentFeedbackId { get; set; }
        public int? StudentStatusId { get; set; }
        public int? TeacherStudentFeedbackId { get; set; }
        public int? UserId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual EnglishLevel EnglishLevel { get; set; }
        public virtual Feedback ExpertStudentFeedback { get; set; }
        public virtual StudentStatus StudentStatus { get; set; }
        public virtual Feedback TeacherStudentFeedback { get; set; }
        public virtual User User { get; set; }
    }
}