using System;
using System.Collections.Generic;

namespace DocumentSharing.Models;

public partial class Comment
{
    public string CommentId { get; set; } = null!;

    public string? CommentContent { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UserId { get; set; }

    public string? PostId { get; set; }

    public string? ParentCommentId { get; set; }

    public virtual ICollection<Comment> InverseParentComment { get; } = new List<Comment>();

    public virtual Comment? ParentComment { get; set; }

    public virtual Post? Post { get; set; }

    public virtual AppUser? User { get; set; }
}
