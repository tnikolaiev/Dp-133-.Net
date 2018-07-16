using System;

namespace Ras.BLL.Exceptions
{
    public class GroupNotFoundException : Exception
    {
        public GroupNotFoundException() : base("Group with such id does not found.")
        {
        }
    }
}