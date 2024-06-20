using System;
using System.Collections.Generic;

namespace DocumentSharing.Models;

public partial class Curriculum
{
    public string CurriId { get; set; } = null!;

    public string? CurriYear { get; set; }

    public string? DepartId { get; set; }

    public virtual ICollection<Credit> Credits { get; } = new List<Credit>();

    public virtual Department? Depart { get; set; }
}
