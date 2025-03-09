using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace DemoComplexTypes;

internal class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Reviewer> Reviewers => Set<Reviewer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Core");

        modelBuilder.Entity<Reviewer>(conf =>
        {
            // EF Core >= 8.0
            // Complex type limitations in EF8 include:
            //    Support collections of complex types. (Issue #31237)
            //    Allow complex type properties to be null. (Issue #31376)
            //    Map complex type properties to JSON columns. (Issue #31252)
            //    Constructor injection for complex types. (Issue #31621)
            //    Add seed data support for complex types. (Issue #31254)
            //    Map complex type properties for the Cosmos provider. (Issue #31253)
            //    Implement complex types for the in-memory database. (Issue #31464)
            conf.ComplexProperty(e => e.Credentials).IsRequired();

            // Primitive collection properties
            conf.Property(e => e.AssignedNumbers).HasMaxLength(100);
        });
       
    }
}
