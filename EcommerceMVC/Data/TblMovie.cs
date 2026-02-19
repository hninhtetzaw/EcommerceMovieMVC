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

    public string? CinemaId { get; set; }

    public string? ProducerId { get; set; }

    public virtual TblMovieCategory? Category { get; set; }

    public virtual TblActor? Cinema { get; set; }

    public virtual TblProducer? Producer { get; set; }

    public virtual ICollection<TblActorMovie> TblActorMovies { get; set; } = new List<TblActorMovie>();

    public virtual ICollection<TblOrderItem> TblOrderItems { get; set; } = new List<TblOrderItem>();
}
