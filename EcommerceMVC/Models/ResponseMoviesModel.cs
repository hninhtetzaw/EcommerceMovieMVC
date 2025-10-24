using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace EcommerceMVC.Models
{
    public class ResponseMoviesModel
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }

        [DisplayName("Release Date")]
        [DataType(DataType.Date)]

        public string? ImageUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
