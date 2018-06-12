using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class Group
    {
        public Group()
        {
            GroupInfo = new HashSet<GroupInfo>();
            GroupInfoTeachers = new HashSet<GroupInfoTeachers>();
            GroupInfoTests = new HashSet<GroupInfoTests>();
            ItaAcademy = new HashSet<ItaAcademy>();
            Students = new HashSet<Students>();
            TestesNames = new HashSet<TestesNames>();
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
        public Directions Direction { get; set; }
        public AcademyStages Stage { get; set; }
        public Technologies Technology { get; set; }
        public ICollection<GroupInfo> GroupInfo { get; set; }
        public ICollection<GroupInfoTeachers> GroupInfoTeachers { get; set; }
        public ICollection<GroupInfoTests> GroupInfoTests { get; set; }
        public ICollection<ItaAcademy> ItaAcademy { get; set; }
        public ICollection<Students> Students { get; set; }
        public ICollection<TestesNames> TestesNames { get; set; }
    }
}
