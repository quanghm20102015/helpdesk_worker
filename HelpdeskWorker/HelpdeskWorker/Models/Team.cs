using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdCompany { get; set; }

    public string? Description { get; set; }
}
