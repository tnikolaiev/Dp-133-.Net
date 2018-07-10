using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class TeacherType
    {
        public TeacherType()
        {
            GroupInfoTeachers = new HashSet<GroupInfoTeacher>();
        }

        [Key]
        public int TeacherTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<GroupInfoTeacher> GroupInfoTeachers { get; set; }
    }
}