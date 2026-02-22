using ExpenseManager_Backend.Datebase;
using ExpenseManager_Backend.Entities;
using ExpenseManager_Backend.Models;
using ExpenseManager_Backend.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager_Backend.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _dbContext;
        public ExpenseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<ExpenseResponse>> GetUserExpenses(int userId)
        {
            return await _dbContext.Expenses.Where(e => e.UserId == userId).Select(x => new ExpenseResponse
            {
                ExpenseID = x.ExpenseId,
                Description = x.Description,
                Name = x.Name,
                Amount = x.Amount,
                CreatedAt = x.CreatedAt,
            }).ToListAsync();
        }

        public async Task AddExpense(Expense expense)
        {
            await _dbContext.AddAsync(expense);
            await _dbContext.SaveChangesAsync();
        }
    }
}
