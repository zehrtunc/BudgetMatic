using System.ComponentModel.DataAnnotations;

namespace BudgetMatic.Models.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email adresi gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçerli bir mail adresi giriniz.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Şifre gereklidir.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
