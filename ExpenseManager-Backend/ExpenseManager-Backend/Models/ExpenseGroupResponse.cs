namespace ExpenseManager_Backend.Models
{
    public class ExpenseGroupResponse
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
