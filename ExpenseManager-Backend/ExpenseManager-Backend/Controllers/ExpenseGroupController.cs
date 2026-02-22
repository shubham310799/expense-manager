using ExpenseManager_Backend.Common;
using ExpenseManager_Backend.Models;
using ExpenseManager_Backend.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager_Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/expense-group")]
    public class ExpenseGroupController
    {
        private readonly IExpenseGroupService _expensGroupService;
        public ExpenseGroupController(IExpenseGroupService expenseGroupService)
        {
            _expensGroupService = expenseGroupService;
        }
        [HttpGet("get-all")]
        public async Task<GlobalResponse<IList<ExpenseGroupResponse>>> GetAllExpense()
        {
            var res = new GlobalResponse<IList<ExpenseGroupResponse>>();
            try
            {
                res = await _expensGroupService.GetUserExpenseGroups();
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

        [HttpPost("create")]
        public async Task<GlobalResponse<bool>> AddExpense([FromBody] CreateExpenseGroupReq req)
        {
            var res = new GlobalResponse<bool>();
            try
            {
                res = await _expensGroupService.CreateExpenseGroup(req);
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
    }
}
