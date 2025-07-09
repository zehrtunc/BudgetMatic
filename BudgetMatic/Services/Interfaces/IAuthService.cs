namespace BudgetMatic.Services.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterAsync(string email, string password, string name, string surname, string avatarPath);
    Task<bool> LoginAsync(string email, string password);
    Task LogoutAsync();
}
