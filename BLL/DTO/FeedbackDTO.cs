using Ras.DAL.Entity;

namespace Ras.BLL.DTO
{
    public class FeedbackDTO
    {
        public FeedbackDTO() { }
        public FeedbackDTO(Feedback dFeedback)
        {
            Id = dFeedback.FeedbackId;
            SummaryComment = dFeedback.SummaryComment;

            ActiveCommunicator = dFeedback.ActiveCommunicator?.Description;
            ActiveCommunicatorTitle = dFeedback.ActiveCommunicator?.Name;
            ActiveCommunicatorCharacteristic = dFeedback.ActiveCommunicator?.Characteristic.Name;

            GettingThingsDone = dFeedback.GettingThingsDone?.Description;
            GettingThingsDoneTitle = dFeedback.GettingThingsDone?.Name;
            GettingThingsDoneCharacteristic = dFeedback.GettingThingsDone?.Characteristic.Name;

            LearningAbility = dFeedback.LearningAbility?.Description;
            LearningAbilityTitle = dFeedback.LearningAbility?.Name;
            LearningAbilityCharacteristic = dFeedback.LearningAbility?.Characteristic.Name;

            TechnicalCompetence = dFeedback.TechnicalCompetence?.Description;
            TechnicalCompetenceTitle = dFeedback.TechnicalCompetence?.Name;
            TechnicalCompetenceCharacteristic = dFeedback.TechnicalCompetence?.Characteristic.Name;

            PassionalInitiative = dFeedback.PassionalInitiative?.Description;
            PassionalInitiativeTitle = dFeedback.PassionalInitiative?.Name;
            PassionalInitiativeCharacteristic = dFeedback.PassionalInitiative?.Characteristic.Name;

            TeamWork = dFeedback.TeamWork?.Description;
            TeamWorkTitle = dFeedback.TeamWork?.Name;
            TeamWorkCharacteristic = dFeedback.TeamWork?.Characteristic.Name;
        }

        public int Id { get; set; }
        public string SummaryComment { get; set; }

        public string ActiveCommunicatorTitle { get; set; }
        public string ActiveCommunicator { get; set; }
        public string ActiveCommunicatorCharacteristic { get; set; }

        public string GettingThingsDoneTitle { get; set; }
        public string GettingThingsDone { get; set; }
        public string GettingThingsDoneCharacteristic { get; set; }

        public string LearningAbilityTitle { get; set; }
        public string LearningAbility { get; set; }
        public string LearningAbilityCharacteristic { get; set; }


        public string TechnicalCompetenceTitle { get; set; }
        public string TechnicalCompetence { get; set; }
        public string TechnicalCompetenceCharacteristic { get; set; }

        public string PassionalInitiativeTitle { get; set; }
        public string PassionalInitiative { get; set; }
        public string PassionalInitiativeCharacteristic { get; set; }

        public string TeamWorkTitle { get; set; }
        public string TeamWork { get; set; }
        public string TeamWorkCharacteristic { get; set; }
    }
}