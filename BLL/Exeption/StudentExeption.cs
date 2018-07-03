using System;
using System.Collections.Generic;
using System.Text;

namespace Ras.BLL.Exeption
{
    public class StudentNotFoundException:Exception
    {
        public StudentNotFoundException() : base()
        {

        }

        public StudentNotFoundException(string message) : base(message)
        {

        }
    }
}
