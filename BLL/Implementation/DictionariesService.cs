using Ras.BLL.DTO;
using Ras.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Ras.BLL.Implementation
{
    public class DictionariesService : Service, IDictionariesService
    {
        public DictionariesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public DictionariesDTO GetGroupInfoDictionaries()
        {
            var setOfDictionaries = new DictionariesDTO();
            setOfDictionaries.Cities = getAllCities();
            setOfDictionaries.Directions = getAllDirections();
            setOfDictionaries.Technologies = getAllTechnologies();
            setOfDictionaries.Stages = getAllStages();
            setOfDictionaries.NamesForSite = getAllNamesForSite();
            setOfDictionaries.PaymentStatuses = getAllPaymentStatuses();
            setOfDictionaries.Profiles = getAllProfiles();
            return setOfDictionaries;
        }

        private Dictionary<int,string> createDictionary(IList<int> keys, IList<string> values)
        {
            var dictionary = new Dictionary<int, string>();
            for (int i = 0; i < values.Count; i++)
                dictionary.Add(keys[i], values[i]);
            return dictionary;
        }

        private Dictionary<int, string> getAllCities()
        {
            return new Dictionary<int, string>();
        }

        private Dictionary<int, string> getAllDirections()
        {
            var keys = unitOfWork.DirectionsRepository.All.Select(d => d.DirectionId).ToList();
            var values = new List<string>();
            foreach (var k in keys)
                values.Add(unitOfWork.DirectionsRepository.All.Where(d => d.DirectionId == k).Select(d => d.Name).FirstOrDefault());
            return createDictionary(keys, values);
        }

        private Dictionary<int, string> getAllTechnologies()
        {
            var keys = unitOfWork.TechnologiesRepository.All.Select(t => t.TechnologyId).ToList();
            var values = new List<string>();
            foreach (var k in keys)
                values.Add(unitOfWork.TechnologiesRepository.All.Where(t => t.TechnologyId == k).Select(t => t.Name).FirstOrDefault());
            return createDictionary(keys, values);
        }

        private Dictionary<int, string> getAllStages()
        {
            var keys = unitOfWork.GroupStagesRepository.All.Select(s => s.StageId).ToList();
            var values = new List<string>();
            foreach (var k in keys)
                values.Add(unitOfWork.GroupStagesRepository.All.Where(s => s.StageId == k).Select(s => s.Name).FirstOrDefault());
            return createDictionary(keys, values);
        }

        private Dictionary<int, string> getAllNamesForSite()
        {
            return new Dictionary<int, string>();
        }

        private Dictionary<int, string> getAllPaymentStatuses()
        {
            var keys = unitOfWork.GroupPaymentStatusesRepository.All.Select(p => p.GroupPaymentStatusId).ToList();
            var values = new List<string>();
            foreach (var k in keys)
                values.Add(unitOfWork.GroupPaymentStatusesRepository.All.Where(p => p.GroupPaymentStatusId == k).Select(p => p.GroupPaymentStatusName).FirstOrDefault());
            return createDictionary(keys, values);
        }

        private Dictionary<int, string> getAllProfiles()
        {
            var keys = unitOfWork.ProfileInfosRepository.All.Select(p => p.ProfileId).ToList();
            var values = new List<string>();
            foreach (var k in keys)
                values.Add(unitOfWork.ProfileInfosRepository.All.Where(p => p.ProfileId == k).Select(p => p.ProfileName).FirstOrDefault());
            return createDictionary(keys, values);
        }
    }
}
