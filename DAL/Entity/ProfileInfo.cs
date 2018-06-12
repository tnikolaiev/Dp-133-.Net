using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class ProfileInfo
    {
        public ProfileInfo()
        {
            GroupInfo = new HashSet<GroupInfo>();
        }

        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public int? TechnologyId { get; set; }

        public Technologies Technology { get; set; }
        public ICollection<GroupInfo> GroupInfo { get; set; }
    }
}
