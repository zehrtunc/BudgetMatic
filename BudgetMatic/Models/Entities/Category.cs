using System.ComponentModel.DataAnnotations;

namespace BudgetMatic.Models.Entities
{
    public class Category
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
