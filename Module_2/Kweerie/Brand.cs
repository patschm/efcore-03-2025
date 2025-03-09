using System;
using System.Collections.Generic;

namespace Kweerie;

public partial class Brand
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Website { get; set; }

    public byte[]? Timestamp { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
