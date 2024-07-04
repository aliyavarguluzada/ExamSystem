using ExamSystem.Dtos;
using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;

namespace ExamSystem.Services
{
    public interface IMarkService
    {
        public Task<ApiResult<MarkResponse>> Add(MarkRequest request);
        public Task<List<MarkDto>> GetAllMarks();
    }
}
