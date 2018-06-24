using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ras.BLL.DTO;
using Ras.BLL.Implementation;
using Ras.DAL;
using Ras.DAL.Entity;
using System.Collections.Generic;
using Ras.BLL.Exeption;
using Ras.DAL.Implementation;

namespace Ras.BLL.Tests
{
    [TestClass]
    public class StudentServiceTest
    {
        private static StudentService studentService;
        private static Mock<IUnitOfWork> mock;
        private static Student student;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            mock = new Mock<IUnitOfWork>();
            studentService = new StudentService(mock.Object);
            student = new Student
            {
                Id = 3,
                UserId = 1,
                User = new User { Id = 1 },
                Group = new Group(),
            };
        }

        private void Initialize()
        {
            mock.Setup(x => x.StudentsRepository.Read(It.Is<int>(a => a == (3)))).Returns(student);
            mock.Setup(x => x.StudentsRepository.Delete(It.Is<int>(a => a == 3))).Callback(() =>
                        mock.Setup(x => x.StudentsRepository.Read(It.Is<int>(a => a == (3)))).Returns<Student>(null));

            mock.Setup(x => x.StudentsRepository.Upate(It.Is<Student>(a => a.Id == 3)))
                .Returns(student);
        }

        [TestMethod]
        public void Delete_ExistStudent_ReturnsWithSuchId()
        {
            Initialize();
            studentService.Delete(3);

            Assert.ThrowsException<StudentExeption>(()=> studentService.GetById(3));
        }

        [TestMethod]
        public void GetById_Exist_ReturnsStudentWithSuchId()
        {
            Initialize();

            var student = studentService.GetById(3);

            Assert.AreEqual(3, student.Id);

        }

        [TestMethod]
        public void Update_Existed_Student()
        {
            mock.Setup(x => x.FeedbacksRepository.Read(It.IsAny<int>())).Returns<Feedback>(null);

            var result = studentService.UpdateStudent(new StudentDTO { Id = 3 });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(StudentExeption))]
        public void Update_No_Existed_Student()
        {
            mock.Setup(x => x.StudentsRepository.Read(It.IsAny<int>())).Returns<Student>(null);

            var result = studentService.UpdateStudent(new StudentDTO());
        }

        [TestMethod]
        public void Update_Existed_FeedBack()
        {
            mock.Setup(x => x.FeedbacksRepository.Read(It.IsAny<int>())).Returns(new Feedback());
            mock.Setup(x => x.FeedbacksRepository.Upate(It.IsAny<Feedback>())).Returns(new Feedback());
            mock.Setup(x => x.SaveChanges());

            var result = studentService.UpdateFeedback(new FeedbackDTO());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FeedbackExeption))]
        public void Update_No_Existed_FeedBack()
        {
            mock.Setup(x => x.FeedbacksRepository.Read(It.IsAny<int>())).Returns<Feedback>(null);

            var result = studentService.UpdateFeedback(new FeedbackDTO());
        }        
    }
}