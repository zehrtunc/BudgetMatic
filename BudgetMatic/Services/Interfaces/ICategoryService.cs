using BudgetMatic.Models.ViewModels;

namespace BudgetMatic.Services.Interfaces;

public interface ICategoryService
{
    Task<bool> CreateAsync(CategoryViewModel model);

    Task<List<CategoryViewModel>> GetAllAsync();
    Task<CategoryViewModel> GetByIdAsync(long id);
    Task<bool> UpdateAsync(CategoryViewModel model);
    Task<bool> DeleteAsync(long id);
}
