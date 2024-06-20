using System;
using System.Collections.Generic;

namespace DocumentSharing.Models;

public partial class Tag
{
    public string TagId { get; set; } = null!;

    public string? TagName { get; set; }

    public virtual ICollection<Post> Posts { get; } = new List<Post>();
}
