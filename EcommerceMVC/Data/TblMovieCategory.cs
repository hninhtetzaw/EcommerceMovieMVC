using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class TblMovieCategory
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<TblMovie> TblMovies { get; set; } = new List<TblMovie>();
}
