using System.Collections.Generic;
using System.Linq;
using Ras.BLL.DTO;
using Ras.DAL;

namespace Ras.BLL.Implementation
{
    public class DictionariesGroupService : Service, IDictionariesGroupService
    {
        public DictionariesGroupService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public DictionariesGroupDTO GetGroupInfoDictionaries()
        {
            var setOfDictionaries = new DictionariesGroupDTO
            {
                Cities = GetAllCities(),
                Directions = GetAllDirections(),
                Technologies = GetAllTechnologies(),
                Stages = GetAllStages(),
                NamesForSite = GetAllNamesForSite(),
                PaymentStatuses = GetAllPaymentStatuses(),
                Profiles = GetAllProfiles()
            };
            return setOfDictionaries;
        }

        private Dictionary<int, string> GetAllCities()
        {
            return new Dictionary<int, string>();
        }

        private Dictionary<int, string> GetAllDirections()
        {
            var dictionary = unitOfWork.DirectionsRepository.All
                                       .Select(d => new {d.DirectionId, d.Name})
                                       .ToDictionary(d => d.DirectionId, d => d.Name);
            return dictionary;
        }

        private Dictionary<int, string> GetAllTechnologies()
        {
            var dictionary = unitOfWork.TechnologiesRepository.All
                                       .Select(d => new {d.TechnologyId, d.Name})
                                       .ToDictionary(d => d.TechnologyId, d => d.Name);
            return dictionary;
        }

        private Dictionary<int, string> GetAllStages()
        {
            var dictionary = unitOfWork.GroupStagesRepository.All
                                       .Select(s => new {s.StageId, s.Name})
                                       .ToDictionary(d => d.StageId, d => d.Name);
            return dictionary;
        }

        private Dictionary<int, string> GetAllNamesForSite()
        {

            return new Dictionary<int, string>();
        }

        private Dictionary<int, string> GetAllPaymentStatuses()
        {
            var dictionary = unitOfWork.GroupPaymentStatusesRepository.All
                                       .Select(p => new {p.GroupPaymentStatusId, p.GroupPaymentStatusName})
                                       .ToDictionary(d => d.GroupPaymentStatusId, d => d.GroupPaymentStatusName);
            return dictionary;
        }

        private Dictionary<int, string> GetAllProfiles()
        {
            var dictionary = unitOfWork.ProfileInfosRepository.All
                                       .Select(p => new {p.ProfileId, p.ProfileName})
                                       .ToDictionary(d => d.ProfileId, d => d.ProfileName);
            return dictionary;
        }
    }
}