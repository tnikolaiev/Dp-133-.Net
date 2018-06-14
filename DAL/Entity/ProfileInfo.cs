﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class ProfileInfo
    {
        public ProfileInfo()
        {
            GroupInfo = new HashSet<GroupInfo>();
        }

        [Key]
        public int ProfileId { get; set; }

        public string ProfileName { get; set; }
        public int? TechnologyId { get; set; }

        public Technology Technology { get; set; }
        public ICollection<GroupInfo> GroupInfo { get; set; }
    }
}