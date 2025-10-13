
using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models.CategoryDtos;

namespace EcommerceMVC.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public List<ResponseCategoryDto> GetAllCategories()
        {
            var lists = _repo.GetAllCategoryAsync();
            var categoryLists = lists.Select(c => new ResponseCategoryDto
            {
              Name = c.Name 
            }).ToList();

            //var count = categoryLists.Count();
            return categoryLists;
        }

        public ResponseCategoryDto AddCategory(RequestNewCategoryDto request)
        {
            var newCategory = new TblMovieCategory
            {
                Id = request.Id,
                Name = request.Name,

            };
            var response = _repo.AddCategoryAsync(newCategory);
            return null;
        }
        public ResponseCategoryDto GetCategoryById(string id)
        {
            return null;

        }
        public ResponseCategoryDto UpdateCategory(string id, UpdateCategoryDto request)
        {
            return null;

        }
        public ResponseCategoryDto DeleteCategory(string id)
        {
            return null;

        }
    }
}