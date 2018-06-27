using Ras.BLL.DTO;

namespace Ras.BLL
{
    public interface IStudentService
    {
        StudentDTO GetById(int id);
        StudentDTO CreateStudent(int userId, int groupId);
        StudentDTO UpdateStudent(StudentDTO student);
        void Delete(int id);
    }
}