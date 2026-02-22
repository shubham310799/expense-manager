namespace ExpenseManager_Backend.Models
{
    public class AddExpenseRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public float Amount { get; set; }
    }
}
