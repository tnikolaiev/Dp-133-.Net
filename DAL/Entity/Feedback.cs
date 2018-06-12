using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class Feedback
    {
        public Feedback()
        {
            StudentsExpertStudentFeedback = new HashSet<Students>();
            StudentsTeacherStudentFeedback = new HashSet<Students>();
        }

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
        public ICollection<Students> StudentsExpertStudentFeedback { get; set; }
        public ICollection<Students> StudentsTeacherStudentFeedback { get; set; }
    }
}
