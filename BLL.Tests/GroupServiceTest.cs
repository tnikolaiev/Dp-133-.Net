using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ras.BLL.Implementation;
using Ras.DAL;
using Ras.BLL.DTO;
using Ras.DAL.Entity;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Ras.BLL.Tests
{
    [TestClass]
    public class GroupServiceTest
    {
        [TestMethod]
        public void Create_New_Group_return_true()
        {
            var mock = new Mock<IUnitOfWork>();
            var groupService = new GroupService(mock.Object);
            var group = new GroupDTO
            {
                Id = 4,
                CrmGroup = 45,
                Name = "Test group",
                StartDate = DateTime.Today.Date,
                EndDate = DateTime.Today.Date,
                DirectionId = 7,
                TechnologyId = 8,
                StageId = 1
            };
            bool isCreated = false;

            mock.Setup(a => a.GroupsRepository.Create(It.Is<Group>
                (gr =>
                        (gr.Id == group.Id) &&
                        (gr.Name == group.Name) &&
                        (gr.CrmGroup == group.CrmGroup) &&
                        (gr.StartDate == group.StartDate) &&
                        (gr.EndDate == group.EndDate) &&
                        (gr.DirectionId == group.DirectionId) &&
                        (gr.TechnologyId == group.TechnologyId) &&
                        (gr.StageId==group.StageId)))).Callback(() => isCreated = true);

            groupService.Create(group);

            Assert.IsTrue(isCreated);
        }

        [TestMethod]
        public void Update_Group_return_true()
        {
            var mock = new Mock<IUnitOfWork>();
            var groupService = new GroupService(mock.Object);
            var group = new GroupDTO
            {
                Id = 4,
                CrmGroup = 45,
                Name = "Test group",
                StartDate = DateTime.Today.Date,
                EndDate = DateTime.Today.Date,
                DirectionId = 7,
                TechnologyId = 8,
                StageId = 1
            };
            bool isUpdated = false;
            mock.Setup(a => a.GroupsRepository.Upate(It.Is<Group>
                (gr =>
                        (gr.Id == group.Id) &&
                        (gr.Name == group.Name) &&
                        (gr.CrmGroup == group.CrmGroup) &&
                        (gr.StartDate == group.StartDate) &&
                        (gr.EndDate == group.EndDate) &&
                        (gr.DirectionId == group.DirectionId) &&
                        (gr.TechnologyId == group.TechnologyId) &&
                        (gr.StageId == group.StageId)))).Callback(() => isUpdated = true);

            groupService.Update(group);

            Assert.IsTrue(isUpdated);
        }

        [TestMethod]
        public void Read_Group_return_group()
        {
            var mock = new Mock<IUnitOfWork>();
            var groupService = new GroupService(mock.Object);
            var group = new Group
            {
                Id = 4,
                CrmGroup = 45,
                Name = "Test group",
                StartDate = DateTime.Today.Date,
                EndDate = DateTime.Today.Date,
                Direction = new Direction {DirectionId=7, Name=".Net"},
                Technology = new Technology { TechnologyId=8, Name="Web"},
                Stage = new GroupStage { StageId=9, Name="Test"}
            };


            mock.Setup(x => x.GroupsRepository.Read(It.Is<int>(a => a == (4)))).Returns(group);


            var result = groupService.GetById(4);

            Assert.AreEqual(4, result.Id);
        }

        

    }
}
