using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ras.BLL;
using Ras.Web.Models;
using AutoMapper;
using Ras.BLL.DTO;
using Ras.BLL.Implementation;
using Ras.Web.Filters;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [ServiceFilter(typeof(LoggerFilterAttribute))]
    [ServiceFilter(typeof(CustomExeptionFilterAttribute))]
    [Route("api/[controller]")]
    public class FeedbackController : Controller
    {
        IStudentService studentService;
        IMapper feedbackMapper;
        IMapper feedbackWithDescriptionMapper;
        IMapper feedbackDtoMapper;
        IMapper feedbacksMapper;
        public FeedbackController(IStudentService service)
        {
            studentService = service;
            feedbackMapper = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackDTO, FeedbackViewModel>()).CreateMapper();
            feedbackWithDescriptionMapper = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackDTO,FeedBackWithDescriptionViewModel>()).CreateMapper();
            feedbackDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackViewModel, FeedbackDTO>()).CreateMapper();
            feedbacksMapper = new MapperConfiguration(cfg => cfg.CreateMap<IEnumerable< FeedbackDTO>,IEnumerable<FeedbackViewModel>>()).CreateMapper();
        }

        [HttpGet("teacher/{studentId}")]
        public FeedBackWithDescriptionViewModel GetFeedBackTeacher(int studentId)
        {
            var feedback = feedbackWithDescriptionMapper.Map<FeedbackDTO, FeedBackWithDescriptionViewModel>(studentService.GetFeedback(studentId, TypeOfFeedBack.teacher));
            return feedback;
        }

        [HttpGet("expert/{studentId}")]
        public FeedBackWithDescriptionViewModel GetFeedBackExpert(int studentId)
        {
            var feedback = feedbackWithDescriptionMapper.Map<FeedbackDTO, FeedBackWithDescriptionViewModel>(studentService.GetFeedback(studentId, TypeOfFeedBack.expert));
            return feedback;
        }

        [HttpGet("interviewer/{studentId}")]
        public string GetFeedBackInterviewer(int studentId)
        {
            return studentService.GetById(studentId).InterviewerComment;
        }

        [HttpPut]  
        public IActionResult UpdateFeedBack([FromBody] FeedbackViewModel feedback)
        {
            if (ModelState.IsValid)
            {
                var feedbackDTO = feedbackDtoMapper.Map<FeedbackViewModel, FeedbackDTO>(feedback);
                studentService.UpdateFeedback(feedbackDTO);
                return Ok(feedback);
            }
            return BadRequest(ModelState);
        }
        
        [HttpPost("teacher/{studentId}")]
        public IActionResult CreateTeacherFeedBack(int studentId, [FromBody] FeedbackViewModel feedback)
        {
            if (ModelState.IsValid)
            {
                var feedbackDTO = feedbackDtoMapper.Map<FeedbackViewModel, FeedbackDTO>(feedback);
                studentService.CreateFeedback(studentId, TypeOfFeedBack.teacher, feedbackDTO);
                return Ok(feedback);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("expert/{studentId}")]
        public IActionResult CreateExpertFeedBack(int studentId, [FromBody] FeedbackViewModel feedback)
        {
            if (ModelState.IsValid)
            {
                var feedbackDTO = feedbackDtoMapper.Map<FeedbackViewModel, FeedbackDTO>(feedback);
                studentService.CreateFeedback(studentId, TypeOfFeedBack.expert, feedbackDTO);
                return Ok(feedback);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("interviewer/{studentId}")]
        public IActionResult CreateInterviewerFeedBack(int studentId, string feedback)
        {
            var student = studentService.GetById(studentId);
            student.InterviewerComment = feedback;
            studentService.UpdateStudent(student);
            return Ok(feedback);
        }

        [HttpGet("inGroup/{groupId}")]
        public IActionResult GetInGroup(int groupId)
        {
            var teacherFeedbacks = feedbackWithDescriptionMapper.Map<IEnumerable<FeedbackDTO>, IEnumerable<FeedbackViewModel>>(studentService.GetFeedBacksInGroup(groupId, TypeOfFeedBack.teacher));
            var expertfeedbacks = feedbackWithDescriptionMapper.Map<IEnumerable<FeedbackDTO>, IEnumerable<FeedbackViewModel>>(studentService.GetFeedBacksInGroup(groupId, TypeOfFeedBack.expert));
            var result = teacherFeedbacks.Zip(expertfeedbacks, (tf, ef) => new { teacherFeedback = tf, expertFeedback = ef });
            return Ok(result);
        }
    }
}