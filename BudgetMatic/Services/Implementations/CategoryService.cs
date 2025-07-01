using AutoMapper;
using BudgetMatic.Data;
using BudgetMatic.Models.Entities;
using BudgetMatic.Models.ViewModels;
using BudgetMatic.Services.Interfaces;

namespace BudgetMatic.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public CategoryService(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<bool> CreateAsync(CategoryViewModel model)
    {
        var category = _mapper.Map<Category>(model);
        
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return true;
    }
}
