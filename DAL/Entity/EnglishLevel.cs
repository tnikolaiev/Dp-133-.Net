using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class EnglishLevel
    {
        public EnglishLevel()
        {
            Students = new HashSet<Students>();
        }

        public int EnglishLevelId { get; set; }
        public string Name { get; set; }

        public ICollection<Students> Students { get; set; }
    }
}
