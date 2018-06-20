using Ras.BLL.DTO;

namespace Ras.BLL
{
    public interface IStudentService
    {
        StudentDTO GetById(int id);
        StudentDTO CreateStudent(UserDTO user);
        StudentDTO UpdateStudent(StudentDTO student);
        void Delete(int id);
    }
}