using Microsoft.Extensions.Logging;
using Ras.BLL.DTO;

namespace Ras.BLL.Implementation.Proxies.Logging
{
    public class StudentServiceLogProxy : IStudentService
    {
        private readonly ILogger logger;
        private readonly IStudentService studentService;

        public StudentServiceLogProxy(IStudentService studentService, ILogger logger)
        {
            this.studentService = studentService;
            this.logger = logger;
        }

        public StudentDTO GetById(int id)
        {
            logger.Log(LogLevel.Trace, $"Begin StudentService.GetById(int id = {id})");
            var result = studentService.GetById(id);
            logger.Log(LogLevel.Trace, $"End StudentService.GetById(int id = {id})");

            return result;
        }

        public StudentDTO CreateStudent(int userId, int groupId)
        {
            logger.Log(LogLevel.Trace, $"Begin StudentService.CreateStudent(int userId = {userId}, int groupId = {groupId})");
            var result = studentService.CreateStudent(userId, groupId);
            logger.Log(LogLevel.Trace, $"End StudentService.CreateStudent(int userId = {userId}, int groupId = {groupId})");

            return result;
        }

        public StudentDTO UpdateStudent(StudentDTO student)
        {
            logger.Log(LogLevel.Trace, $"Begin StudentService.UpdateStudent(StudentDTO student = {student})");
            var result = studentService.UpdateStudent(student);
            logger.Log(LogLevel.Trace, $"End StudentService.UpdateStudent(StudentDTO student = {student})");

            return result;
        }

        public void Delete(int id)
        {
            logger.Log(LogLevel.Trace, $"Begin StudentService.UpdateStudent(int id = {id})");
            studentService.Delete(id);
            logger.Log(LogLevel.Trace, $"End StudentService.UpdateStudent(int id = {id})");
        }

        public FeedbackDTO UpdateFeedback(FeedbackDTO feedback)
        {
            logger.Log(LogLevel.Trace, $"Begin StudentService.UpdateFeedback(FeedbackDTO feedback = {feedback})");
            var result = studentService.UpdateFeedback(feedback);
            logger.Log(LogLevel.Trace, $"End StudentService.UpdateFeedback(FeedbackDTO feedback = {feedback})");

            return result;
        }

        public FeedbackDTO CreateFeedback(int studentId, TypeOfFeeadBack typeOfFeeadBack, FeedbackDTO feedback)
        {
            logger.Log(LogLevel.Trace,
                       $"Begin StudentService.CreateFeedback(int studentId = {studentId}, TypeOfFeeadBack typeOfFeeadBack = {typeOfFeeadBack}, FeedbackDTO feedback = {feedback})");
            var result = studentService.CreateFeedback(studentId, typeOfFeeadBack, feedback);
            logger.Log(LogLevel.Trace,
                       $"End StudentService.CreateFeedback(int studentId = {studentId}, TypeOfFeeadBack typeOfFeeadBack = {typeOfFeeadBack}, FeedbackDTO feedback = {feedback})");

            return result;
        }

        public FeedbackDTO GetFeedback(int studentId, TypeOfFeeadBack typeOfFeeadBack)
        {
            logger.Log(LogLevel.Trace,
                       $"Begin StudentService.GetFeedback(int studentId  = {studentId}, TypeOfFeeadBack typeOfFeeadBack = {typeOfFeeadBack})");
            var result = studentService.GetFeedback(studentId, typeOfFeeadBack);
            logger.Log(LogLevel.Trace,
                       $"End StudentService.GetFeedback(int studentId  = {studentId}, TypeOfFeeadBack typeOfFeeadBack = {typeOfFeeadBack})");

            return result;
        }
    }
}