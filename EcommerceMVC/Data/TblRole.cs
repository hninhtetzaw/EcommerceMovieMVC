using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class TblRole
{
    public string Id { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
