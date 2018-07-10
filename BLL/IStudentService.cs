using System.Collections.Generic;
using Ras.BLL.DTO;
using Ras.BLL.Implementation;

namespace Ras.BLL
{
    public interface IStudentService
    {
        StudentDTO GetById(int id);
        StudentDTO CreateStudent(int userId, int groupId);
        StudentDTO UpdateStudent(StudentDTO student);
        void Delete(int id);
        FeedbackDTO UpdateFeedback(FeedbackDTO feedback);

        /// <summary>
        ///     Creates Feedback entry for this student.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="typeOfFeeadBack">Type of feedback will be created.</param>
        /// <param name="feedback">Feedback data.</param>
        /// <returns></returns>
        FeedbackDTO CreateFeedback(int studentId, TypeOfFeedBack typeOfFeeadBack, FeedbackDTO feedback);
        FeedbackDTO GetFeedback(int studentId, TypeOfFeedBack typeOfFeeadBack);
        IEnumerable<FeedbackDTO> GetFeedBacksInGroup(int groupId, TypeOfFeedBack typeOfFeeadBack);
    }
}