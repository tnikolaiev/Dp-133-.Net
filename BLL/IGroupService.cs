using System;
using System.Collections.Generic;
using System.Text;
using Ras.BLL.DTO;

namespace Ras.BLL
{
    interface IGroupService
    {
        GroupDTO GetById(int id);

        GroupDTO Create(GroupDTO group);

        GroupDTO Update(GroupDTO group);

    }
}
