using BudgetMatic.Models.Entities;
using BudgetMatic.Models.ViewModels;
using BudgetMatic.Services.Implementations;
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

    [HttpGet]
    public async Task<IActionResult> MyMonthlyExpenses()
    {
        var models = await _expenseService.GetMonthlyExpenseAsync();
        return View(models);
    }

    [HttpGet]
    public async Task<IActionResult> MyExpenses()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetExpenses()
    {
        var models = await _expenseService.GetAllAsync();
        return Json(new { data = models });
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
        if (!ModelState.IsValid)
        {
            model.Categories = await _expenseService.GetCategoriesAsync();
            model.PaymentTypes = await _expenseService.GetPaymentTypesAsync();

            return View(model);
        }

        try
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _expenseService.CreateAsync(model, user.Id);

            if (result) return RedirectToAction("MyMonthlyExpenses");
        }
        catch(Exception)
        {
            ModelState.AddModelError("", "Harcama eklenirken bir hata oluştu.");
        }

        model.Categories = await _expenseService.GetCategoriesAsync();
        model.PaymentTypes = await _expenseService.GetPaymentTypesAsync();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var result = await _expenseService.DeleteAsync(id);
            if (result) return RedirectToAction("MyMonthlyExpenses");
        }
        catch(Exception)
        {
            ModelState.AddModelError("", "Haracama silinirken bir hata oluştu.");
        }
        return RedirectToAction("MyMonthlyExpenses");
    }

}
