using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class EnglishLevel
    {
        public EnglishLevel()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public int EnglishLevelId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}