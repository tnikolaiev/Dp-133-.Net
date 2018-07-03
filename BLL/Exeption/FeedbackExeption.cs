using System;
using System.Collections.Generic;
using System.Text;

namespace Ras.BLL.Exeption
{
    public class FeedbackExeption : Exception
    {
        public FeedbackExeption() : base()
        {

        }

        public FeedbackExeption(string message) : base(message)
        {

        }
    }
}
