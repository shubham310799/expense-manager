using System.ComponentModel.DataAnnotations;

namespace ExpenseManager_Backend.Models
{
    public class SignupRequest
    {
        public required string Name { get; set; }

        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
        public required string Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password doesnot fulfills the criteria")]
        public required string Password { get; set; }
    }
}
