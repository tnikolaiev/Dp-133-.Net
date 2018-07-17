using System.Collections.Generic;
using Ras.BLL.DTO;
using Ras.BLL.Enums;
using Ras.DAL;
using System.Linq;

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
            var dictionary = unitOfWork.MarksRepository.All
                .Where(d => d.CharacteristicId == (int)MarksEnum.LearningAbility)
                .Select(d=>new { d.MarkId, d.Name})
                .ToDictionary(d => d.MarkId, d => d.Name);
            return dictionary;
        }

        private Dictionary<int, string> GetAllOverallTechnicalCompetences()
        {
            var dictionary = unitOfWork.MarksRepository.All
                .Where(d => d.CharacteristicId == (int)MarksEnum.OverallTechnicalCompetence)
                .Select(d => new { d.MarkId, d.Name })
                .ToDictionary(d => d.MarkId, d => d.Name);
            return dictionary;
        }

        private Dictionary<int, string> GetAllProfessionalInitistives()
        {
            var dictionary = unitOfWork.MarksRepository.All
                .Where(d => d.CharacteristicId == (int)MarksEnum.PassionalInitiative)
                .Select(d => new { d.MarkId, d.Name })
                .ToDictionary(d => d.MarkId, d => d.Name);
            return dictionary;
        }

        private Dictionary<int, string> GetAllTeamWorkStatuses()
        {
            var dictionary = unitOfWork.MarksRepository.All
                .Where(d => d.CharacteristicId == (int)MarksEnum.TeamWork)
                .Select(d => new { d.MarkId, d.Name })
                .ToDictionary(d => d.MarkId, d => d.Name);
            return dictionary;
        }

        private Dictionary<int, string> GetAllGettingThingsDoneStatuses()
        {
            var dictionary = unitOfWork.MarksRepository.All
                .Where(d => d.CharacteristicId == (int)MarksEnum.GettingThingsDone)
                .Select(d => new { d.MarkId, d.Name })
                .ToDictionary(d => d.MarkId, d => d.Name);
            return dictionary;
        }

        private Dictionary<int, string> GetAllActiveCommunicatorStatuses()
        {
            var dictionary = unitOfWork.MarksRepository.All
                .Where(d => d.CharacteristicId == (int)MarksEnum.ActiveCommunicator)
                .Select(d => new { d.MarkId, d.Name })
                .ToDictionary(d => d.MarkId, d => d.Name);
            return dictionary;
        }
    }
}