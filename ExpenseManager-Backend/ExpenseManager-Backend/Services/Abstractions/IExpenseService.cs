using ExpenseManager_Backend.Common;
using ExpenseManager_Backend.Models;

namespace ExpenseManager_Backend.Services.Abstractions
{
    public interface IExpenseService
    {
        Task<GlobalResponse<IList<ExpenseResponse>>> GetUserExpenses();
        Task<GlobalResponse<bool>> AddExpense(AddExpenseRequest req);
    }
}
