﻿using System;
using System.Collections.Generic;

namespace HelpdeskWorker.Models;

public partial class Label
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Color { get; set; }

    public int IdCompany { get; set; }
}
