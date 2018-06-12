using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class ItaAcademyStatuses
    {
        public ItaAcademyStatuses()
        {
            ItaAcademy = new HashSet<ItaAcademy>();
        }

        public int ItAcademyStatusId { get; set; }
        public int? CsStatus { get; set; }
        public string CrmStatus { get; set; }
        public string CrmStatusCode { get; set; }

        public ICollection<ItaAcademy> ItaAcademy { get; set; }
    }
}
