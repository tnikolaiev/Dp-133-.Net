using System;
using System.Collections.Generic;
using System.Text;

namespace Ras.BLL.Exeption
{
    public class FeedbackExeption : Exception
    {
        public FeedbackExeption() : base("Student's feedback doesn't exist!") { }
    }
}
