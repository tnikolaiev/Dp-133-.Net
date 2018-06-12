﻿using System;

namespace Ras.DAL.Entity
{
    public partial class ItaAcademy
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

        public Group Academy { get; set; }
        public ItaAcademyStatuses ItAcademyStatus { get; set; }
        public User User { get; set; }
    }
}
