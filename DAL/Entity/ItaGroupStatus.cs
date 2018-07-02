using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public class ItaGroupStatus
    {
        public ItaGroupStatus()
        {
            ItaAcademy = new HashSet<ItaGroup>();
        }

        public int ItAcademyStatusId { get; set; }
        public int? CsStatus { get; set; }
        public string CrmStatus { get; set; }
        public string CrmStatusCode { get; set; }

        public virtual ICollection<ItaGroup> ItaAcademy { get; set; }
    }
}