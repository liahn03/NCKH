using System;
using System.Collections.Generic;

namespace DocumentSharing.Models;

public partial class Credit
{
    public string SubjectId { get; set; } = null!;

    public string CurriId { get; set; } = null!;

    public int? Theory { get; set; }

    public int? Practical { get; set; }

    public virtual Curriculum Curri { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
