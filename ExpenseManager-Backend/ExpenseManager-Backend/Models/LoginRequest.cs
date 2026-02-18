using System.ComponentModel.DataAnnotations;

namespace ExpenseManager_Backend.Models
{
    public class LoginRequest
    {
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
        public required string UserId { get; set; }
        public required string Password { get; set; }
    }
}
