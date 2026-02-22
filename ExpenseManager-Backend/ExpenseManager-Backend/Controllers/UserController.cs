using ExpenseManager_Backend.Common;
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
        public async Task<GlobalResponse<string>> Login(LoginRequest req)
        {
            var res = new GlobalResponse<string>();
            try
            {
                res = await _userService.Login(req);
            }
            catch (Exception ex)
            {
                res.Error = new ErrorDetails
                {
                    ErrorMessage="something went wrong",
                    ErrorCode="SOMETHIG_WENT_WRONG"
                };
            }
            return res;
        }

        [HttpPost("signup")]
        public async Task<GlobalResponse<string>> Signup(SignupRequest req)
        {
            var res = new GlobalResponse<string>();
            try
            {
                res = await _userService.Signup(req);
            }
            catch (Exception ex)
            {
                res.Error = new ErrorDetails
                {
                    ErrorMessage = "something went wrong",
                    ErrorCode = "SOMETHIG_WENT_WRONG"
                };
            }
            return res;
        }
    }
}
