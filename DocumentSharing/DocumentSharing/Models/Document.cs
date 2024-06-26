using System;
using System.Collections.Generic;

namespace DocumentSharing.Models;

public partial class Document
{
    public string DocId { get; set; } = null!;

    public string? DocName { get; set; }

    public string? DocCategory { get; set; }

    public string? DocUrl { get; set; }

    public bool? DocStatus { get; set; }

    public string? UserId { get; set; }

    public string? UserName { get; set; }

    public string? SubjectId { get; set; }

    public string? SubjectName { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual AppUser? User { get; set; }
}
