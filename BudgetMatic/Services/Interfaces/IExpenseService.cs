using BudgetMatic.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetMatic.Services.Interfaces;

public interface IExpenseService
{
    Task<List<SelectListItem>> GetCategoriesAsync();
    Task<List<SelectListItem>> GetPaymentTypesAsync();
    Task<bool> CreateAsync(ExpenseViewModel model, long userId);

    Task<List<MonthlyExpenseListViewModel>> GetMonthlyExpenseAsync();

    Task<List<ExpenseListViewModel>> GetAllAsync();  
    Task<bool> DeleteAsync(long id);


}
