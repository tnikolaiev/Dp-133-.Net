using System;

namespace Ras.BLL.Exeptions
{
    public class FeedbackNotFoundExeption : Exception
    {
        public FeedbackNotFoundExeption() : base("Feedback with such id does not found.")
        {

        }
    }
}
