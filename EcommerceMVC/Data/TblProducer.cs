using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class TblProducer
{
    public string Id { get; set; } = null!;

    public string ProfilePictureUrl { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Bio { get; set; }

    public virtual ICollection<TblMovie> TblMovies { get; set; } = new List<TblMovie>();
}
