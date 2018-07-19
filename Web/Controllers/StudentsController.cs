using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ras.BLL;
using Ras.BLL.DTO;
using Ras.Web.Filters;
using Ras.Web.Models;

namespace Web.Controllers
{
    [ServiceFilter(typeof(LoggerFilterAttribute))]
    [ServiceFilter(typeof(CustomExeptionFilterAttribute))]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IMapper studentDTOMapper;
        private readonly IMapper studentMapper;

        private readonly IMapper userDTOMapper;
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
            userDTOMapper = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, UserDTO>()).CreateMapper();
            studentMapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentViewModel>()).CreateMapper();
            studentDTOMapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentViewModel, StudentDTO>()).CreateMapper();
        }

        /// <summary>
        ///     Creates student by user id and group id.
        /// </summary>
        /// <param name="userId">Id of user.</param>
        /// <param name="groupId">Id of group to which student will be added.</param>
        /// <returns>Status of request.</returns>
        [HttpPost("create/userId={userId}/groupId={groupId}")]
        public IActionResult CreateStudent(int userId, int groupId)
        {
            if (ModelState.IsValid)
            {
                studentService.CreateStudent(userId, groupId);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        ///     Gets student by id.
        /// </summary>
        /// <param name="id">Id of student.</param>
        /// <returns>Return student with given id.</returns>
        [HttpGet("{id}")]
        public StudentViewModel GetStydentById(int id)
        {
            var tempStudent = studentService.GetById(id);
            var student = studentMapper.Map<StudentDTO, StudentViewModel>(tempStudent);
            student.FullName = tempStudent.UserDTO.FirstName + " " + tempStudent.UserDTO.LastName;

            return student;
        }

        /// <summary>
        ///     Takes student by <paramref name="student"/>.Id and updates his data.
        /// </summary>
        /// <param name="student">Data to update</param>
        /// <returns>Status of request</returns>
        [HttpPut("update")]
        public IActionResult UpdateStudent([FromBody] StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                var studentDTO = studentDTOMapper.Map<StudentViewModel, StudentDTO>(student);
                studentService.UpdateStudent(studentDTO);
                return Ok(student);
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        ///     Delete student by id.
        /// </summary>
        /// <param name="id">Id of student which we need to delete.</param>
        /// <returns> Status of request </returns>
        [HttpDelete("delete/id={id}")]
        public IActionResult DeleteStudentById(int id)
        {
            studentService.Delete(id);
            return Ok();
        }
    }
}