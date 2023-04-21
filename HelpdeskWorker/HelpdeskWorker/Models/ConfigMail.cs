using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class ConfigMail
{
    public int Id { get; set; }

    public string YourName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Incoming { get; set; }

    public int? IncomingPort { get; set; }

    public string? Outgoing { get; set; }

    public int? OutgoingPort { get; set; }
}
