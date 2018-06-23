using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ras.BLL.Implementation;
using Ras.DAL;
using Ras.BLL.DTO;
using Moq;
using Ras.DAL.Entity;

namespace Ras.BLL.Tests
{
    [TestClass]
    public class StudentServiceTest
    {
        [TestMethod]
        public void Update_Existed_Student()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            StudentService studentService = new StudentService(mock.Object);
            mock.Setup(x => x.StudentsRepository.Read(It.IsAny<int>())).Returns(new Student());
            mock.Setup(x => x.StudentsRepository.Upate(It.IsAny<Student>())).Returns(new Student() { User = new User(),Group=new Group(),UserId=0 });
            mock.Setup(x => x.SaveChanges());

            var result = studentService.UpdateStudent(new StudentDTO());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Update_No_Existed_Student()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            StudentService studentService = new StudentService(mock.Object);
            mock.Setup(x => x.StudentsRepository.Read(It.IsAny<int>())).Returns<Student>(null);

            var result = studentService.UpdateStudent(new StudentDTO());

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Update_Existed_FeedBack()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            StudentService studentService = new StudentService(mock.Object);
            mock.Setup(x => x.FeedbacksRepository.Read(It.IsAny<int>())).Returns(new Feedback());
            mock.Setup(x => x.FeedbacksRepository.Upate(It.IsAny<Feedback>())).Returns(new Feedback());
            mock.Setup(x => x.SaveChanges());

            var result = studentService.UpdateFeedback(new FeedbackDTO());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Update_No_Existed_FeedBack()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
            StudentService studentService = new StudentService(mock.Object);
            mock.Setup(x => x.FeedbacksRepository.Read(It.IsAny<int>())).Returns<Feedback>(null);

            var result = studentService.UpdateFeedback(new FeedbackDTO());

            Assert.IsNull(result);
        }
    }
}
