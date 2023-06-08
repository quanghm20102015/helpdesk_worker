using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class EmailInfoAttach
{
    public int Id { get; set; }

    public int IdEmailInfo { get; set; }

    public string? PathFile { get; set; }

    public DateTime? FileName { get; set; }
}
