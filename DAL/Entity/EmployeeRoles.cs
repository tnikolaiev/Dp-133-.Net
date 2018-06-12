using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class EmployeeRoles
    {
        public EmployeeRoles()
        {
            LoginuserEmployeeroles = new HashSet<LoginuserEmployeeroles>();
        }

        public int EmployeerolesId { get; set; }
        public string Authority { get; set; }

        public ICollection<LoginuserEmployeeroles> LoginuserEmployeeroles { get; set; }
    }
}
