using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public class Language
    {
        public Language()
        {
            LanguageTranslations = new HashSet<LanguageTranslations>();
        }

        public int LanguageId { get; set; }
        public string Local { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LanguageTranslations> LanguageTranslations { get; set; }
    }
}