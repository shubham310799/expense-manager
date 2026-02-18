using ExpenseManager_Backend.Entities;

namespace ExpenseManager_Backend.Repositories.Abstraction
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
