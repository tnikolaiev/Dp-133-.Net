using System;
using System.Collections.Generic;
using System.Text;
using Ras.BLL.DTO;
using Ras.DAL;
namespace Ras.BLL.Implementation
{
    class StudentService : Service, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public StudentDTO GetById(int id)
        {
            return new StudentDTO(unitOfWork.StudentsRepository.Read(id));
        }

        public StudentDTO CreateStudent(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public StudentDTO UpdateStudent(StudentDTO student)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
