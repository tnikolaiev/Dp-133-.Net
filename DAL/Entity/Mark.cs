using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class Mark
    {
        public Mark()
        {
            FeedbackActiveCommunicatorNavigation = new HashSet<Feedback>();
            FeedbackGettingThingsDoneNavigation = new HashSet<Feedback>();
            FeedbackLearningAbilityNavigation = new HashSet<Feedback>();
            FeedbackPassionalInitiativeNavigation = new HashSet<Feedback>();
            FeedbackTeamWorkNavigation = new HashSet<Feedback>();
            FeedbackTechnicalCompetenceNavigation = new HashSet<Feedback>();
        }

        public int MarkId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int? CharacteristicId { get; set; }

        public Characteristic Characteristic { get; set; }
        public ICollection<Feedback> FeedbackActiveCommunicatorNavigation { get; set; }
        public ICollection<Feedback> FeedbackGettingThingsDoneNavigation { get; set; }
        public ICollection<Feedback> FeedbackLearningAbilityNavigation { get; set; }
        public ICollection<Feedback> FeedbackPassionalInitiativeNavigation { get; set; }
        public ICollection<Feedback> FeedbackTeamWorkNavigation { get; set; }
        public ICollection<Feedback> FeedbackTechnicalCompetenceNavigation { get; set; }
    }
}
