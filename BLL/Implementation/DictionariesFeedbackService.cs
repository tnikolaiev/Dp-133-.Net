using System.Collections.Generic;
using Ras.BLL.DTO;
using Ras.DAL;

namespace Ras.BLL.Implementation
{
    public class DictionariesFeedbackService : Service, IDictionariesFeedbackService
    {
        public DictionariesFeedbackService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public DictionariesFeedbackDTO GetFeedbackDictionaries()
        {
            var setOfDictionaries = new DictionariesFeedbackDTO
            {
                LearningAbilities = GetAllLearningAbilities(),
                OverallTechnicalCompetences = GetAllOverallTechnicalCompetences(),
                ProfessionalInitistives = GetAllProfessionalInitistives(),
                TeamWorkStatuses = GetAllTeamWorkStatuses(),
                GettingThingsDoneStatuses = GetAllGettingThingsDoneStatuses(),
                ActiveCommunicatorStatuses = GetAllActiveCommunicatorStatuses()
            };
            return setOfDictionaries;
        }

        private Dictionary<int, string> GetAllLearningAbilities()
        {
            return new Dictionary<int, string>();
        }

        private Dictionary<int, string> GetAllOverallTechnicalCompetences()
        {
            return new Dictionary<int, string>();
        }

        private Dictionary<int, string> GetAllProfessionalInitistives()
        {
            return new Dictionary<int, string>();
        }

        private Dictionary<int, string> GetAllTeamWorkStatuses()
        {
            return new Dictionary<int, string>();
        }

        private Dictionary<int, string> GetAllGettingThingsDoneStatuses()
        {
            return new Dictionary<int, string>();
        }

        private Dictionary<int, string> GetAllActiveCommunicatorStatuses()
        {
            return new Dictionary<int, string>();
        }
    }
}