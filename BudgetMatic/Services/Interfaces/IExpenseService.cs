using BudgetMatic.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetMatic.Services.Interfaces;

public interface IExpenseService
{
    Task<List<SelectListItem>> GetCategoriesAsync();
    Task<List<SelectListItem>> GetPaymentTypesAsync();
    Task<bool> CreateAsync(ExpenseViewModel model, long userId);

}
