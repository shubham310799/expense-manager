using ExpenseManager_Backend.Entities;

namespace ExpenseManager_Backend.Services.Abstractions
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
