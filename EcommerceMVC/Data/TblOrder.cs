using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class TblOrder
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual ICollection<TblOrderItem> TblOrderItems { get; set; } = new List<TblOrderItem>();//one order can have many items

    public virtual TblUser? User { get; set; } // foreign key relationship with user
}
