using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class Mark
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

        [Key]
        public int MarkId { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }
        public int? CharacteristicId { get; set; }

        public virtual Characteristic Characteristic { get; set; }
        public virtual ICollection<Feedback> FeedbackActiveCommunicatorNavigation { get; set; }
        public virtual ICollection<Feedback> FeedbackGettingThingsDoneNavigation { get; set; }
        public virtual ICollection<Feedback> FeedbackLearningAbilityNavigation { get; set; }
        public virtual ICollection<Feedback> FeedbackPassionalInitiativeNavigation { get; set; }
        public virtual ICollection<Feedback> FeedbackTeamWorkNavigation { get; set; }
        public virtual ICollection<Feedback> FeedbackTechnicalCompetenceNavigation { get; set; }
    }
}