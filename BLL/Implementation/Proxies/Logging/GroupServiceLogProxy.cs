using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Ras.BLL.DTO;

namespace Ras.BLL.Implementation.Proxies.Logging
{
    public class GroupServiceLogProxy : IGroupService
    {
        private readonly IGroupService groupService;
        private readonly ILogger logger;

        public GroupServiceLogProxy(IGroupService groupService, ILogger logger)
        {
            this.groupService = groupService;
            this.logger = logger;
        }

        public GroupDTO GetById(int id)
        {
            logger.Log(LogLevel.Trace, $"Begin method GroupService.GetById(int id = {id}).");
            var result = groupService.GetById(id);
            logger.Log(LogLevel.Trace, $"End method GroupService.GetById(int id = {id}).");

            return result;
        }

        public void Create(GroupDTO group)
        {
            logger.Log(LogLevel.Trace, $"Begin GroupService.Create(GroupDTO group).");
            groupService.Create(group);
            logger.Log(LogLevel.Trace, $"End GroupService.Create(GroupDTO group).");
        }

        public void Update(GroupDTO group)
        {
            logger.Log(LogLevel.Trace, $"Begin GroupService.Update(GroupDTO group).");
            groupService.Update(group);
            logger.Log(LogLevel.Trace, $"End GroupService.Update(GroupDTO group).");
        }

        public IEnumerable<StudentDTO> GetStudentsByGroupId(int groupId)
        {
            logger.Log(LogLevel.Trace, $"Begin GroupService.GetStudentsByGroupId(int groupId = {groupId}).");
            var result = groupService.GetStudentsByGroupId(groupId);
            logger.Log(LogLevel.Trace, $"Begin GroupService.GetStudentsByGroupId(int groupId = {groupId}).");

            return result;
        }

        public IEnumerable<GroupDTO> GetAll(string orderby, int skip, int count)
        {
            logger.Log(LogLevel.Trace, $"Begin GroupService.GetAll().");
            var result = groupService.GetAll(orderby, skip, count);
            logger.Log(LogLevel.Trace, $"Begin GroupService.GetAll().");

            return result;
        }

        public IEnumerable<GroupDTO> GetAll
            (string orderby, int skip, int count, string name, DateTime? startdate, DateTime? enddate, int? cityid, int? directionid, int? technologyid, int? stageid)
        {
            logger.Log(LogLevel.Trace,
                       $"Begin GroupService.GetAll(string name = {name}, DateTime? startdate = {startdate?.ToString()}, DateTime? enddate = {enddate?.ToString()}, int? cityid = {cityid?.ToString()}, int? directionid = {directionid?.ToString()}, int? technologyid = {technologyid?.ToString()}, int? stageid = {stageid?.ToString()}).");
            var result = groupService.GetAll(orderby, skip, count, name, startdate, enddate, cityid, directionid, technologyid, stageid);
            logger.Log(LogLevel.Trace,
                       $"Begin GroupService.GetAll(string name = {name}, DateTime? startdate = {startdate?.ToString()}, DateTime? enddate = {enddate?.ToString()}, int? cityid = {cityid?.ToString()}, int? directionid = {directionid?.ToString()}, int? technologyid = {technologyid?.ToString()}, int? stageid = {stageid?.ToString()}).");

            return result;
        }
    }
}