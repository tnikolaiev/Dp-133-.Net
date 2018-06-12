using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class User
    {
        public User()
        {
            ItaAcademy = new HashSet<ItaAcademy>();
            Students = new HashSet<Students>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public int? EngLevel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Salt { get; set; }
        public string UserName { get; set; }

        public ICollection<ItaAcademy> ItaAcademy { get; set; }
        public ICollection<Students> Students { get; set; }
    }
}
