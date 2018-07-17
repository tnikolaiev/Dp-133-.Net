using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Ras.BLL;
using Ras.BLL.DTO;
using Ras.BLL.Implementation;

namespace Ras.Infastructure.BLL.Proxies.Logging
{
    public class StudentServiceLogProxy : ServiceLogProxy<IStudentService>, IStudentService
    {
        public StudentServiceLogProxy(IStudentService studentService, ILogger logger)
            : base(studentService, logger)
        {
        }

        public StudentDTO GetById(int id)
        {
            LogBegin(id);
            var result = service.GetById(id);
            LogEnd(id);

            return result;
        }

        public StudentDTO CreateStudent(int userId, int groupId)
        {
            LogBegin(userId, groupId);
            var result = service.CreateStudent(userId, groupId);
            LogEnd(userId, groupId);

            return result;
        }

        public StudentDTO UpdateStudent(StudentDTO student)
        {
            LogBegin(student);
            var result = service.UpdateStudent(student);
            LogEnd(student);

            return result;
        }

        public void Delete(int id)
        {
            LogBegin(id);
            service.Delete(id);
            LogEnd(id);
        }

        public FeedbackDTO UpdateFeedback(FeedbackDTO feedback)
        {
            LogBegin(feedback);
            var result = service.UpdateFeedback(feedback);
            LogEnd(feedback);

            return result;
        }

        public FeedbackDTO CreateFeedback(int studentId, TypeOfFeedBack typeOfFeedBack, FeedbackDTO feedback)
        {
            LogBegin(studentId, typeOfFeedBack, feedback);
            var result = service.CreateFeedback(studentId, typeOfFeedBack, feedback);
            LogEnd(studentId, typeOfFeedBack, feedback);

            return result;
        }

        public FeedbackDTO GetFeedback(int studentId, TypeOfFeedBack typeOfFeedBack)
        {
            LogBegin(studentId, typeOfFeedBack);
            var result = service.GetFeedback(studentId, typeOfFeedBack);
            LogEnd(studentId, typeOfFeedBack);

            return result;
        }

        public IEnumerable<FeedbackDTO> GetFeedBacksInGroup(int groupId, TypeOfFeedBack typeOfFeedBack)
        {
            LogBegin(groupId, typeOfFeedBack);
            var result = service.GetFeedBacksInGroup(groupId, typeOfFeedBack);
            LogEnd(groupId, typeOfFeedBack);

            return result;
        }
    }
}