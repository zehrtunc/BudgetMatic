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

        [HttpGet]
        public IActionResult MyCategories()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var models = await _categoryService.GetAllAsync();
            return Json(new { data = models });
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

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var model = await _categoryService.GetByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var result = await _categoryService.UpdateAsync(model);
                if (result) return RedirectToAction("MyCategories");
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Kategori güncellenirken bir hata oluştu.");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _categoryService.DeleteAsync(id);
                if (result) return RedirectToAction("MyCategories");
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Kategori silinirken bir hata oluştu.");
            }
            return RedirectToAction("MyCategories");
        }
    }
}
