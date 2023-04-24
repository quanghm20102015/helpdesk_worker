using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public string? Company { get; set; }

    public string? Workemail { get; set; }

    public string? Password { get; set; }

    public int IdCompany { get; set; }
}
