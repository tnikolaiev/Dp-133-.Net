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

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class FeedbackController : Controller
    {
        IStudentService studentService;
        IMapper feedbackMapper;
        IMapper feedbackWithDescriptionMapper;
        IMapper feedbackDtoMapper;

        public FeedbackController(IStudentService service)
        {
            studentService = service;
            feedbackMapper = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackDTO, FeedbackViewModel>()).CreateMapper();
            feedbackWithDescriptionMapper = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackDTO,FeedBackWithDescriptionViewModel>()).CreateMapper();
            feedbackDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackViewModel, FeedbackDTO>()).CreateMapper();
        }
        //id==studentId
        [HttpGet("teacher/{studentId}")]
        public FeedBackWithDescriptionViewModel GetFeedBackTeacher(int studentId)
        {
            var feedback = feedbackWithDescriptionMapper.Map<FeedbackDTO, FeedBackWithDescriptionViewModel>(studentService.GetFeedback(studentId, TypeOfFeeadBack.teacher));
            return feedback;
        }

        [HttpGet("expert/{studentId}")]
        public FeedBackWithDescriptionViewModel GetFeedBackExpert(int studentId)
        {
            var feedback = feedbackWithDescriptionMapper.Map<FeedbackDTO, FeedBackWithDescriptionViewModel>(studentService.GetFeedback(studentId, TypeOfFeeadBack.expert));
            return feedback;
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
                studentService.CreateFeedback(studentId, TypeOfFeeadBack.teacher, feedbackDTO);
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
                studentService.CreateFeedback(studentId, TypeOfFeeadBack.expert, feedbackDTO);
                return Ok(feedback);
            }
            return BadRequest(ModelState);
        }
    }
}