using BudgetMatic.Models.ViewModels;
using BudgetMatic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetMatic.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult MyCategories()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var result = await _categoryService.CreateAsync(model);

                if (result) return RedirectToAction("MyCategories");
            }
            catch(Exception)
            {
                //result false düştüğünde 

                ModelState.AddModelError("", "Kategori eklenirken bir hata oluştu.");
            }
            return View(model);
        }
    }
}
