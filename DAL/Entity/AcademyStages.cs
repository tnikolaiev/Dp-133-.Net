using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class AcademyStages
    {
        public AcademyStages()
        {
            Academy = new HashSet<Group>();
        }

        public int StageId { get; set; }
        public string Name { get; set; }
        public short Sort { get; set; }

        public ICollection<Group> Academy { get; set; }
    }
}
