using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class User
    {
        public User()
        {
            ItaAcademy = new HashSet<ItaGroup>();
            Students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public int? EngLevel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Salt { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<ItaGroup> ItaAcademy { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}