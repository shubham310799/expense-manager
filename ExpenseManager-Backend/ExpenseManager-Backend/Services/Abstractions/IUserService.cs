using ExpenseManager_Backend.Common;
using ExpenseManager_Backend.Entities;
using ExpenseManager_Backend.Models;

namespace ExpenseManager_Backend.Services.Abstractions
{
    public interface IUserService
    {
        Task<GlobalResponse<string>> Login(LoginRequest req);
        Task<GlobalResponse<string>> Signup(SignupRequest req);
    }
}
