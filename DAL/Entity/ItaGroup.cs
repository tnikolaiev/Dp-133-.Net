using System;

namespace Ras.DAL.Entity
{
    public class ItaGroup
    {
        public int ItAcademyId { get; set; }
        public int? UserId { get; set; }
        public int? AcademyId { get; set; }
        public int? TechSlotId { get; set; }
        public int? EngSlotId { get; set; }
        public int? ItAcademyStatusId { get; set; }
        public int? LocationId { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Status { get; set; }
        public int? IsSync { get; set; }
        public int? IsSyncRegGroup { get; set; }
        public int? Canceled { get; set; }
        public DateTime? HrStartDate { get; set; }
        public DateTime? HrEndDate { get; set; }
        public string HrComment { get; set; }

        public virtual Group Academy { get; set; }
        public virtual ItaGroupStatus ItAcademyStatus { get; set; }
        public virtual User User { get; set; }
    }
}