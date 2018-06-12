using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class Technologies
    {
        public Technologies()
        {
            Academy = new HashSet<Group>();
            ProfileInfo = new HashSet<ProfileInfo>();
            TestsNameTemplate = new HashSet<TestsNameTemplate>();
        }

        public int TechnologyId { get; set; }
        public string Alias { get; set; }
        public long? DirectiondId { get; set; }
        public int Free { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public short? Ita { get; set; }
        public string Name { get; set; }

        public ICollection<Group> Academy { get; set; }
        public ICollection<ProfileInfo> ProfileInfo { get; set; }
        public ICollection<TestsNameTemplate> TestsNameTemplate { get; set; }
    }
}
