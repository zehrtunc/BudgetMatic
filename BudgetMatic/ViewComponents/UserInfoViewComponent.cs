using BudgetMatic.Models.Entities;
using BudgetMatic.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BudgetMatic.ViewComponents;

public class UserInfoViewComponent : ViewComponent
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public UserInfoViewComponent(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = new UserInfoViewModel();

        if(_signInManager.IsSignedIn(HttpContext.User))
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            //Dbden cektigimiz user in verilerini modelin verilerine atariz boylece Dbden cektigimiz verileri View`a model araciligi ile veririz

            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Email = user.Email;
        }

        return View("Default", model);
    }
}
