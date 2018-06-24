using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ras.BLL.DTO;
using Ras.BLL.Implementation;
using Ras.DAL;
using Ras.DAL.Entity;
using System.Collections.Generic;

namespace Ras.BLL.Tests
{
    [TestClass]
    public class StudentServiceTest
    {
        private IStudentService Initialize()
        {
            var mock = new Mock<IUnitOfWork>();
            var studentService = new StudentService(mock.Object);

            var student = new Student
            {
                Id = 3,
                UserId = 1,
                User = new User { Id = 1 },
                Group = new Group(),
            };

            mock.Setup(x => x.StudentsRepository.Read(It.Is<int>(a => a == (3)))).Returns(student);
            mock.Setup(x => x.StudentsRepository.Delete(It.Is<int>(a => a == 3))).Callback(() =>
                        mock.Setup(x => x.StudentsRepository.Read(It.Is<int>(a => a == (3)))).Returns<Student>(null));

            mock.Setup(x => x.StudentsRepository.Update(It.Is<Student>(a => a.Id == 3)))
                .Returns(student);

            return studentService;
        }

        [TestMethod]
        public void Delete_ExistStudent_ReturnsWithSuchId()
        {
            var studentService = Initialize();
            studentService.Delete(3);

            Assert.ThrowsException<System.ArgumentException>(()=> studentService.GetById(3));
        }

        [TestMethod]
        public void GetById_Exist_ReturnsStudentWithSuchId()
        {
            var studentService = Initialize();

            var student = studentService.GetById(3);

            Assert.AreEqual(3, student.Id);

        }

        [TestMethod]
        public void Update_Existed_Student()
        {
            var studentService = Initialize();

            var result = studentService.UpdateStudent(new StudentDTO { Id = 3 });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Update_No_Existed_Student()
        {
            var mock = new Mock<IUnitOfWork>();
            var studentService = new StudentService(mock.Object);
            mock.Setup(x => x.StudentsRepository.Read(It.IsAny<int>())).Returns<Student>(null);

            var result = studentService.UpdateStudent(new StudentDTO());

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Update_Existed_FeedBack()
        {
            var mock = new Mock<IUnitOfWork>();
            var studentService = new StudentService(mock.Object);
            mock.Setup(x => x.FeedbacksRepository.Read(It.IsAny<int>())).Returns(new Feedback());
            mock.Setup(x => x.FeedbacksRepository.Update(It.IsAny<Feedback>())).Returns(new Feedback());
            mock.Setup(x => x.SaveChanges());

            var result = studentService.UpdateFeedback(new FeedbackDTO());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Update_No_Existed_FeedBack()
        {
            var mock = new Mock<IUnitOfWork>();
            var studentService = new StudentService(mock.Object);
            mock.Setup(x => x.FeedbacksRepository.Read(It.IsAny<int>())).Returns<Feedback>(null);

            var result = studentService.UpdateFeedback(new FeedbackDTO());

            Assert.IsNull(result);
        }
    }
}