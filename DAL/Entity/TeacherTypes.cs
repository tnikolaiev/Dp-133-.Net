using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class TeacherTypes
    {
        public TeacherTypes()
        {
            GroupInfoTeachers = new HashSet<GroupInfoTeachers>();
        }

        public int TeacherTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<GroupInfoTeachers> GroupInfoTeachers { get; set; }
    }
}
