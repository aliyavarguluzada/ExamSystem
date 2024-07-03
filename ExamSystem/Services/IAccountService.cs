using ExamSystem.Entities;
using ExamSystem.Results.Requests;

namespace ExamSystem.Services
{
    public interface IAccountService
    {
        public Task<User> AdminRegister(RegisterRequest request);
        public Task<User> TeacherRegister(RegisterRequest request);
        public Task<User> StudentRegister(RegisterRequest request);
        public Task<string> Login(LoginRequest request);
    }
}
