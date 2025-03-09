using System;
using System.Collections.Generic;

namespace QueryFilters.Models;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long BrandId { get; set; }

    public long ProductGroupId { get; set; }

    public string? Image { get; set; }

    public byte[]? Timestamp { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ProductGroup ProductGroup { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Specification> Specifications { get; set; } = new List<Specification>();
}
