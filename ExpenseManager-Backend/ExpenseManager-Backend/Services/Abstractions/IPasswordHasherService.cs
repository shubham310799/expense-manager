namespace ExpenseManager_Backend.Services.Abstractions
{
    public interface IPasswordHasherService
    {
        string Hash(string password);
        bool Verify(string hashedPassword, string providedPassword);
    }
}
