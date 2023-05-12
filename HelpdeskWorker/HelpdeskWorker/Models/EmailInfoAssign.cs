using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class EmailInfoAssign
{
    public int Id { get; set; }

    public int IdEmailInfo { get; set; }

    public int? IdUser { get; set; }
}
