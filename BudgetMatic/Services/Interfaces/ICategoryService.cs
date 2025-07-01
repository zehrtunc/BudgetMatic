using BudgetMatic.Models.ViewModels;

namespace BudgetMatic.Services.Interfaces;

public interface ICategoryService
{
    Task<bool> CreateAsync(CategoryViewModel model);
}
