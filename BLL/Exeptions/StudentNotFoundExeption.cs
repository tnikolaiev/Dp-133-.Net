using System;

namespace Ras.BLL.Exeptions
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException() : base("Student with such id does not found.")
        {
        }
    }
}