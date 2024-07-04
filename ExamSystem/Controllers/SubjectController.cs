using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;
using ExamSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamSystem.Controllers
{
    [ApiController]
    [Route("api/subjects")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost("add")]
        public async Task<ApiResult<SubjectResponse>> AddSubject(SubjectRequest request) => await _subjectService.AddSubject(request);

        [HttpPut("update/{id}")]
        public async Task<ApiResult<SubjectResponse>> Update([FromRoute] int id, [FromBody] SubjectRequest request) => await _subjectService.Update(id, request);

        [HttpPut("deactivate/{id}")]
        public async Task<ApiResult<SubjectResponse>> Deactivate([FromRoute] int id) => await _subjectService.Deactivate(id);

    }
}
