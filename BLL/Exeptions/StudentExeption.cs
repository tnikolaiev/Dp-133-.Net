using System;

namespace Ras.BLL.Exeptions
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
