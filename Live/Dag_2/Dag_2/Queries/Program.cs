using Microsoft.EntityFrameworkCore;

namespace Queries;

internal class Program
{
    private const string constr = @"Server = .\sqlexpress; Database=ProductCatalog;Trusted_Connection=True;TrustServerCertificate =True;MultipleActiveResultSets=True";


    static void Main(string[] args)
    {
        var bld = new DbContextOptionsBuilder();
        bld.UseSqlServer(constr);
        //bld.UseLazyLoadingProxies();
        bld.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        var context = new ShopDatabaseContext(bld.Options);

        //ViaExtension(context);
        //ViaLinq(context);
        //ViaRaw(context);
        //NaviLeanAndMaen(context);
        EagerLoading(context);

        Console.ReadLine();
    }

    private static void EagerLoading(ShopDatabaseContext context)
    {
        var query = context.ProductGroups
            .Include(pg => pg.Products)
                .ThenInclude(p => p.Brand);
        //.Include


        foreach (var pg in query)
        {
            Console.WriteLine(pg.Name);
            foreach (var p in pg.Products)
            {
                Console.WriteLine($"\t{p.Brand.Name} {p.Name}");
            }
        }
    }

    private static void NaviLeanAndMaen(ShopDatabaseContext context)
    {
        foreach (var pg in context.ProductGroups)
        {
            // Console.WriteLine(pg.GetType().Name);
            Console.WriteLine(pg.Name);
            // Load Explicit Loading
            //context.Entry(pg).Collection(p => p.Products).Load();
            foreach (var p in pg.Products)
            {
                // context.Entry(p).Reference(p=>p.Brand).Load();
                Console.WriteLine($"\t{p.Brand.Name} {p.Name}");
            }
        }
    }

    private static void ViaRaw(ShopDatabaseContext context)
    {
        var pgs = context.ProductGroups.FromSqlRaw("Select * FROM Core.ProductGroups");
        //var pgs = context.ProductGroups;
        foreach (var group in pgs)
        {
            Console.WriteLine(group.Name);
        }

    }

    private static void ViaLinq(ShopDatabaseContext context)
    {
        var first = "P";

        var query = from p in context.ProductGroups select p;
        //query = from q in query.Where(p => p.Name.StartsWith (first)) select q;

        var qjoin = from pg in context.ProductGroups
                    join p in context.Products on pg.Id equals p.ProductGroupId
                    group p by pg.Name into iets
                    //let a = 20
                    select new { Group = iets.Key, Products = iets };

        //qjoin.ToList();
        foreach (var item in query.Skip(0).Take(3))
        {
            Console.WriteLine(item.Name);
        }

    }

    private static void ViaExtension(ShopDatabaseContext context)
    {
        var first = "P";
        //var query = context.ProductGroups.Where(pg=>pg.Name.StartsWith(first));
        var query = context.ProductGroups
            .OrderByDescending(g => g.Name)
            .Where(g => g.Name.StartsWith("M"))
            .Select(pg => new { Naam = pg.Name, Idee = pg.Id });

        //foreach (var group in query)
        //{
        //    Console.WriteLine(group.Naam);
        //}

        //var q1  = query.Where(g => g.Name.StartsWith("M"));
        // var realList = query.ToList();
        //foreach (var group in query)
        //{
        //    Console.WriteLine(group.Name);
        //}

        var qjoin = context.ProductGroups
            .Join(context.Products, pg => pg.Id, p => p.ProductGroupId, (pg, p) => p)
            .GroupBy(iets => iets.ProductGroup.Name);

        foreach (var item in qjoin)
        {
            Console.WriteLine(item.Key);


            foreach (var p in item)
            {
                Console.WriteLine($"\t{p.Name}");
            }
        }
        //qjoin.ToArray();
    }
}
