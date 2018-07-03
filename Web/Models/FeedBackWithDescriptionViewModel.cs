using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ras.Web.Models
{
    public class FeedBackWithDescriptionViewModel
    {

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
