using System;
using System.Collections.Generic;

namespace DocumentSharing.Models;

public partial class Department
{
    public string DepartId { get; set; } = null!;

    public string? DepartName { get; set; }

    public virtual ICollection<Curriculum> Curricula { get; } = new List<Curriculum>();
}
