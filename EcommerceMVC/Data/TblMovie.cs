using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class TblMovie
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? CategoryId { get; set; }

    public virtual TblMovieCategory? Category { get; set; }
}
