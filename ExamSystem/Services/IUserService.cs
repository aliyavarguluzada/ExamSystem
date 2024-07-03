using ExamSystem.Dtos;
using ExamSystem.Models;
using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;

namespace ExamSystem.Services
{
    public interface IUserService
    {
        public Task<List<UserDto>> GetAllUsers(PaginationModel model);
        public Task<ApiResult<UpdateResponse>> Update(int id, UpdateRequest request);

        public Task<ApiResult<UserResponse>> Deactive(int id);

    }
}
