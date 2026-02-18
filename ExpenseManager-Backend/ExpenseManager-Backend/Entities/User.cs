using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManager_Backend.Entities
{
    [Table("users")]
    public class User
    {
        [Column("user_id")]
        [Key]
        public int UserId { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("password_hash")]
        public required string Password { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;
    }
}
