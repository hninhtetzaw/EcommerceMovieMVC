using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class TblActorMovie
{
    public string Id { get; set; } = null!;

    public string? MovieId { get; set; }

    public string ActorId { get; set; } = null!;

    public virtual TblActor Actor { get; set; } = null!;

    public virtual TblMovie? Movie { get; set; }
}
