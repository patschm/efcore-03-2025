using System;
using System.Collections.Generic;

namespace DbFirst;

public partial class Brand
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Website { get; set; }

    public string? SupportEmail { get; set; }

    public byte[]? Timestamp { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
