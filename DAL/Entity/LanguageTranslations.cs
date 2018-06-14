namespace Ras.DAL.Entity
{
    public class LanguageTranslations
    {
        public int TranslationId { get; set; }
        public string Field { get; set; }
        public int ItemId { get; set; }
        public string Local { get; set; }
        public string Tag { get; set; }
        public string Trasnlation { get; set; }
        public int? LanguageId { get; set; }

        public Language Language { get; set; }
    }
}