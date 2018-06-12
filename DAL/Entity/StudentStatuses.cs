using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class StudentStatuses
    {
        public StudentStatuses()
        {
            Students = new HashSet<Students>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Students> Students { get; set; }
    }
}
