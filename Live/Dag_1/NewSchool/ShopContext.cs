using Microsoft.EntityFrameworkCore;

namespace NewSchool;

internal class ShopContext : DbContext
{
    public ShopContext(DbContextOptions options) : base(options)
    {      
    }
    //public DbSet<Brand> Brands { get; set; }
    //public DbSet<Produkt> Produkten { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Core"); // dbo is default schema

        //var p = modelBuilder.Entity<Produkt>();
        //p.ToTable("Products");

        //modelBuilder.Entity<Produkt>().ToTable("Products");

        //modelBuilder.Entity<Produkt>(opts => {
        //    opts.ToTable("Products");
        //    opts.HasKey(p => p.Id);
        //    opts.Property(p => p.Name).HasColumnName("Name");
           
        //});
    }
}
