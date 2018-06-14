using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ras.DAL.Entity
{
    public class LoginuserEmployeeroles
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        public int EmployeerolesId { get; set; }

        public EmployeeRole Employeeroles { get; set; }
        public LoginUser IdNavigation { get; set; }
    }
}