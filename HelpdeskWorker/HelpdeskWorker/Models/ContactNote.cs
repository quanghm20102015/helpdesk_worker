using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class ContactNote
{
    public int Id { get; set; }

    public int IdContact { get; set; }

    public string Note { get; set; } = null!;
}
