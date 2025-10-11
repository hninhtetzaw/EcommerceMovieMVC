
using MovieMVC.Models;

namespace MovieMVC.Models
{
    public class RequestNewCategoryDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

    }
}