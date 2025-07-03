using BudgetMatic.Models.Entities;
using BudgetMatic.Models.ViewModels;
using BudgetMatic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BudgetMatic.Controllers;

public class ExpenseController : Controller
{
    private readonly IExpenseService _expenseService;
    private readonly UserManager<AppUser> _userManager;
    public ExpenseController(IExpenseService expenseService, UserManager<AppUser> userManager)
    {
        _expenseService = expenseService;
        _userManager = userManager;
    }
    public IActionResult Myexpenses()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new ExpenseViewModel()
        {
            StartDate = DateTime.Today,
            Categories = await _expenseService.GetCategoriesAsync(),
            PaymentTypes = await _expenseService.GetPaymentTypesAsync()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ExpenseViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.Categories = await _expenseService.GetCategoriesAsync();
            model.PaymentTypes = await _expenseService.GetPaymentTypesAsync();

            return View(model);
        }

        try
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _expenseService.CreateAsync(model, user.Id);

            if (result) return RedirectToAction("MyExpenses");
        }
        catch(Exception)
        {
            ModelState.AddModelError("", "Harcama eklenirken bir hata oluştu.");
        }

        model.Categories = await _expenseService.GetCategoriesAsync();
        model.PaymentTypes = await _expenseService.GetPaymentTypesAsync();

        return View(model);
    }
}
