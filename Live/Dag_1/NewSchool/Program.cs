using Microsoft.EntityFrameworkCore;
using NewSchool.NewModels;

namespace NewSchool;

internal class Program
{
    const string connectionString = @"Server =.\SQLExpress;Database=ShopDatabase;Trusted_Connection=Yes;TrustServerCertificate=true;MultipleActiveResultSets=true";

    static void Main(string[] args)
    {
        DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
        bld.UseSqlServer(connectionString);
        //bld.LogTo(Console.WriteLine);
        DbContextOptions options = bld.Options;
        ShopDatabaseContext ctx = new ShopDatabaseContext(options);

        //ctx.Database.EnsureDeleted();
        //ctx.Database.EnsureCreated();
        //ctx.Database.Migrate("Version2");
        Console.WriteLine("Ok");

      //  DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
      //  bld.UseSqlServer(connectionString);
      //  bld.LogTo(Console.WriteLine);
      //  DbContextOptions options = bld.Options;

      //  ShopContext context = new ShopContext(options);
      ////Console.WriteLine(context.Database.GetConnectionString());
      //  List<Brand> brands =  context.Brands.ToList();
      //  foreach(Brand brand in brands)
      //  {
      //      //Console.WriteLine($"[{brand.Id} {brand.Name} ({brand.Website})]");

      //      context.Entry<Brand>(brand).Collection(b=>b.Products).Load();
      //      foreach (Produkt product in brand.Products) 
      //      {
      //          //Console.WriteLine($"\t[{product.Id}] {product.Name}");
      //      }
      //  }

      //  foreach (Produkt product in context.Produkten)
      //  {
      //      //Console.WriteLine($"[{product.Id}] {product.Name}");
      //  }
    }
}
