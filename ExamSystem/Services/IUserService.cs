using ExamSystem.Dtos;
using ExamSystem.Models;
using ExamSystem.Results;

namespace ExamSystem.Services
{
    public interface IUserService
    {
        public Task<List<UserDto>> GetAllUsers(PaginationModel model);
        
    }
}
