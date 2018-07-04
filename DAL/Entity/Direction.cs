using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class Direction
    {
        public Direction()
        {
            Academy = new HashSet<Group>();
        }

        [Key]
        public int DirectionId { get; set; }

        public short? Ita { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Group> Academy { get; set; }
    }
}