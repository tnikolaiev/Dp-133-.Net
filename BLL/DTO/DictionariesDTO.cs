using System.Collections.Generic;

namespace Ras.BLL.DTO
{
    public class DictionariesDTO
    {
        public DictionariesDTO()
        { }

        public Dictionary<int, string> Cities { get; set; }
        public Dictionary<int, string> Directions { get; set; }     //CommonDirection
        public Dictionary<int, string> Technologies { get; set; }
        public Dictionary<int, string> Stages { get; set; }
        public Dictionary<int, string> NamesForSite { get; set; }
        public Dictionary<int, string> PaymentStatuses { get; set; }  //can`t find in data base
        public Dictionary<int, string> Profiles { get; set; }
    }
}
