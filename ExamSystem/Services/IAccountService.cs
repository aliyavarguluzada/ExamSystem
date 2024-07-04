using ExamSystem.Entities;
using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;

namespace ExamSystem.Services
{
    public interface IAccountService
    {
        public Task<ApiResult<UserResponse>> Login(LoginRequest request);
    }
}
