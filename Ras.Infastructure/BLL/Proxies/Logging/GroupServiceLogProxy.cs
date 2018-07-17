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
            LogBegin(id);
            var result = service.GetById(id);
            LogEnd(id);

            return result;
        }

        public void Create(GroupDTO group)
        {
            LogBegin(group);
            service.Create(group);
            LogEnd(group);
        }

        public void Update(GroupDTO group)
        {
            LogBegin(group);
            service.Update(group);
            LogEnd(group);
        }

        public IEnumerable<StudentDTO> GetStudentsByGroupId(int groupId)
        {
            LogBegin(groupId);
            var result = service.GetStudentsByGroupId(groupId);
            LogEnd(groupId);

            return result;
        }

        public IEnumerable<GroupDTO> GetAll(string orderby, int skip, int count)
        {
            LogBegin(orderby, skip, count);
            var result = service.GetAll(orderby, skip, count);
            LogEnd(orderby, skip, count);

            return result;
        }

        public IEnumerable<GroupDTO> GetAll
        (
            string orderby, int skip, int count, string name, DateTime? startdate, DateTime? enddate, int? cityid, int? directionid,
            int? technologyid, int? stageid
        )
        {
            LogBegin(orderby, skip, count, name, startdate, enddate, cityid, directionid, technologyid, stageid);
            var result = service.GetAll(orderby, skip, count, name, startdate, enddate, cityid, directionid, technologyid, stageid);
            LogEnd(orderby, skip, count, name, startdate, enddate, cityid, directionid, technologyid, stageid);

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
            LogBegin();
            var result = service.GetAllEmployeesForGroup(GroupId);
            LogEnd();

            return result;
        }

        public void AddEmployeeToGroup(int groupId, int employeeId, int involved, int typeId)
        {
            LogBegin();
            service.AddEmployeeToGroup(groupId, employeeId, involved, typeId);
            LogEnd();
        }

        public void DeleteEmployeeFromGroup(int groupId, int employeeId)
        {
            LogBegin();
            service.DeleteEmployeeFromGroup(groupId, employeeId);
            LogEnd();
        }

        public void UpdateEmployeeInGroup(EmployeeDTO employee)
        {
            LogBegin();
            service.UpdateEmployeeInGroup(employee);
            LogEnd();
        }
    }
}