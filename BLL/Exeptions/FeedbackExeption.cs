using System;

namespace Ras.BLL.Exeptions
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
