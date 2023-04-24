using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class Company
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;
}
