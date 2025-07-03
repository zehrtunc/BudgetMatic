using AutoMapper;
using BudgetMatic.Data;
using BudgetMatic.Models.Entities;
using BudgetMatic.Models.ViewModels;
using BudgetMatic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<CategoryViewModel>> GetAllAsync()
    {
        var categories = await _context.Categories.ToListAsync();

        var models = _mapper.Map<List<CategoryViewModel>>(categories);

        return models;
    }

    public async Task<CategoryViewModel> GetByIdAsync(long id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null) throw new Exception("Güncellenmek istediğiniz kategori bulunamadı");

        var model = _mapper.Map<CategoryViewModel>(category);

        return model;
    }

    public async Task<bool> UpdateAsync(CategoryViewModel model)
    {
        var category = await _context.Categories.FindAsync(model.Id);

        if (category == null) throw new Exception("Güncellemek istediğiniz kategori bulunamadı.");

        _mapper.Map(model, category); // Modeldeki veriler ayni idli category entitisi uzerine yazilir

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null) throw new Exception("Silmek istediğiniz kategori bulunamadı.");

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return true;
    }
}
