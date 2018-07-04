using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class PersonalStatus
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}