using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Ras.BLL;
using Ras.BLL.DTO;
using Ras.BLL.Enums;
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
            var arguments = new object[] { id };
            LogBegin(arguments);
            var result = service.GetById(id);
            LogEnd(arguments);

            return result;
        }

        public StudentDTO CreateStudent(int userId, int groupId)
        {
            var arguments = new object[] { userId, groupId };
            LogBegin(arguments);
            var result = service.CreateStudent(userId, groupId);
            LogEnd(arguments);

            return result;
        }

        public StudentDTO UpdateStudent(StudentDTO student)
        {
            var arguments = new object[] { student };
            LogBegin(arguments);
            var result = service.UpdateStudent(student);
            LogEnd(arguments);

            return result;
        }

        public void Delete(int id)
        {
            var arguments = new object[] { id };
            LogBegin(arguments);
            service.Delete(id);
            LogEnd(arguments);
        }

        public FeedbackDTO UpdateFeedback(FeedbackDTO feedback)
        {
            var arguments = new object[] {feedback};
            LogBegin(arguments);
            var result = service.UpdateFeedback(feedback);
            LogEnd(arguments);

            return result;
        }

        public FeedbackDTO CreateFeedback(int studentId, TypeOfFeedBack typeOfFeedBack, FeedbackDTO feedback)
        {
            var arguments = new object[] {studentId, typeOfFeedBack, feedback};
            LogBegin(arguments);
            var result = service.CreateFeedback(studentId, typeOfFeedBack, feedback);
            LogEnd(arguments);

            return result;
        }

        public FeedbackDTO GetFeedback(int studentId, TypeOfFeedBack typeOfFeedBack)
        {
            var arguments = new object[] { studentId, typeOfFeedBack};
            LogBegin(arguments);
            var result = service.GetFeedback(studentId, typeOfFeedBack);
            LogEnd(arguments);

            return result;
        }

        public IEnumerable<FeedbackDTO> GetFeedBacksInGroup(int groupId, TypeOfFeedBack typeOfFeedBack)
        {
            var arguments = new object[] { groupId, typeOfFeedBack };
            LogBegin(arguments);
            var result = service.GetFeedBacksInGroup(groupId, typeOfFeedBack);
            LogEnd(arguments);

            return result;
        }
    }
}