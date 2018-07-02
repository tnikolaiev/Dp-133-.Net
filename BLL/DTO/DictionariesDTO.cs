using System.Collections.Generic;

namespace Ras.BLL.DTO
{
    public class DictionariesDTO
    {
        public DictionariesDTO()
        {
            Cities = new Dictionary<int, string>();
            Directions = new Dictionary<int, string>();
            Technologies = new Dictionary<int, string>();
            Stages = new Dictionary<int, string>();
            NamesForSite = new Dictionary<int, string>();
            PaymentStatuses = new Dictionary<int, string>();
            Profiles = new Dictionary<int, string>();
        }

        public Dictionary<int, string> Cities { get; set; }
        public Dictionary<int, string> Directions { get; set; }     //CommonDirection
        public Dictionary<int, string> Technologies { get; set; }
        public Dictionary<int, string> Stages { get; set; }
        public Dictionary<int, string> NamesForSite { get; set; }
        public Dictionary<int, string> PaymentStatuses { get; set; }
        public Dictionary<int, string> Profiles { get; set; }
    }
}
