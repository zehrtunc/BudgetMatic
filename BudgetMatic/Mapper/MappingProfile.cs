using AutoMapper;
using BudgetMatic.Models.Entities;
using BudgetMatic.Models.ViewModels;

namespace BudgetMatic.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryViewModel>().ReverseMap();

        CreateMap<Expense, ExpenseViewModel>().ReverseMap();

    }
}
