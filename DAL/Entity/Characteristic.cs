using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class Characteristic
    {
        public Characteristic()
        {
            Mark = new HashSet<Mark>();
        }

        public int CharacteristicId { get; set; }
        public string Name { get; set; }

        public ICollection<Mark> Mark { get; set; }
    }
}
