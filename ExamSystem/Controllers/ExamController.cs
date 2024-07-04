using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;
using ExamSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamSystem.Controllers
{
    [ApiController]
    [Route("api/exams")]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpPost("add")]
        public async Task<ApiResult<ExamResponse>> AddExam(ExamRequest request) => await _examService.AddExam(request);
  
        
    }
}
