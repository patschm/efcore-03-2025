using System;
using System.Collections.Generic;

namespace QueryFilters.Models;

public partial class ProductGroup
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Image { get; set; }

    public byte[]? Timestamp { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<SpecificationDefinition> SpecificationDefinitions { get; set; } = new List<SpecificationDefinition>();
}
