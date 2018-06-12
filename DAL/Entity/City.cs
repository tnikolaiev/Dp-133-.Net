using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class City
    {
        public City()
        {
            Academy = new HashSet<Group>();
        }

        public int CityId { get; set; }
        public int CrmId { get; set; }
        public int? Ita { get; set; }

        public ICollection<Group> Academy { get; set; }
    }
}
