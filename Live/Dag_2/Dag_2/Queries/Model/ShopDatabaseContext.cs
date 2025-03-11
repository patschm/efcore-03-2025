using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Queries;

public partial class ShopDatabaseContext : DbContext
{
    public ShopDatabaseContext()
    {
    }

    public ShopDatabaseContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }
    public virtual DbSet<Price> Prices { get; set; }
    public virtual DbSet<PriceHistory> PriceHistories { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductGroup> ProductGroups { get; set; }
    public virtual DbSet<Review> Reviews { get; set; }
    public virtual DbSet<Reviewer> Reviewers { get; set; }
    public virtual DbSet<Specification> Specifications { get; set; }
    public virtual DbSet<SpecificationDefinition> SpecificationDefinitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Core");

        // QueryFilter
        //modelBuilder.Entity<ProductGroup>().HasQueryFilter(g => g.Name.StartsWith("M"));
    }
}
