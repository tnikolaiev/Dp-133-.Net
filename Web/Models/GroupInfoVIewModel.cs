using System;
using System.Collections.Generic;

namespace Ras.Web.Models
{
    public class GroupInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CrmGroup { get; set; }               //what is this?
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CityId { get; set; }
        public Dictionary<int,string> Cities { get; set; }
        public string DirectionId { get; set; }     //CommonDirection
        public Dictionary<int, string> Directions { get; set; }
        public int TechnologyId { get; set; }       //Direction
        public Dictionary<int, string> Technologies { get; set; }
        public int StageId { get; set; }
        public Dictionary<int, string> Stages { get; set; }
        public int NameForSiteId { get; set; }
        public Dictionary<int, string> NamesForSite { get; set; }         //where this info from? it is absent in DTO

        public int PaymentStatusId { get; set; }       //where this info from? it is absent in DTO
        public Dictionary<int, string> PaymentStatuses { get; set; }
        public int Profile { get; set; }       //where this info from? it is absent in DTO
        public Dictionary<int, string> Profiles { get; set; }
        public int AmountStudentForGraduate { get; set; }       //where this info from? it is absent in DTO
        public int AmountStudentForEnrollment { get; set; }       //where this info from? it is absent in DTO
        public int AmountStudenActual { get; set; }       //where this info from? it is absent in DTO
    }
}
