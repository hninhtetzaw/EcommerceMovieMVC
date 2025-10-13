using EcommerceMVC.Models.CategoryDtos;

namespace EcommerceMVC.Interfaces.IServices
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