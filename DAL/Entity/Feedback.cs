using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class Feedback
    {
        public Feedback()
        {
            StudentsExpertStudentFeedback = new HashSet<Student>();
            StudentsTeacherStudentFeedback = new HashSet<Student>();
        }

        [Key]
        public int FeedbackId { get; set; }

        public string SummaryComment { get; set; }
        public int? ActiveCommunicator { get; set; }
        public int? GettingThingsDone { get; set; }
        public int? LearningAbility { get; set; }
        public int? TechnicalCompetence { get; set; }
        public int? PassionalInitiative { get; set; }
        public int? TeamWork { get; set; }

        public Mark ActiveCommunicatorNavigation { get; set; }
        public Mark GettingThingsDoneNavigation { get; set; }
        public Mark LearningAbilityNavigation { get; set; }
        public Mark PassionalInitiativeNavigation { get; set; }
        public Mark TeamWorkNavigation { get; set; }
        public Mark TechnicalCompetenceNavigation { get; set; }
        public ICollection<Student> StudentsExpertStudentFeedback { get; set; }
        public ICollection<Student> StudentsTeacherStudentFeedback { get; set; }
    }
}