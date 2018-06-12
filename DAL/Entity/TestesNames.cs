namespace Ras.DAL.Entity
{
    public partial class TestesNames
    {
        public long Id { get; set; }
        public int? AcademyId { get; set; }
        public double TestMaxScore { get; set; }
        public string TestName { get; set; }
        public int? TestSequence { get; set; }

        public Group Academy { get; set; }
    }
}
