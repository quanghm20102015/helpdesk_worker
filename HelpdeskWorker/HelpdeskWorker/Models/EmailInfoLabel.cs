using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class EmailInfoLabel
{
    public int Id { get; set; }

    public int IdEmailInfo { get; set; }

    public int? IdLabel { get; set; }
}
