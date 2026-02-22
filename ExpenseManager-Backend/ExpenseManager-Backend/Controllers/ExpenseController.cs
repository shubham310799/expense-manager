using ExpenseManager_Backend.Common;
using ExpenseManager_Backend.Models;
using ExpenseManager_Backend.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager_Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/expense")]
    public class ExpenseController
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        [HttpGet("get-all")]
        public async Task<GlobalResponse<IList<ExpenseResponse>>> GetAllExpense()
        {
            var res = new GlobalResponse<IList<ExpenseResponse>>();
            try
            {
                res = await _expenseService.GetUserExpenses();
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
        public async Task<GlobalResponse<bool>> AddExpense([FromBody] AddExpenseRequest req)
        {
            var res = new GlobalResponse<bool>();
            try
            {
                res = await _expenseService.AddExpense(req);
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
