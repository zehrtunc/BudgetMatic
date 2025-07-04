using AutoMapper;
using BudgetMatic.Data;
using BudgetMatic.Models.Entities;
using BudgetMatic.Models.Enums;
using BudgetMatic.Models.ViewModels;
using BudgetMatic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BudgetMatic.Services.Implementations;

public class ExpenseService : IExpenseService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public ExpenseService(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<List<SelectListItem>> GetCategoriesAsync()
    {
        return await _context.Categories
            .Select(c => new SelectListItem //parantezler () parametreli constructor calisicaksa kullanilir
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToListAsync();
    }

    public async Task<List<SelectListItem>> GetPaymentTypesAsync()
    {
        return Enum.GetValues(typeof(PaymentType)).Cast<PaymentType>()
            .Select(p => new SelectListItem
            {
                Value = ((int)p).ToString(),
                Text = p.ToString()
            }).ToList();
    }

    public async Task<bool> CreateAsync(ExpenseViewModel model, long userId)
    {
        var expense = _mapper.Map<Expense>(model);
        expense.UserId = userId;

        // 2.fazda burasi for dongusu ile guncellenecek 
        expense.ExpenseItems = new List<ExpenseItem>
        {
            new ExpenseItem
            {
                Date = model.StartDate,
                Amount = model.TotalAmount,
                Note = model.Note
            }
        };

        await _context.Expenses.AddAsync(expense);
        await _context.SaveChangesAsync();

        return true;

    }
}
