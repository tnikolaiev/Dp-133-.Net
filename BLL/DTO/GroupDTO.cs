using System;

namespace Ras.BLL.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CrmGroup { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Direction { get; set; }
        public string Technology { get; set; }
        public string Stage { get; set; }
    }
}