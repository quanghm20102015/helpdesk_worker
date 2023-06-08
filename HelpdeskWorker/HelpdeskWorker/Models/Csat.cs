using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class Csat
{
    public int Id { get; set; }

    public int IdFeedBack { get; set; }

    public string? DescriptionFeedBack { get; set; }

    public int IdCompany { get; set; }

    public string IdGuIdEmailInfo { get; set; } = null!;

    public DateTime DateTime { get; set; }
}
