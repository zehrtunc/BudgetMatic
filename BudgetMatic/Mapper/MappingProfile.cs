using AutoMapper;
using BudgetMatic.Helpers;
using BudgetMatic.Models.Entities;
using BudgetMatic.Models.ViewModels;

namespace BudgetMatic.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryViewModel>().ReverseMap();

        CreateMap<Expense, ExpenseViewModel>().ReverseMap();

        CreateMap<Expense, ExpenseListViewModel>()
            .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType.GetDescription()));


        CreateMap<ExpenseListViewModel, Expense>();

    }
}
