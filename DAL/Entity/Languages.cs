using System.Collections.Generic;

namespace Ras.DAL.Entity
{
    public partial class Languages
    {
        public Languages()
        {
            LanguageTranslations = new HashSet<LanguageTranslations>();
        }

        public int LanguageId { get; set; }
        public string Local { get; set; }
        public string Name { get; set; }

        public ICollection<LanguageTranslations> LanguageTranslations { get; set; }
    }
}
