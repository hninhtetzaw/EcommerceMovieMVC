using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class TblUser
{
    public string Id { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? RoleId { get; set; }

    public virtual TblRole? Role { get; set; }
}
