namespace Ras.DAL.Entity
{
    public partial class LoginuserEmployeeroles
    {
        public int Id { get; set; }
        public int EmployeerolesId { get; set; }

        public EmployeeRoles Employeeroles { get; set; }
        public LoginUser IdNavigation { get; set; }
    }
}
