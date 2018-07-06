using Ras.BLL.DTO;
using Ras.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Ras.BLL.Implementation
{
    class DictionariesStudentService:Service,IDictionariesStudentService
    {
        public DictionariesStudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public DictionariesStudentDTO GetStudentDictionaries()
        {
            var setOfDictionaries = new DictionariesStudentDTO();
            setOfDictionaries.StudentStatuses = GetAllStudentStatuses();
            setOfDictionaries.Experts = GetAllExpertsInGroup();
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
