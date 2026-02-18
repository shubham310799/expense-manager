using ExpenseManager_Backend.Common;
using ExpenseManager_Backend.Datebase;
using ExpenseManager_Backend.Entities;
using ExpenseManager_Backend.Models;
using ExpenseManager_Backend.Repositories.Abstraction;
using ExpenseManager_Backend.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IPasswordHasherService passwordHasher, IJwtTokenService jwtTokenService, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
            _logger = logger;
        }
        public async Task<GlobalResponse<string>> Login(LoginRequest req)
        {
            var res = new GlobalResponse<string>();
            try
            {
                var user = await _userRepository.GetByEmailAsync(req.UserId);
                if (user == null)
                {
                    res.Error = new ErrorDetails
                    {
                        ErrorMessage = "User does not exists!",
                        ErrorCode = "USER_DOESNOT_EXISTS"
                    };
                    return res;
                }
                if (!_passwordHasher.Verify(user.Password, req.Password))
                {
                    res.Error = new ErrorDetails
                    {
                        ErrorMessage = "Entered password is incorrect!",
                        ErrorCode = "INCORRECT_PASSWORD"
                    };
                    return res;
                }
                res.Data = _jwtTokenService.GenerateToken(user);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error when user trying to login - {ex.Message}");
                res.Error = new ErrorDetails
                {
                    ErrorCode = "SOMETHING_WENT_WRONG",
                    ErrorMessage = "Something went wrong"
                };
            }
            return res;
        }

        public async Task<GlobalResponse<string>> Signup(SignupRequest req)
        {
            var res = new GlobalResponse<string>();
            try
            {
                var existingUser = await _userRepository.GetByEmailAsync(req.Email);
                if (existingUser != null)
                {
                    res.Error = new ErrorDetails
                    {
                        ErrorMessage = "User does not exists!",
                        ErrorCode = "USER_DOESNOT_EXISTS"
                    };
                    return res;
                }
                User newUser = new User
                {
                    Name = req.Name,
                    Email = req.Email,
                    Password = _passwordHasher.Hash(req.Password)
                };
                await _userRepository.AddAsync(newUser);
                res.Data = "User Created!";
            }
            catch (Exception ex)
            {
                _logger.LogError($"error occurred when trying to create enw user {ex.Message}");
                res.Error = new ErrorDetails
                {
                    ErrorMessage = "Something Went Wrong!",
                    ErrorCode = "SOMETHING_WENT_WRONG"
                };
            }
            return res;
        }
    }
}
