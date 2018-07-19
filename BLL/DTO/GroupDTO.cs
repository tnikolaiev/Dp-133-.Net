using System;
using Ras.DAL.Entity;

namespace Ras.BLL.DTO
{
    public class GroupDTO
    {
        public GroupDTO()
        {
        }

        public GroupDTO(Group groupDb)
        {
            Id = groupDb.Id;
            NameForSite = groupDb.Name;
            CrmGroup = groupDb.CrmGroup;
            StartDate = groupDb.StartDate;
            EndDate = groupDb.EndDate;
            CityId = groupDb.CityId;
            Direction = groupDb.Direction.Name;
            DirectionId = groupDb.Direction.DirectionId;
            Technology = groupDb.Technology.Name;
            TechnologyId = groupDb.Technology.TechnologyId;
            Stage = groupDb.Stage.Name;
            StageId = groupDb.Stage.StageId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NameForSite { get; set; }
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