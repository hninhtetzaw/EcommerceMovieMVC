namespace EcommerceMVC.Models.CategoryDtos
{
    public class RequestNewCategoryDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

    }
}