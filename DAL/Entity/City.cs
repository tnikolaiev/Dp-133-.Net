using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class City
    {
        public City()
        {
            Academy = new HashSet<Group>();
        }

        [Key]
        public int CityId { get; set; }

        public int CrmId { get; set; }
        public int? Ita { get; set; }

        public virtual ICollection<Group> Academy { get; set; }
    }
}