using ExamSystem.Data;
using ExamSystem.Dtos;
using ExamSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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

    }

}

