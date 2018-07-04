using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class Technology
    {
        public Technology()
        {
            Academy = new HashSet<Group>();
            ProfileInfo = new HashSet<ProfileInfo>();
            TestsNameTemplate = new HashSet<TestsNameTemplate>();
        }

        [Key]
        public int TechnologyId { get; set; }

        public string Alias { get; set; }
        public long? DirectiondId { get; set; }
        public int Free { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public short? Ita { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Group> Academy { get; set; }
        public virtual ICollection<ProfileInfo> ProfileInfo { get; set; }
        public virtual ICollection<TestsNameTemplate> TestsNameTemplate { get; set; }
    }
}