using System;
using System.Collections.Generic;
using System.Text;

namespace Ras.BLL.DTO
{
    class FeedbackDTO
    {
        public int Id { get; set; }
        public string SummaryComment { get; set; }
        public string ActiveCommunicator { get; set; }
        public string GettingThingsDone { get; set; }
        public string LearningAbility { get; set; }
        public string TechnicalCompetence { get; set; }
        public string PassionalInitiative { get; set; }
        public string TeamWork { get; set; }
    }
}
