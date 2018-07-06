using Ras.BLL.DTO;
using Ras.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Ras.BLL.Implementation
{
    class DictionariesFeedbackService:Service,IDictionariesFeedbackService
    {
        public DictionariesFeedbackService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public DictionariesFeedbackDTO GetFeedbackDictionaries()
        {
            var setOfDictionaries = new DictionariesFeedbackDTO();
            setOfDictionaries.LearningAbilities = GetAllLearningAbilities();
            setOfDictionaries.OverallTechnicalCompetences = GetAllOverallTechnicalCompetences();
            setOfDictionaries.ProfessionalInitistives = GetAllProfessionalInitistives();
            setOfDictionaries.TeamWorkStatuses = GetAllTeamWorkStatuses();
            setOfDictionaries.GettingThingsDoneStatuses = GetAllGettingThingsDoneStatuses();
            setOfDictionaries.ActiveCommunicatorStatuses = GetAllActiveCommunicatorStatuses();
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
