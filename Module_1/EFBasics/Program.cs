using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFBasics;

internal class Program
{
    private static string connectionString = @"Server = .\sqlexpress; Database=ProductCatalog;Trusted_Connection=True;TrustServerCertificate =True;MultipleActiveResultSets=true;";

    static void Main(string[] args)
    {
        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.UseLazyLoadingProxies(true);
        optionsBuilder.LogTo(fn=>Console.WriteLine(fn));
        //DbContext ctx = new DbContext(optionsBuilder.Options);
        
        //DbSet<Brand> brands =ctx.Set<Brand>();
        //DbSet<Product> products =ctx.Set<Product>();
        //

        CatalogContext context = new CatalogContext(optionsBuilder.Options);

        var brandList = context.Brands.ToList();
        foreach (var brand in brandList)
        {
            //Console.WriteLine($"{brand.GetType().Name}");
            //Console.WriteLine($"[{brand.Id}] {brand.Naam} ({brand.Website})");
           foreach(var product in brand.Products)
            {              
               // Console.WriteLine($"\t{product.Name}");
            }
        }
    }
}
