using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class EmailInfoFollow
{
    public int Id { get; set; }

    public int IdEmailInfo { get; set; }

    public int? IdUser { get; set; }
}
