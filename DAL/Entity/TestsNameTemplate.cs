namespace Ras.DAL.Entity
{
    public partial class TestsNameTemplate
    {
        public long Id { get; set; }
        public double TestMaxScore { get; set; }
        public string TestName { get; set; }
        public int? TemplateDirectionId { get; set; }

        public Technologies TemplateDirection { get; set; }
    }
}
