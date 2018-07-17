using Ras.BLL.DTO;
using Ras.BLL.Enums;
using Ras.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Ras.BLL.Implementation
{
    public class DictionariesStudentService : Service, IDictionariesStudentService
    {
        public DictionariesStudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public DictionariesStudentDTO GetStudentDictionaries(int groupId)
        {
            var setOfDictionaries = new DictionariesStudentDTO()
            {
                StudentStatuses = GetAllStudentStatuses(),
                Experts = GetAllExpertsInGroup(groupId)
            };
            return setOfDictionaries;
        }

        private Dictionary<int, string> GetAllStudentStatuses()
        {
            var dictionary = unitOfWork.StudentStatusesRepository.All
                .Select(d => new { d.Id, d.Name })
                .ToDictionary(d => d.Id, d => d.Name);
            return dictionary;
        }

        private Dictionary<int, string> GetAllExpertsInGroup(int groupId)
        {
            var dictionary = new Dictionary<int, string>();
            var employeeIds = unitOfWork.GroupInfoTeachersRepsitory.All
                .Where(d => d.AcademyId == groupId)
                .Where(d => d.TeacherTypeId == (int)TeacherTypeEnum.Expert)
                .Select(d => d.EmployeeId);
            foreach (var id in employeeIds)
            {
                var empInfo = unitOfWork.EmployeesRepository.All
                    .Where(d => d.EmployeeId == id)
                    .Select(d => new { d.EmployeeId, d.FirstNameEng, d.LastNameEng }).FirstOrDefault();
                dictionary.Add(empInfo.EmployeeId, empInfo.FirstNameEng + empInfo.LastNameEng);
            }
            return dictionary;
        }
    }
}
