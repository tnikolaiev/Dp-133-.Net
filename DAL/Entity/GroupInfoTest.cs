using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class GroupInfoTest
    {
        [Key]
        public int Id { get; set; }

        public string Test8MaxVal { get; set; }
        public string Test8Name { get; set; }
        public string Test5MaxVal { get; set; }
        public string Test5Name { get; set; }
        public string Test4MaxVal { get; set; }
        public string Test4Name { get; set; }
        public string Test9MaxVal { get; set; }
        public string Test9Name { get; set; }
        public string Test1MaxVal { get; set; }
        public string Test1Name { get; set; }
        public string Test7MaxVal { get; set; }
        public string Test7Name { get; set; }
        public string Test6MaxVal { get; set; }
        public string Test6Name { get; set; }
        public string Test10MaxVal { get; set; }
        public string Test10Name { get; set; }
        public string Test3MaxVal { get; set; }
        public string Test3Name { get; set; }
        public string Test2MaxVal { get; set; }
        public string Test2Name { get; set; }
        public int? AcademyId { get; set; }

        public virtual Group Academy { get; set; }
    }
}