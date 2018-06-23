﻿using System;
using System.Collections.Generic;
using System.Text;
using Ras.BLL.DTO;

namespace Ras.BLL
{
    interface IGroupService
    {
        GroupDTO GetById(int id);

        void Create(GroupDTO group);

        void Update(GroupDTO group);

        IEnumerable<StudentDTO> GetStudentsByGroupId(int groupId);

        IEnumerable<GroupDTO> GetAll();

        //IEnumerable<GroupDTO> GetAll();

    }
}
