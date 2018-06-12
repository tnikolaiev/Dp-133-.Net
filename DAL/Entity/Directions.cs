using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class Directions
    {
        public Directions()
        {
            Academy = new HashSet<Group>();
        }

        public int DirectionId { get; set; }
        public short? Ita { get; set; }
        public string Name { get; set; }

        public ICollection<Group> Academy { get; set; }
    }
}
