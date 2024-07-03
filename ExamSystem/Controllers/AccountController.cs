using ExamSystem.Entities;
using ExamSystem.Results.Requests;
using ExamSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamSystem.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) => _accountService = accountService;

        [HttpPost("studentRegister")]
        public async Task<User> StudentRegister(RegisterRequest request) => await _accountService.StudentRegister(request);

        [HttpPost("adminRegister")]
        public async Task<User> AdminRegister(RegisterRequest request) => await _accountService.AdminRegister(request); 
        
        [HttpPost("teacherRegister")]
        public async Task<User> TeacherRegister(RegisterRequest request) => await _accountService.TeacherRegister(request);


        [HttpPost("login")]
        public async Task<string> Login(LoginRequest request) => await _accountService.Login(request);
    }
}
