using ExpenseManager_Backend.Common;
using ExpenseManager_Backend.Models;

namespace ExpenseManager_Backend.Services.Abstractions
{
    public interface IExpenseGroupService
    {
        Task<GlobalResponse<IList<ExpenseGroupResponse>>> GetUserExpenseGroups();
        Task<GlobalResponse<bool>> CreateExpenseGroup(CreateExpenseGroupReq req);
    }
}
