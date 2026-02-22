using ExpenseManager_Backend.Entities;
using ExpenseManager_Backend.Models;

namespace ExpenseManager_Backend.Repositories.Abstraction
{
    public interface IExpenseRepository
    {
        Task<IList<ExpenseResponse>> GetUserExpenses(int userId);

        Task AddExpense(Expense expense);
    }
}
