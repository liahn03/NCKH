using System;
using System.Collections.Generic;

namespace DocumentSharing.Models;

public partial class Subject
{
    public string SubjectId { get; set; } = null!;

    public string? SubjectName { get; set; }

    public string? SubCategory { get; set; }

    public virtual ICollection<Credit> Credits { get; } = new List<Credit>();

    public virtual ICollection<Document> Documents { get; } = new List<Document>();
}
