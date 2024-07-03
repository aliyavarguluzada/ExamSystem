using ExamSystem.Entities;

namespace ExamSystem.Services
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
        public string ValidateToken(string token);
    }
}
