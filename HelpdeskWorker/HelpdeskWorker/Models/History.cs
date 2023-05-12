using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class History
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public int? IdDetail { get; set; }

    public int? Type { get; set; }

    public DateTime? Time { get; set; }

    public string? Content { get; set; }

    public string? FullName { get; set; }
}
