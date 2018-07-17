using System.Collections.Generic;

namespace Ras.BLL.DTO
{
    public class DictionariesFeedbackDTO
    {
        public Dictionary<int,string> LearningAbilities { get; set; }
        public Dictionary<int, string> OverallTechnicalCompetences { get; set; }
        public Dictionary<int, string> ProfessionalInitistives { get; set; }
        public Dictionary<int, string> TeamWorkStatuses { get; set; }
        public Dictionary<int, string> GettingThingsDoneStatuses { get; set; }
        public Dictionary<int, string> ActiveCommunicatorStatuses { get; set; }
    }
}
