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

    //properties for relationships
    public string? CategoryId { get; set; }

    public string? CinemaId { get; set; }

    public string? ProducerId { get; set; }

    // Navigation properties for relationships (many to one)
    public virtual TblMovieCategory? Category { get; set; }

    public virtual TblActor? Cinema { get; set; }

    public virtual TblProducer? Producer { get; set; }

    //for many to many relationship
    public virtual ICollection<TblActorMovie> TblActorMovies { get; set; } = new List<TblActorMovie>();
}
