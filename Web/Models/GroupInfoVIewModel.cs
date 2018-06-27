using System;
using System.Collections.Generic;

namespace Ras.Web.Models
{
    public class GroupInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
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

        public int CrmGroup { get; set; }
        public int NameForSiteId { get; set; }
        public Dictionary<int, string> NamesForSite { get; set; }
        public int PaymentStatusId { get; set; }
        public Dictionary<int, string> PaymentStatuses { get; set; }
        public int Profile { get; set; }
        public Dictionary<int, string> Profiles { get; set; }
        public int AmountStudentForGraduate { get; set; }
        public int AmountStudentForEnrollment { get; set; }
        public int AmountStudenActual { get; set; }
    }
}
