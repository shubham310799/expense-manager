using ExpenseManager_Backend.Datebase;
using ExpenseManager_Backend.Entities;
using ExpenseManager_Backend.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager_Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(User user)
        {
            try
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework like Serilog, NLog, etc.)
                Console.WriteLine($"An error occurred while adding a user: {ex.Message}");
            }
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework like Serilog, NLog, etc.)
                Console.WriteLine($"An error occurred while fetching user by email: {ex.Message}");
                return null;
            }
        }
    }
}
