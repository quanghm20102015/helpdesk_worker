using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class ContactLabel
{
    public int Id { get; set; }

    public int IdContact { get; set; }

    public int? IdLabel { get; set; }
}
