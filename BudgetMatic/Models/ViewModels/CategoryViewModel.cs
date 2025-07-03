using System.ComponentModel.DataAnnotations;

namespace BudgetMatic.Models.ViewModels
{
    public class CategoryViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Kategori ismi gereklidir.")]
        public string Name { get; set; }
    }
}
