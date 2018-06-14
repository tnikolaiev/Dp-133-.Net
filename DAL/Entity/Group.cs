using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class Group
    {
        public Group()
        {
            GroupInfo = new HashSet<GroupInfo>();
            GroupInfoTeachers = new HashSet<GroupInfoTeacher>();
            GroupInfoTests = new HashSet<GroupInfoTest>();
            ItaAcademy = new HashSet<ItaGroup>();
            Students = new HashSet<Student>();
            TestesNames = new HashSet<TestName>();
        }

        [Key]
        public int AcademyId { get; set; }

        public int CrmGroup { get; set; }
        public DateTime EndDate { get; set; }
        public int Free { get; set; }
        public int HasEng { get; set; }
        public int HasFirst { get; set; }
        public int HasTech { get; set; }
        public string Name { get; set; }
        public int NotSynchronized { get; set; }
        public DateTime StartDate { get; set; }
        public int Status { get; set; }
        public int? StageId { get; set; }
        public int? CityId { get; set; }
        public int? DirectionId { get; set; }
        public int? TechnologyId { get; set; }

        public City City { get; set; }
        public Direction Direction { get; set; }
        public GroupStage Stage { get; set; }
        public Technology Technology { get; set; }
        public ICollection<GroupInfo> GroupInfo { get; set; }
        public ICollection<GroupInfoTeacher> GroupInfoTeachers { get; set; }
        public ICollection<GroupInfoTest> GroupInfoTests { get; set; }
        public ICollection<ItaGroup> ItaAcademy { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<TestName> TestesNames { get; set; }
    }
}