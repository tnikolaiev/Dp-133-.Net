using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ras.BLL.DTO;
using Ras.BLL.Exeptions;
using Ras.BLL.Implementation;
using Ras.DAL;
using Ras.DAL.Entity;

namespace Ras.BLL.Tests
{
    [TestClass]
    public class StudentServiceTest
    {
        private static StudentService StudentService;
        private static readonly Mock<IUnitOfWork> Mock = new Mock<IUnitOfWork>();

        private static readonly Student Student = new Student
        {
            Id = 3,
            UserId = 1,
            User = new User {Id = 1},
            Group = new Group()
        };

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Mock.Setup(x => x.StudentsRepository.Read(It.Is<int>(a => a == 3))).Returns(Student);
            Mock.Setup(x => x.StudentsRepository.Delete(It.Is<int>(a => a == 3))).Callback(() =>
                                                                                               Mock.Setup(x => x.StudentsRepository.Read(
                                                                                                              It.Is<int>(a => a == 3)))
                                                                                                   .Returns<Student>(null));
            Mock.Setup(x => x.StudentsRepository.Update(It.Is<Student>(a => a.Id == 3)))
                .Returns(Student);

            Mock.Setup(x => x.EnglishLevelsRepository.All).Returns(new List<EnglishLevel>().AsQueryable());
            Mock.Setup(x => x.StudentStatusesRepository.All).Returns(new List<StudentStatus>().AsQueryable());

            Mock.Setup(x => x.FeedbacksRepository.Read(It.IsAny<int>())).Returns(new Feedback());
            Mock.Setup(x => x.FeedbacksRepository.All).Returns(new[] {new Feedback()}.AsQueryable());

            Mock.Setup(x => x.FeedbacksRepository.Update(It.IsAny<Feedback>())).Returns(new Feedback());

            Mock.Setup(x => x.CharacteristicsRepository.All).Returns(new[] {new Characteristic()}.AsQueryable());

            Mock.Setup(x => x.MarksRepository.All).Returns(new[] {new Mark()}.AsQueryable());

            Mock.Setup(x => x.SaveChanges());

            StudentService = new StudentService(Mock.Object);
        }

        [TestMethod]
        public void Delete_ExistStudent_DeletesStudentWithSuchId()
        {
            StudentService.Delete(3);

            Assert.ThrowsException<StudentNotFoundException>(() => StudentService.GetById(3));
        }

        [TestMethod]
        public void GetById_Exist_ReturnsStudentWithSuchId()
        {
            Mock.Setup(x => x.StudentsRepository.Read(It.Is<int>(a => a == 3))).Returns(Student);
            var student = StudentService.GetById(3);

            Assert.AreEqual(3, student.Id);
        }

        [ExpectedException(typeof(StudentNotFoundException))]
        [TestMethod]
        public void GetById_NotExist_TrowsException()
        {
            var student = StudentService.GetById(5);
        }

        [TestMethod]
        public void UpdateExistStudent_ReturnsNotNullStudentDto()
        {
            Mock.Setup(x => x.StudentsRepository.Read(It.Is<int>(a => a == 3))).Returns(Student);
            var result = StudentService.UpdateStudent(new StudentDTO {Id = 3});

            Assert.AreEqual(3, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(StudentNotFoundException))]
        public void UpdateNotExistStudent_ThrowsException()
        {
            Mock.Setup(x => x.StudentsRepository.Read(It.IsAny<int>())).Returns<Student>(null);

            var result = StudentService.UpdateStudent(new StudentDTO());
        }

        [TestMethod]
        public void UpdateExistFeedback_RetunsNotNullFeedbackDTO()
        {
            var result = StudentService.UpdateFeedback(new FeedbackDTO());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FeedbackNotFoundExeption))]
        public void Update_Not_Exist_FeedBack()
        {
            Mock.Setup(x => x.FeedbacksRepository.Read(It.IsAny<int>())).Returns<Feedback>(null);

            var result = StudentService.UpdateFeedback(new FeedbackDTO());
        }
    }
}