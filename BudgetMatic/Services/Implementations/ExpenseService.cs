using BudgetMatic.Models.ViewModels;
using BudgetMatic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetMatic.Services.Implementations;

public class ExpenseService : IExpenseService
{
    public async Task<List<SelectListItem>> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<SelectListItem>> GetPaymentTypesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(ExpenseViewModel model, long userId)
    {
        throw new NotImplementedException();
    }
}
