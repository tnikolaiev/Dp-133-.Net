using Ras.BLL;
using Microsoft.AspNetCore.Mvc;
using Ras.Web.Models;
using AutoMapper;
using Ras.BLL.DTO;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private IStudentService studentService;

        private readonly IMapper userDTOMapper;
        private readonly IMapper studentMapper;
        private readonly IMapper studentDTOMapper;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
            userDTOMapper = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, UserDTO>()).CreateMapper();
            studentMapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentViewModel>()).CreateMapper();
            studentDTOMapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentViewModel, StudentDTO>()).CreateMapper();
        }

        [HttpPost]
        public IActionResult Create(int userId, int groupId)
        {
            if (ModelState.IsValid)
            {
                studentService.CreateStudent(userId, groupId);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public StudentViewModel Get(int id)
        {
            StudentDTO tempStudent = studentService.GetById(id);
            StudentViewModel student = studentMapper.Map<StudentDTO, StudentViewModel>(tempStudent);
            student.FullName = tempStudent.UserDTO.FirstName + " " + tempStudent.UserDTO.LastName;
            
            return student;
        }

        [HttpPut]
        public IActionResult Update([FromBody]StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                var studentDTO = studentDTOMapper.Map<StudentViewModel, StudentDTO>(student);
                studentService.UpdateStudent(studentDTO);
                return Ok(student);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            studentService.Delete(id);
            return Ok();
        }
    }
}