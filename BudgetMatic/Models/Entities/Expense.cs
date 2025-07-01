using BudgetMatic.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetMatic.Models.Entities;

public class Expense
{
    public long Id { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    public int? InstallmentCount { get; set; }

    public PayementType PaymentType { get; set; }

    public long CategoryId { get; set; }
    public virtual Category Category { get; set; }

    public long UserId { get; set; }
    public virtual AppUser User { get; set; }

    public virtual ICollection<ExpenseItem> ExpenseItems { get; set; }
}
