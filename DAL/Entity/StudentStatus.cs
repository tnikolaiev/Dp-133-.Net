using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class StudentStatus
    {
        public StudentStatus()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}