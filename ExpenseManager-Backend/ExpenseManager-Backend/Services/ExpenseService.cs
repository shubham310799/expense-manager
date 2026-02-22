using ExpenseManager_Backend.Common;
using ExpenseManager_Backend.Datebase;
using ExpenseManager_Backend.Entities;
using ExpenseManager_Backend.Models;
using ExpenseManager_Backend.Repositories.Abstraction;
using ExpenseManager_Backend.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager_Backend.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IHttpContextHelper _contextHelper;
        private readonly IExpenseRepository _expenseRepo;
        public ExpenseService(IHttpContextHelper httpHelper, IExpenseRepository expenseRepo)
        {
            _contextHelper = httpHelper;
            _expenseRepo = expenseRepo;
        }
        public async Task<GlobalResponse<IList<ExpenseResponse>>> GetUserExpenses()
        {
            var res = new GlobalResponse<IList<ExpenseResponse>>();
            try
            {
                var userId = _contextHelper.GetUserId();
                res.Data = await _expenseRepo.GetUserExpenses(userId);
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

        public async Task<GlobalResponse<bool>> AddExpense(AddExpenseRequest req)
        {
            var res = new GlobalResponse<bool>();
            try
            {
                var userId = _contextHelper.GetUserId();
                var expense = new Expense
                {
                    Name = req.Name,
                    Amount = req.Amount,
                    Description = req.Description,
                };
                await _expenseRepo.AddExpense(expense);
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
