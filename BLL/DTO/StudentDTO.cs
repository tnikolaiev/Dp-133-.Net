using System;
using System.Collections.Generic;
using System.Text;

namespace Ras.BLL.DTO
{
    class StudentDTO
    {
        public int Id { get; set; }
        public UserDTO UserDTO { get; set; }
        public int GroupId { get; set; }
        public List<double> Tests { get; set; }
        public double FinalBase { get; set; }
        public double FinalLang { get; set; }
        public double IncomingTest { get; set; }
        public double IntermTestBase { get; set; }
        public double IntermTestLang { get; set; }
        public double InterviewerScore { get; set; }
        public double TeacherScore { get; set; }
        public string InterviewerComment { get; set; }
        public double EnglishGrammar { get; set; }
        public double EntryScore { get; set; }
        public double ExpertScore { get; set; }
        public int EmployeeId { get; set; }
        public int UserId { get; set; }

        //TODO
        public FeedbackDTO ExpertFeedbackDTO { get; set; }
        public FeedbackDTO TeacherFeedbackDTO { get; set; }
        public string EnglishLevel { get; set; }
        public string StudentStatus { get; set; }



    }
}
