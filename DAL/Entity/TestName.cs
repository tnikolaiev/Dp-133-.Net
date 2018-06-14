using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class TestName
    {
        [Key]
        public long Id { get; set; }

        public int? AcademyId { get; set; }
        public double TestMaxScore { get; set; }
        public string Name { get; set; }
        public int? TestSequence { get; set; }

        public Group Academy { get; set; }
    }
}