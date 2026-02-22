using ExpenseManager_Backend.Common;
using ExpenseManager_Backend.Entities;
using ExpenseManager_Backend.Models;
using ExpenseManager_Backend.Repositories.Abstraction;
using ExpenseManager_Backend.Services.Abstractions;

namespace ExpenseManager_Backend.Services
{
    public class ExpenseGroupService : IExpenseGroupService
    {
        private readonly IHttpContextHelper _contextHelper;
        private readonly IExpenseGroupRepository _expenseGroupRepo;
        public ExpenseGroupService(IHttpContextHelper httpHelper, IExpenseGroupRepository expenseGroupRepo)
        {
            _contextHelper = httpHelper;
            _expenseGroupRepo = expenseGroupRepo;
        }
        public async Task<GlobalResponse<IList<ExpenseGroupResponse>>> GetUserExpenseGroups()
        {
            var res = new GlobalResponse<IList<ExpenseGroupResponse>>();
            try
            {
                var userId = _contextHelper.GetUserId();
                res.Data = await _expenseGroupRepo.GetUserExpenseGroups(userId);
            }
            catch (Exception ex)
            {
                res.Error = new ErrorDetails
                {
                    ErrorCode = "SWW"
                };
            }
            return res;
        }

        public async Task<GlobalResponse<bool>> CreateExpenseGroup(CreateExpenseGroupReq req)
        {
            var res = new GlobalResponse<bool>();
            try
            {
                var userId = _contextHelper.GetUserId();
                var expense = new ExpenseGroup
                {
                    Name = req.Name,
                    Description = req.Description,
                    UserId = userId,
                };
                await _expenseGroupRepo.CreateExpenseGroup(expense);
                res.Data = true;
            }
            catch
            {
                res.Error = new ErrorDetails
                {
                    ErrorCode = "sww"
                };
            }
            return res;
        }
    }
}
