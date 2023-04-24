using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class EmailInfo
{
    public int Id { get; set; }

    public int IdConfigEmail { get; set; }

    public string? MessageId { get; set; }

    public DateTime? Date { get; set; }

    public string? From { get; set; }

    public string? FromName { get; set; }

    public string? To { get; set; }

    public string? Cc { get; set; }

    public string? Bcc { get; set; }

    public string? Subject { get; set; }

    public string? TextBody { get; set; }
}
