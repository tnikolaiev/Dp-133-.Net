using System.ComponentModel.DataAnnotations;

namespace Ras.DAL.Entity
{
    public class TestsNameTemplate
    {
        [Key]
        public long Id { get; set; }

        public double TestMaxScore { get; set; }
        public string TestName { get; set; }
        public int? TemplateDirectionId { get; set; }

        public virtual Technology TemplateDirection { get; set; }
    }
}