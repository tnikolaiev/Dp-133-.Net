using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Ras.BLL;
using Ras.BLL.DTO;

namespace Ras.Infastructure.BLL.Proxies.Logging
{
    public class GroupServiceLogProxy : ServiceLogProxy<IGroupService>, IGroupService
    {
        public GroupServiceLogProxy(IGroupService groupService, ILogger logger) : base(groupService, logger)
        {
        }

        public GroupDTO GetById(int id)
        {
            var arguments = new object[] { id };
            LogBegin(arguments);
            var result = service.GetById(id);
            LogEnd(arguments);

            return result;
        }

        public void Create(GroupDTO group)
        {
            var arguments = new object[] {group};
            LogBegin(arguments);
            service.Create(group);
            LogEnd(arguments);
        }

        public void Update(GroupDTO group)
        {
            var arguments = new object[] { group };
            LogBegin(arguments);
            service.Update(group);
            LogEnd(arguments);
        }

        public IEnumerable<StudentDTO> GetStudentsByGroupId(int groupId)
        {
            var arguments = new object[] {groupId};
            LogBegin(arguments);
            var result = service.GetStudentsByGroupId(groupId);
            LogEnd(arguments);

            return result;
        }

        public IEnumerable<GroupDTO> GetAll(string orderby, int skip, int count)
        {
            var arguments = new object[] {orderby, skip, count};
            LogBegin(arguments);
            var result = service.GetAll(orderby, skip, count);
            LogEnd(arguments);

            return result;
        }

        public IEnumerable<GroupDTO> GetAll
        (
            string orderby, int skip, int count, string name, DateTime? startdate, DateTime? enddate, int? cityid, int? directionid,
            int? technologyid, int? stageid
        )
        {
            var arguments = new object[] {orderby, skip, count, name, startdate, enddate, cityid, directionid, technologyid, stageid};
            LogBegin(arguments);
            var result = service.GetAll(orderby, skip, count, name, startdate, enddate, cityid, directionid, technologyid, stageid);
            LogEnd(arguments);

            return result;
        }
    }
}