using System.ComponentModel.DataAnnotations;

namespace BudgetMatic.Models.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Kategori ismi gereklidir.")]
        public string Name { get; set; }
    }
}
