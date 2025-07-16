using AutoMapper;
using BudgetMatic.Data;
using BudgetMatic.Helpers;
using BudgetMatic.Models.Entities;
using BudgetMatic.Models.Enums;
using BudgetMatic.Models.ViewModels;
using BudgetMatic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Collections.Generic;

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
                Text = p.GetDescription()
            }).ToList();
    }

    public async Task<bool> CreateAsync(ExpenseViewModel model, long userId)
    {
        var expense = _mapper.Map<Expense>(model);
        expense.UserId = userId;

        expense.ExpenseItems = new List<ExpenseItem>();

        if (expense.PaymentType == PaymentType.OneTime)
        {
            expense.ExpenseItems.Add(new ExpenseItem
            {
                Date = model.StartDate,
                Amount = model.TotalAmount
            });
        }

        if (model.InstallmentCount.HasValue && model.InstallmentCount > 1)
        {
            decimal monthlyAmount = 0;
            decimal difference = 0;

            for (int i = 0; i < expense.InstallmentCount.Value; i++)
            {

                if (expense.PaymentType == PaymentType.Installment)
                {
                    monthlyAmount = Math.Round(model.TotalAmount / model.InstallmentCount.Value, 2);
                    difference = model.TotalAmount - (monthlyAmount * model.InstallmentCount.Value);

                    // Son taksite kurus farkini yansit
                    if (i == expense.InstallmentCount.Value - 1)
                        monthlyAmount += difference;
                    
                }

                else if (expense.PaymentType == PaymentType.Subscription)
                    monthlyAmount = Math.Round(model.TotalAmount, 2);


                expense.ExpenseItems.Add(new ExpenseItem
                {
                    Date = model.StartDate.AddMonths(i),
                    Amount = monthlyAmount
                });
            }
        }

        await _context.Expenses.AddAsync(expense);
        await _context.SaveChangesAsync();

        return true;

    }

    public async Task<List<MonthlyExpenseListViewModel>> GetMonthlyExpenseAsync(long userId)
    {
        var expenses = await _context.Expenses.Where(x => x.UserId == userId).ToListAsync();
        var viewModels = new List<MonthlyExpenseListViewModel>();

        foreach (var expense in expenses)
        {
            var viewModel = new MonthlyExpenseListViewModel
            {
                Id = expense.Id,
                CategoryName = expense.Category.Name,
                Note = expense.Note
            };

            foreach (var expenseItem in expense.ExpenseItems)
            {
                int monthIndex = expenseItem.Date.Month - 1;
                viewModel.MonthlyAmounts[monthIndex] = expenseItem.Amount;
            }

            viewModels.Add(viewModel);
        }

        return viewModels;
    }

    public async Task<List<ExpenseListViewModel>> GetAllAsync(long userId)
    {
        var expenses = await _context.Expenses.Where(x => x.UserId ==userId).ToListAsync();

        return _mapper.Map<List<ExpenseListViewModel>>(expenses);
    }


    public async Task<bool> DeleteAsync(long id)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null) throw new Exception("Silmek istediğiniz harcama bulunamadı.");

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();

        return true;

    }

 
}
