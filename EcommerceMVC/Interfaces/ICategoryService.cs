
using MovieMVC.Interfaces;
using MovieMVC.Models;

namespace MovieMVC.Interfaces
{
    public interface ICategoryService
    {
        List<ResponseCategoryDto> GetAllCategories();

        ResponseCategoryDto AddCategory(RequestNewCategoryDto request);
        ResponseCategoryDto GetCategoryById(string id);
        ResponseCategoryDto UpdateCategory(string id, UpdateCategoryDto request);
        ResponseCategoryDto DeleteCategory(string id);
    }
}