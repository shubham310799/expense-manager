namespace ExpenseManager_Backend.Models
{
    public class CreateExpenseGroupReq
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
