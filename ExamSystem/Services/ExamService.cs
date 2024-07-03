using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;

namespace ExamSystem.Services
{
    public class ExamService : IExamService
    {
        public async Task<ApiResult<ExamResponse>> AddExam(ExamRequest request)
        {
            return ApiResult<ExamResponse>.Ok(new ExamResponse()); ;
        }
    }
}
