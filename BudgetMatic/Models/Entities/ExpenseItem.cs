using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetMatic.Models.Entities
{
    public class ExpenseItem
    {
        public long Id { get; set; }

        [Required]
        public DateTime Date { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string? Note { get; set; }

        public long ExpenseId { get; set; }
        public virtual Expense Expense { get; set; }
    }
}
