// See https://aka.ms/new-console-template for more information
using DbFirst;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<ProductCatalogContext>();
optionsBuilder.UseSqlServer("Server = .\\sqlexpress; Database=RommelBase;Trusted_Connection=True;TrustServerCertificate =True;MultipleActiveResultSets=true;");
optionsBuilder.UseLazyLoadingProxies(true);
var ctx = new ProductCatalogContext(optionsBuilder.Options);

ctx.Database.EnsureDeleted();
ctx.Database.EnsureCreated();

foreach(var brand in ctx.Brands)
{
    System.Console.WriteLine(brand.Name);
    foreach(var prod in brand.Products)
    {
        System.Console.WriteLine($"\t{prod.Name}");
    }

}