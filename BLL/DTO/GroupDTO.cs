using Ras.DAL.Entity;
using System;

namespace Ras.BLL.DTO
{
    public class GroupDTO
    {
        public GroupDTO() { }
        public GroupDTO(Group groupDb)
        {
            this.Id = groupDb.Id;
            this.Name = groupDb.Name;
            this.CrmGroup = groupDb.CrmGroup;
            this.StartDate = groupDb.StartDate;
            this.EndDate = groupDb.EndDate;
            this.CityId = groupDb.CityId;
            this.Direction = groupDb.Direction.Name;
            this.DirectionId = groupDb.Direction.DirectionId;
            this.Technology = groupDb.Technology.Name;
            this.TechnologyId = groupDb.Technology.TechnologyId;
            this.Stage = groupDb.Stage.Name;
            this.StageId = groupDb.Stage.StageId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CrmGroup { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? CityId { get; set; }
        public string City { get; set; }
        public int DirectionId { get; set; }
        public string Direction { get; set; }
        public int TechnologyId { get; set; }
        public string Technology { get; set; }
        public int StageId { get; set; }
        public string Stage { get; set; }
        public int AmountStudentForGraduate { get; set; }
        public int AmountStudentForEnrollment { get; set; }
        public int AmountStudenActual { get; set; }
        public int TeacherId { get; set; }
        public int ExpertId { get; set; }
    }
}