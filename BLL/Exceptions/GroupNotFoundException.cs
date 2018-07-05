using System;
using System.Collections.Generic;
using System.Text;

namespace Ras.BLL.Exceptions
{
    public class GroupNotFoundException:Exception
    {
        public GroupNotFoundException() : base("Group with such id does not found.") { }
    }
}
