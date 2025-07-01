using System.ComponentModel.DataAnnotations;

namespace BudgetMatic.Models.ViewModels;

public class RegisterViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }

    [Required(ErrorMessage = "Email adresi gereklidir.")]
    [EmailAddress(ErrorMessage = "Geçerli bir mail adresi giriniz.")]
    public string Email { get; set; }

    [Required(ErrorMessage ="Şifre gereklidir.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage ="Şifre doğrulama gereklidir.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor!")]
    public string ConfirmPassword { get; set; }
}
