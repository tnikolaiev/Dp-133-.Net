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
        FeedbackDTO CreateFeedback(int studentId, TypeOfFeeadBack typeOfFeeadBack, FeedbackDTO feedback);
        FeedbackDTO GetFeedback(int studentId, TypeOfFeeadBack typeOfFeeadBack);
        IEnumerable<FeedbackDTO> GetFeedBacksInGroup(int groupId, TypeOfFeeadBack typeOfFeeadBack);
    }
}