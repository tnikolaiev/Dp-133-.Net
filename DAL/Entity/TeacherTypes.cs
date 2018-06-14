using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class TeacherTypes
    {
        public TeacherTypes()
        {
            GroupInfoTeachers = new HashSet<GroupInfoTeacher>();
        }

        [Key]
        public int TeacherTypeId { get; set; }

        public string Name { get; set; }

        public ICollection<GroupInfoTeacher> GroupInfoTeachers { get; set; }
    }
}