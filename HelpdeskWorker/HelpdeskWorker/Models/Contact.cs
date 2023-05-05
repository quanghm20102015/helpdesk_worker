using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public string? Email { get; set; }

    public string? Bio { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Company { get; set; }

    public int? Country { get; set; }

    public string? City { get; set; }

    public string? Facebook { get; set; }

    public string? Twitter { get; set; }

    public string? Linkedin { get; set; }

    public string? Github { get; set; }

    public int IdCompany { get; set; }

    public int? IdLabel { get; set; }
}
