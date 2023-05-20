using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class Status
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public int Sort { get; set; }
}
