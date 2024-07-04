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
        public async Task<ApiResult<UserResponse>> TeacherRegister(RegisterRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                if (String.IsNullOrEmpty(request.Name)
                       ||
                       String.IsNullOrEmpty(request.Password)
                       ||
                       String.IsNullOrEmpty(request.Email))
                    return ApiResult<UserResponse>.Error("", "Error", StatusCodes.Status406NotAcceptable);
                var newUser = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    UserRoleId = (int)UserRoleEnum.Teacher,
                    isActive = true,
                    EditDate = DateTime.Now,
                    CreateDate = DateTime.Now

                };

                newUser.CreatePassword(request.Password);

                await _context.Users.AddAsync(newUser);
                await transaction.CommitAsync();

                await _context.SaveChangesAsync();

                var response = new UserResponse
                {
                    Name = request.Name,
                    Email = request.Email,

                };
                return ApiResult<UserResponse>.Ok(response);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return ApiResult<UserResponse>.Error("", "Error", StatusCodes.Status400BadRequest);
            }
        }
        public async Task<ApiResult<UserResponse>> AdminRegister(RegisterRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (String.IsNullOrEmpty(request.Name)
                    ||
                    String.IsNullOrEmpty(request.Password)
                    ||
                    String.IsNullOrEmpty(request.Email))
                    return ApiResult<UserResponse>.Error("", "", StatusCodes.Status406NotAcceptable);

                var newUser = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    UserRoleId = (int)UserRoleEnum.Admin,
                    isActive = true,
                    EditDate = DateTime.Now,
                    CreateDate = DateTime.Now

                };

                newUser.CreatePassword(request.Password);

                await _context.Users.AddAsync(newUser);
                await transaction.CommitAsync();
                await _context.SaveChangesAsync();
                var response = new UserResponse
                {
                    Name = request.Name,
                    Email = request.Email
                };


                return ApiResult<UserResponse>.Ok(response);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return ApiResult<UserResponse>.Error("", "Error", StatusCodes.Status400BadRequest);
            }
        }
        public async Task<ApiResult<UserResponse>> StudentRegister(RegisterRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                if (String.IsNullOrEmpty(request.Name)
                   ||
                   String.IsNullOrEmpty(request.Password)
                   ||
                   String.IsNullOrEmpty(request.Email))
                    return ApiResult<UserResponse>.Error("", "", StatusCodes.Status406NotAcceptable);

                var newUser = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    UserRoleId = (int)UserRoleEnum.Student,
                    isActive = true,
                    EditDate = DateTime.Now,
                    CreateDate = DateTime.Now
                };



                var newStudent = new Student
                {
                    CreateDate = DateTime.Now,
                    EditDate = DateTime.Now,
                    Email = request.Email,
                    Name = request.Name,
                    UserRoleId = (int)UserRoleEnum.Student

                };

                newUser.CreatePassword(request.Password);
                newStudent.Password = newUser.Password;


                await _context.Users.AddAsync(newUser);
                await _context.Students.AddAsync(newStudent);
                await transaction.CommitAsync();

                await _context.SaveChangesAsync();

                var response = new UserResponse
                {
                    Name = request.Name,
                    Email = request.Email
                };
                return ApiResult<UserResponse>.Ok(response);

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return ApiResult<UserResponse>.Error("", "Error", StatusCodes.Status400BadRequest);
            }


        }


    }
}
