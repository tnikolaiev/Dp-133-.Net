using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ras.Web.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string EnglishLevel { get; set; }

        public string EnglishGrammar { get; set; }

        public double? IntermTestLang { get; set; }

        public double? IncomingTest { get; set; }

        public double? EntryScore { get; set; }

        public List<double?> Tests { get; set; }

        public double? FinalBase { get; set; }

        public double? FinalLang { get; set; }

        public double? IntermTestBase { get; set; }

        public double? TeacherScore { get; set; }

        public double? ExpertScore { get; set; }

        public double? InterviewerScore { get; set; }

        public string StudentStatus { get; set; }

        public int? EmployeeId { get; set; } // ApprovedBy

        public FeedbackViewModel ExpertFeedback { get; set; }

        public FeedbackViewModel TeacherFeedback { get; set; }

        //public string PersonStatus { get; set; }
    }
}
