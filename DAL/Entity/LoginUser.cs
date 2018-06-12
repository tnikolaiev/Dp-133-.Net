using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class LoginUser
    {
        public LoginUser()
        {
            LoginuserEmployeeroles = new HashSet<LoginuserEmployeeroles>();
        }

        public int Id { get; set; }
        public byte[] AccountNonExpired { get; set; }
        public byte[] AccountNonLocked { get; set; }
        public byte[] CredentialsNonExpired { get; set; }
        public byte[] Enabled { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }
        public ICollection<LoginuserEmployeeroles> LoginuserEmployeeroles { get; set; }
    }
}
