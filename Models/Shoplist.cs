﻿using System;
using System.Collections.Generic;

namespace ShoppingBackend.Models;

public partial class Shoplist
{
    public int Id { get; set; }

    public string Item { get; set; } = null!;

    public int Amount { get; set; }
}
