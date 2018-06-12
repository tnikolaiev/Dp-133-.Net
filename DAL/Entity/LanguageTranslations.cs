namespace Ras.DAL.Entity
{
    public partial class LanguageTranslations
    {
        public int TranslationId { get; set; }
        public string Field { get; set; }
        public int ItemId { get; set; }
        public string Local { get; set; }
        public string Tag { get; set; }
        public string Trasnlation { get; set; }
        public int? LanguageId { get; set; }

        public Languages Language { get; set; }
    }
}
