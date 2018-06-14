using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class EmployeeRole
    {
        public EmployeeRole()
        {
            LoginuserEmployeeroles = new HashSet<LoginuserEmployeeroles>();
        }

        [Key]
        public int EmployeeroleId { get; set; }

        public string Authority { get; set; }

        public ICollection<LoginuserEmployeeroles> LoginuserEmployeeroles { get; set; }
    }
}