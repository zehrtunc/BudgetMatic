namespace BudgetMatic.Services.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterAsync(string email, string password, string name, string surname);
    Task<bool> LoginAsync(string email, string password);
    Task LogoutAsync();
}
