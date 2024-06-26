using System;
using System.Collections.Generic;

namespace DocumentSharing.Models;

public partial class Post
{
    public string PostId { get; set; } = null!;

    public string? Title { get; set; }

    public string? PostContent { get; set; }

    public bool? PostStatus { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? PublishedDate { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual AppUser? User { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
