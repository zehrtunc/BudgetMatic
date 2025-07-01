using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BudgetMatic.Models.Entities;

public class AppUser : IdentityUser<long>
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public string Surname { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; }
}
