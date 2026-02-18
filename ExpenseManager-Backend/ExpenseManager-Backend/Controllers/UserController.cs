using ExpenseManager_Backend.Models;
using ExpenseManager_Backend.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager_Backend.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest req)
        {
            try
            {
                var res = await _userService.Login(req);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(SignupRequest req)
        {
            try
            {
                await _userService.Signup(req);
                return Ok(req);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
