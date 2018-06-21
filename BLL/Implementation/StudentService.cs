using System;
using Ras.BLL.DTO;
using Ras.DAL;
using Ras.DAL.Entity;

namespace Ras.BLL.Implementation
{
    public enum TypeOfFeeadBack
    {
        teacher,
        expert
    }
    public class StudentService : Service, IStudentService
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

            var student = new StudentDTO(unitOfWork.StudentsRepository.Create(dStudent));

            unitOfWork.SaveChanges();
            return student;
        }

        public StudentDTO UpdateStudent(StudentDTO student)
        {
            Student dStudent = unitOfWork.StudentsRepository.Read(student.Id);
            StudentDTO newStudent = null;
            if (dStudent != null)
            {
                newStudent = new StudentDTO(unitOfWork.StudentsRepository.Upate(dStudent));
                unitOfWork.SaveChanges();
            }

            return newStudent;
        }

        public FeedbackDTO UpdateFeedback(FeedbackDTO feedback)
        {
            Feedback dFeedBack = unitOfWork.FeedbacksRepository.Read(feedback.Id);
            FeedbackDTO newFeedBack = null;
            if (dFeedBack != null)
            {
                newFeedBack = new FeedbackDTO(unitOfWork.FeedbacksRepository.Upate(dFeedBack));
                unitOfWork.SaveChanges();
            }

            return newFeedBack;
        }
        public FeedbackDTO CreateFeedback( int studentId,TypeOfFeeadBack typeOfFeeadBack,FeedbackDTO feedback)
        {
            Student dStudent = unitOfWork.StudentsRepository.Read(studentId);
            Feedback dFeedBack = unitOfWork.FeedbacksRepository.Read(feedback.Id);
            FeedbackDTO newFeedBack = null;
            if (dFeedBack != null && dStudent != null)
            {
                newFeedBack = new FeedbackDTO(unitOfWork.FeedbacksRepository.Create(dFeedBack));
                switch (typeOfFeeadBack)
                {
                    case TypeOfFeeadBack.expert:
                        {
                            dStudent.ExpertStudentFeedbackId = newFeedBack.Id;                      
                            break;
                        }
                    case TypeOfFeeadBack.teacher:
                        {
                            dStudent.TeacherStudentFeedbackId = newFeedBack.Id;
                            break;
                        }
                }

                unitOfWork.StudentsRepository.Upate(dStudent);
                unitOfWork.SaveChanges();
            }

            return newFeedBack;
        }
       
        public void Delete(int id)
        {
            unitOfWork.StudentsRepository.Delete(id);
            unitOfWork.SaveChanges();
        }
    }
}