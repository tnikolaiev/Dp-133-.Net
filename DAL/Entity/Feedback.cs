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
        public int? ActiveCommunicatorId { get; set; }
        public int? GettingThingsDoneId { get; set; }
        public int? LearningAbilityId { get; set; }
        public int? TechnicalCompetenceId { get; set; }
        public int? PassionalInitiativeId { get; set; }
        public int? TeamWorkId { get; set; }

        public virtual Mark ActiveCommunicator { get; set; }
        public virtual Mark GettingThingsDone { get; set; }
        public virtual Mark LearningAbility { get; set; }
        public virtual Mark PassionalInitiative { get; set; }
        public virtual Mark TeamWork { get; set; }
        public virtual Mark TechnicalCompetence { get; set; }
        public virtual ICollection<Student> StudentsExpertStudentFeedback { get; set; }
        public virtual ICollection<Student> StudentsTeacherStudentFeedback { get; set; }
    }
}