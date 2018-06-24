using System;
using System.Collections.Generic;
using System.Text;

namespace Ras.BLL.Exeption
{
    public class StudentExeption:Exception
    {
        public StudentExeption():base("Student doesn't exist!") { }
    }
}
