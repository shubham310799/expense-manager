namespace ExpenseManager_Backend.Models
{
    public class ExpenseResponse
    {
        public int ExpenseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
