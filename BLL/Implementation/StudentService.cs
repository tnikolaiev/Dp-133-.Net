using System;
using Ras.BLL.DTO;
using Ras.DAL;
using Ras.DAL.Entity;

namespace Ras.BLL.Implementation
{
    public class StudentService : Service, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public StudentDTO GetById(int id)
        {
            return new StudentDTO(unitOfWork.StudentsRepository.Read(id));
        }

        public StudentDTO CreateStudent(UserDTO user, int groupId)
        {
            var dUser = unitOfWork.UsersRepository.Read(user.Id);
            var dStudent = new Student
            {
                User = dUser,
                GroupId = groupId,
            };

            var student = new StudentDTO(unitOfWork.StudentsRepository.Create(dStudent));

            unitOfWork.SaveChanges();
            return student;
        }

        public StudentDTO UpdateStudent(StudentDTO student)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            unitOfWork.StudentsRepository.Delete(id);
            unitOfWork.SaveChanges();
        }
    }
}