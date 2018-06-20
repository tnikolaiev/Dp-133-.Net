using System;
using Ras.BLL.DTO;
using Ras.DAL;
using Ras.DAL.Entity;

namespace Ras.BLL.Implementation
{
    internal class StudentService : Service, IStudentService
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
            var dUser = unitOfWork.UsersRepository.Read(user.Id);
            var dStudent = new Student
            {
                User = dUser
            };

            return new StudentDTO(unitOfWork.StudentsRepository.Create(dStudent));
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