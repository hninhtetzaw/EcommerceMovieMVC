using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class TblOrderItem
{
    public string Id { get; set; } = null!;

    public string? OrderId { get; set; }

    public string? MovieId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual TblMovie? Movie { get; set; }

    public virtual TblOrder? Order { get; set; }
}
