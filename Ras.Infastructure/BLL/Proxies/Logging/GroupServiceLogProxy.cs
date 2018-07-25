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

        public IEnumerable<EmployeeDTO> GetAllEployee()
        {
            LogBegin();
            var result = service.GetAllEployee();
            LogEnd();

            return result;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployeesForGroup(int GroupId)
        {
            LogBegin(new object[] { GroupId });
            var result = service.GetAllEmployeesForGroup(GroupId);
            LogEnd(new object[] { GroupId });

            return result;
        }

        public void AddEmployeeToGroup(int groupId, int employeeId, int involved, int typeId)
        {
            LogBegin(new object[] { groupId, employeeId, involved, typeId });
            service.AddEmployeeToGroup(groupId, employeeId, involved, typeId);
            LogEnd(new object[] { groupId, employeeId, involved, typeId });
        }

        public void DeleteEmployeeFromGroup(int groupId, int employeeId)
        {
            LogBegin(new object[] { groupId, employeeId });
            service.DeleteEmployeeFromGroup(groupId, employeeId);
            LogEnd(new object[] { groupId, employeeId });
        }

        public void UpdateEmployeeInGroup(EmployeeDTO employee)
        {
            LogBegin(new object[] { employee });
            service.UpdateEmployeeInGroup(employee);
            LogEnd(new object[] { employee });
        }
    }
}