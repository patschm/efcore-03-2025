using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace EFBasics;

public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Merk> Brands => Set<Merk>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Core");
        
        modelBuilder.Entity<Merk>(c => {
            c.ToTable("Brands");
            //c.HasMany(c => c.Products).WithOne().HasForeignKey(x => x.BrandId);//.OnDelete(DeleteBehavior.Cascade);
            //c.HasKey(p => new { p.Id, p.Naam });
            c.Property("Id").HasColumnName("Id");
            c.Property("Naam").HasColumnName("Name");
            
           
        });

    }

}
