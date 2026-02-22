using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManager_Backend.Entities
{
    [Table("expense")]
    public class Expense
    {
        [Column("expense_id")]
        [Key]
        public int ExpenseId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("amount")]
        public float Amount { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("descr")]
        public string Description { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User User { get; set; }
    }
}
