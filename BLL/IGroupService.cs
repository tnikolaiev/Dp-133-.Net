using System;
using System.Collections.Generic;
using System.Text;
using Ras.BLL.DTO;

namespace Ras.BLL
{
    public interface IGroupService
    {
        GroupDTO GetById(int id);

        void Create(GroupDTO group);

        void Update(GroupDTO group);

        IEnumerable<StudentDTO> GetStudentsByGroupId(int groupId);

        IEnumerable<GroupDTO> GetAll(string orderby, int skip, int count);

        IEnumerable<GroupDTO> GetAll(string orderby, int skip, int count, string name, DateTime? startdate, DateTime? enddate, int? cityid, int? directionid, int? technologyid, int? stageid);

        IEnumerable<EmployeeDTO> GetAllEployee();

        IEnumerable<EmployeeDTO> GetAllEmployeesForGroup(int GroupId);

        void AddEmployeeToGroup(int groupId, int employeeId, int involved, int typeId);

        void DeleteEmployeeFromGroup(int groupId, int employeeId);

        void UpdateEmployeeInGroup(EmployeeDTO employee);
    }
}
