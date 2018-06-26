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
        [HttpGet("getTeacher/{id}")]
        public FeedBackWithDescriptionViewModel GetFeedBackTeacher(int id)
        {
            var feedback = feedbackWithDescriptionMapper.Map<FeedbackDTO, FeedBackWithDescriptionViewModel>(studentService.GetFeedback(id, TypeOfFeeadBack.teacher));
            return feedback;
        }

        [HttpGet("getExpert/{id}")]
        public FeedBackWithDescriptionViewModel GetFeedBackExpert(int id)
        {
            var feedback = feedbackWithDescriptionMapper.Map<FeedbackDTO, FeedBackWithDescriptionViewModel>(studentService.GetFeedback(id, TypeOfFeeadBack.expert));
            return feedback;
        }

        [HttpPut]  // [HttpPut("update")]
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
    }
}