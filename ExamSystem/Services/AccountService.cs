using ExamSystem.Data;
using ExamSystem.Entities;
using ExamSystem.Enum;
using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;
using Microsoft.EntityFrameworkCore;

namespace ExamSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public AccountService(IAuthService authService, ApplicationDbContext context)
        {
            _authService = authService;
            _context = context;
        }

        public async Task<ApiResult<UserResponse>> Login(LoginRequest request)
        {
            try
            {
                if (String.IsNullOrEmpty(request.Password)
                           ||
                           String.IsNullOrEmpty(request.Email))
                    return ApiResult<UserResponse>.Error("", "Error", StatusCodes.Status406NotAcceptable);


                var user = await _context.Users.Where(c => c.Email == request.Email)
                    .Include(c => c.UserRole)
                    .FirstAsync();

                if (user is null)
                    return ApiResult<UserResponse>.Error("", "No such User exists", StatusCodes.Status406NotAcceptable);


                var validatePass = user.VerifyPassword(request.Password);

                if (validatePass is false)
                    return ApiResult<UserResponse>.Error("", "Password is wrong", StatusCodes.Status406NotAcceptable);

                var token = _authService.GenerateToken(user);

                var response = new UserResponse
                {
                    Email = request.Email,
                    Token = token
                };

                return ApiResult<UserResponse>.Ok(response);
            }
            catch (Exception)
            {
                return ApiResult<UserResponse>.Error("", "Error", StatusCodes.Status400BadRequest);
            }
        }
        


    }
}
