using System;
using System.Collections.Generic;
using System.Text;

namespace Ras.BLL.DTO
{
    class StudentDTO
    {
        public int Id { get; set; }
        public UserDTO UserDTO { get; set; }
        public int GroupId { get; set; }
        public List<double> Tests { get; set; }
        public double FinalBase { get; set; }


    }
}
