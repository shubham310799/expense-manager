using ExpenseManager_Backend.Services.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace ExpenseManager_Backend.Services
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private readonly PasswordHasher<object> _passwordHasher;
        public PasswordHasherService()
        {
            _passwordHasher = new PasswordHasher<object>();
        }
        public string Hash(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool Verify(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(
                null,
                hashedPassword,
                providedPassword);

            return result == PasswordVerificationResult.Success;
        }
    }
}
