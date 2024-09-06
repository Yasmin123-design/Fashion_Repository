using ClothesStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _repository;
        public CategoryMenu(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _repository.GetCategories();
            return View(categories);
        }
    }
}
