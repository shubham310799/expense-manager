using ExpenseManager_Backend.Entities;
using ExpenseManager_Backend.Models;

namespace ExpenseManager_Backend.Repositories.Abstraction
{
    public interface IExpenseGroupRepository
    {
        Task<IList<ExpenseGroupResponse>> GetUserExpenseGroups(int userId);

        Task CreateExpenseGroup(ExpenseGroup expense);
    }
}
