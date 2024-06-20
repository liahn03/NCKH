using System;
using System.Collections.Generic;

namespace DocumentSharing.Models;

public partial class AppRole
{
    public string RoleId { get; set; } = null!;

    public string? RoleName { get; set; }

    public virtual ICollection<AppUser> AppUsers { get; } = new List<AppUser>();
}
