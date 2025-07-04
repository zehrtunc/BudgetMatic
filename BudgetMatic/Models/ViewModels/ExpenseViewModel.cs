using BudgetMatic.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace BudgetMatic.Models.ViewModels;

public class ExpenseViewModel
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Tarih zorunludur.")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }


    [Required(ErrorMessage = "Harcama tutarını girmek zorunludur.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Tutar 0'dan büyük olmalıdır.")]
    public decimal TotalAmount { get; set; }

    public string? Note { get; set; }

    [Required(ErrorMessage = "Ödeme tipini seçmek zorunludur.")]
    public PaymentType PaymentType { get; set; }

    public int? InstallmentCount { get; set; }

    [Required(ErrorMessage = "Kategori alanını seçmek zorunludur.")]
    public long CategoryId { get; set; }

    public List<SelectListItem>? Categories { get; set; } 
    public List<SelectListItem>? PaymentTypes { get; set; } 
}
