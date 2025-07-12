using BudgetMatic.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetMatic.Services.Interfaces;

public interface IExpenseService
{
    Task<List<SelectListItem>> GetCategoriesAsync();
    Task<List<SelectListItem>> GetPaymentTypesAsync();
    Task<bool> CreateAsync(ExpenseViewModel model, long userId);

    Task<List<MonthlyExpenseListViewModel>> GetMonthlyExpenseAsync(long userId);

    Task<List<ExpenseListViewModel>> GetAllAsync(long userId);  
    Task<bool> DeleteAsync(long id);


}
