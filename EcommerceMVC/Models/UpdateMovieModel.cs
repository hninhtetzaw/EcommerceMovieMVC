using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieMVC.Models;

public class UpdateMovieModel
{
    public string Id { get; set; } 
    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Genre { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [DataType(DataType.Date)]
    public DateTime? ReleaseDate { get; set; }
}
