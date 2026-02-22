using ExpenseManager_Backend.Datebase;
using ExpenseManager_Backend.Entities;
using ExpenseManager_Backend.Models;
using ExpenseManager_Backend.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager_Backend.Repositories
{
    public class ExpenseGroupRepository : IExpenseGroupRepository
    {
        private readonly AppDbContext _dbContext;
        public ExpenseGroupRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<ExpenseGroupResponse>> GetUserExpenseGroups(int userId)
        {
            return await _dbContext.ExpenseGroups.Where(e => e.UserId == userId).Select(x => new ExpenseGroupResponse
            {
                GroupId = x.GroupId,
                Description = x.Description,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
            }).ToListAsync();
        }

        public async Task CreateExpenseGroup(ExpenseGroup expense)
        {
            try
            {
                await _dbContext.ExpenseGroups.AddAsync(expense);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
