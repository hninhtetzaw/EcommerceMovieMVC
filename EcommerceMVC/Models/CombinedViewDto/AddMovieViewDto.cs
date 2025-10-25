using EcommerceMVC.Models.CategoryDtos;

namespace EcommerceMVC.Models.CombinedViewDto
{
    public class AddMovieViewDto
    {
        public RequestNewMovieModel MovieRequest { get; set; }
        public List<ResponseCategoryDto> CategoriesList { get; set; }
    }
}
