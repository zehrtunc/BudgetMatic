using BudgetMatic.Models.ViewModels;
using BudgetMatic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetMatic.Controllers;

public class AccountController : Controller
{
    private readonly IAuthService _authService;

    public AccountController(IAuthService authService)
    {
        _authService = authService;    
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var result = await _authService.RegisterAsync(model.Email, model.Password, model.Name, model.Surname, model.AvatarPath); 

        if(!result)
        {
            ModelState.AddModelError("", "Bu email adresi zaten var.");
            return View(model);
        }

        return RedirectToAction("Login", "Account");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var result = await _authService.LoginAsync(model.Email, model.Password);

        if (!result)
        {
            ModelState.AddModelError("", "Giriş yapılırken bir sorun oluştu");
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();

        return RedirectToAction("Login", "Account");
    }
}
