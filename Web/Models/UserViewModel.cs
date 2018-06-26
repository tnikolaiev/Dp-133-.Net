using Ras.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ras.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FirtstName { get; set; }
        public string LastName { get; set; }
        public int? EnglishLevel { get; set; }
        public string Phone { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
    }
}
