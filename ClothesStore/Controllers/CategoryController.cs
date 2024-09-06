using ClothesStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController (ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Invoke()
        {
            var categories = _categoryRepository.GetCategories();
            return View(categories);
        }
    }
}
