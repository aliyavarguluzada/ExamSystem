using ExamSystem.Dtos;
using ExamSystem.Models;
using ExamSystem.Results;
using ExamSystem.Results.Requests;
using ExamSystem.Results.Responses;
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

        [HttpPost("addRole"), Authorize(Roles = "Admin")]
        public async Task<ApiResult<UserResponse>> AddUserRole([FromBody] string name) => await _userService.AddUserRole(name);

        [HttpPut("update"), Authorize(Roles = "Admin")]
        public async Task<ApiResult<UpdateResponse>> Update(int id, UpdateRequest request) => await _userService.Update(id, request);

        [HttpPut("deactivate"), Authorize(Roles = "Admin")]
        public async Task<ApiResult<UserResponse>> Deactive(int id) => await _userService.Deactive(id);






    }
}
