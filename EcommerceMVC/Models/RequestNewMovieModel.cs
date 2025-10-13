using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceMVC.Models
{
    public class RequestNewMovieModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string? Title { get; set; }

        [Required]
        public string? Genre { get; set; }

        [Required]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
    }
}
