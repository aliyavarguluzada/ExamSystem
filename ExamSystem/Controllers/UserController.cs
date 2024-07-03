using ExamSystem.Dtos;
using ExamSystem.Models;
using ExamSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamSystem.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all"), Authorize(Roles = "Admin")]
        public async Task<List<UserDto>> GetAllUsers([FromQuery] PaginationModel model) => await _userService.GetAllUsers(model);




    }
}
