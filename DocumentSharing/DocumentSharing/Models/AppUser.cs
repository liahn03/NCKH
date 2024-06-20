using System;
using System.Collections.Generic;

namespace DocumentSharing.Models;

public partial class AppUser
{
    public string UserId { get; set; } = null!;

    public string? Username { get; set; }

    public string? UserPassword { get; set; }

    public string? Email { get; set; }

    public string? RoleId { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Document> Documents { get; } = new List<Document>();

    public virtual ICollection<Post> Posts { get; } = new List<Post>();

    public virtual AppRole? Role { get; set; }
}
