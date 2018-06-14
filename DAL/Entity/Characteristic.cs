using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class Characteristic
    {
        public Characteristic()
        {
            Mark = new HashSet<Mark>();
        }

        [Key]
        public int CharacteristicId { get; set; }

        public string Name { get; set; }

        public ICollection<Mark> Mark { get; set; }
    }
}