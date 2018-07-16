using System.Collections.Generic;

namespace Ras.BLL.DTO
{
    public class DictionariesStudentDTO
    {
        public Dictionary<int, string> StudentStatuses { get; set; }
        public Dictionary<int, string> Experts { get; set; }
    }
}