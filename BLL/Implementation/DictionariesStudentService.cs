using System.Collections.Generic;
using Ras.BLL.DTO;
using Ras.DAL;

namespace Ras.BLL.Implementation
{
    public class DictionariesStudentService : Service, IDictionariesStudentService
    {
        public DictionariesStudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public DictionariesStudentDTO GetStudentDictionaries()
        {
            var setOfDictionaries = new DictionariesStudentDTO
            {
                StudentStatuses = GetAllStudentStatuses(),
                Experts = GetAllExpertsInGroup()
            };
            return setOfDictionaries;
        }

        private Dictionary<int, string> GetAllStudentStatuses()
        {
            return new Dictionary<int, string>();
        }

        private Dictionary<int, string> GetAllExpertsInGroup()
        {
            return new Dictionary<int, string>();
        }
    }
}