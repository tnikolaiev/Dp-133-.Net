using System;

namespace Ras.BLL.Exeptions
{
    public class FeedbackExeption : Exception
    {
        public FeedbackExeption() : base("Feedback with such id does not found.")
        {

        }
    }
}
