using ExamSystem.Data;
using ExamSystem.Dtos;
using ExamSystem.Models;
using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;
using Microsoft.EntityFrameworkCore;

namespace ExamSystem.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> GetAllUsers(PaginationModel model)
        {
            var users = await _context
                              .Users
                              .Select(c => new UserDto
                              {
                                  Email = c.Email,
                                  Name = c.Name,
                                  Password = c.Password,
                                  UserRole = c.UserRole.Name
                              })
                              .Skip((model.PageNumber - 1) * model.PageSize)
                              .Take(model.PageSize)
                              .ToListAsync();

            return users;


        }

        public async Task<ApiResult<UpdateResponse>> Update(int id, UpdateRequest request)
        {
            var user = await _context
                             .Users
                             .Include(c => c.UserRole)
                             .Where(c => c.Id == id)
                             .FirstAsync();

            user.Email = request.Email;
            user.Name = request.Name;
            user.isActive = request.isActive;
            user.Password = user.CreatePassword(request.Password);
            user.EditDate = DateTime.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var response = new UpdateResponse()
            {
                Name = request.Name
            };

            return ApiResult<UpdateResponse>.Ok(response);

        }

        public async Task<ApiResult<UserResponse>> Deactive(int id)
        {
            var user = await _context
                             .Users
                             .Where(c => c.Id == id)
                             .FirstAsync();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            var response = new UserResponse()
            {
                Description = "User Deleted"
            };

            return ApiResult<UserResponse>.Ok(response);
        }

    }

}

