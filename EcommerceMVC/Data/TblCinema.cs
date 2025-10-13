using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class TblCinema
{
    public string Id { get; set; } = null!;

    public string? Logo { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
