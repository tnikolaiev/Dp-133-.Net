using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ras.Web.Models
{
    public class GroupHistoryViewModel
    {
        public int Id { get; set; }
        public int? AcademyId { get; set; }
        public string AcademyName { get; set; }
        public string NameForSite { get; set; }
        public string Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Stage { get; set; }
        public string Direction { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public int? CrmGroup { get; set; }
    }
}
