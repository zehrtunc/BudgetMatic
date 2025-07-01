using BudgetMatic.Models.Entities;
using BudgetMatic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BudgetMatic.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> RegisterAsync(string email, string password, string name, string surname)
    {
        // var olan user var mi varsa register islemi yapilamasin
        var existingUser = await _userManager.FindByEmailAsync(email);

        if (existingUser != null) return false;

        // Var olan bir user yoksa, user olusturulacaksa 

        var user = new AppUser()
        {
            UserName = email,
            Email = email,
            Name = name,
            Surname = surname
        };

        //Db`de user ekleme
        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var existingUser = await _userManager.FindByEmailAsync(email);

        if(existingUser == null)
        {
            return false;
        }

        var result = await _signInManager.CheckPasswordSignInAsync(existingUser, password, lockoutOnFailure: false);

        if (!result.Succeeded) return false;

        await _signInManager.SignInAsync(existingUser, isPersistent: false);
        return true;
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
