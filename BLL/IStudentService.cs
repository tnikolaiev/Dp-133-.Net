using Ras.BLL.DTO;
using Ras.BLL.Implementation;
namespace Ras.BLL
{
    public interface IStudentService
    {
        StudentDTO GetById(int id);
        StudentDTO CreateStudent(UserDTO user, int groupId);
        StudentDTO UpdateStudent(StudentDTO student);
        void Delete(int id);
        FeedbackDTO UpdateFeedback(FeedbackDTO feedback);
        FeedbackDTO CreateFeedback(int studentId, TypeOfFeeadBack typeOfFeeadBack, FeedbackDTO feedback);
    }
}