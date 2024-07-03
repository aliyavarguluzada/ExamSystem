using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;

namespace ExamSystem.Services
{
    public interface IExamService
    {
        public Task<ApiResult<ExamResponse>> AddExam(ExamRequest request);
    }
}
