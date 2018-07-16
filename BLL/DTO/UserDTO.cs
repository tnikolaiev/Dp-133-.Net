using Ras.DAL.Entity;

namespace Ras.BLL.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(User dUser)
        {
            Id = dUser.Id;
            Name = dUser.UserName;
            Email = dUser.Email;
            FirstName = dUser.FirstName;
            LastName = dUser.LastName;
            EnglishLevel = dUser.EngLevel;
            Phone = dUser.Phone;
            Salt = dUser.Salt;
            Password = dUser.Password;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? EnglishLevel { get; set; }
        public string Phone { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
    }
}