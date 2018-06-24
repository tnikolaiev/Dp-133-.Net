using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ras.Web.Models
{
    public class GroupInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CrmGroup { get; set; }               //what is this?
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Direction { get; set; }
        public string Technology { get; set; }
        public string Stage { get; set; }
        public string NameForSite { get; set; }         //where this info from? it is absent in DTO
        public string PaymentStatus { get; set; }       //where this info from? it is absent in DTO
        public string CommonDirection { get; set; }       //where this info from? it is absent in DTO
        public string Profile { get; set; }       //where this info from? it is absent in DTO
        public int AmountStudentForGraduate { get; set; }       //where this info from? it is absent in DTO
        public int AmountStudentForEnrollment { get; set; }       //where this info from? it is absent in DTO
        public int AmountStudenActual { get; set; }       //where this info from? it is absent in DTO
    }
}
