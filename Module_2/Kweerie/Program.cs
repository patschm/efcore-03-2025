using Microsoft.EntityFrameworkCore;

namespace Kweerie;

class Program
{
    static void Main(string[] args)
    {
        //Extentions();
        //Link
        //Navigatie();
        //ChangeTracker();
        NewChangeTracker();

        Console.ReadLine();
    }

    private static void NewChangeTracker()
    {
        var context = new ProductCatalogContext();
        //context.ChangeTracker.DetectedEntityChanges += ChangeTracker_DetectedEntityChanges;
        var pg = context.ProductGroups.FirstOrDefault();
        pg.Name = "Aha";
        context.ChangeTracker.DetectChanges();
        //Console.WriteLine(pg.Name);
        //pg.Name = "Hoi";
        //var entry = context.Entry(pg);
        //entry.OriginalValues["Name"] = "Hmmmm";
        //Console.WriteLine($"Original = {entry.OriginalValues["Name"]}");
        //Console.WriteLine($"Current = {entry.CurrentValues["Name"]}");
        //var list = context.ProductGroups.ToList();
        //entry = context.Entry(list.First());
        //Console.WriteLine($"Original = {entry.OriginalValues["Name"]}");
        //Console.WriteLine($"Current = {entry.CurrentValues["Name"]}");
    }

    //private static void ChangeTracker_DetectedEntityChanges(object? sender, Microsoft.EntityFrameworkCore.ChangeTracking.DetectedEntityChangesEventArgs e)
    //{
    //    Console.WriteLine(e.Entry.CurrentValues["Name"]);
    //}

    private static void ChangeTracker()
    {
        //var listx = LoadGroups();
        var pgsub = new ProductGroup {Name = "Iets anders" };
        var context = new ProductCatalogContext();

        context.ProductGroups.Select(pg => pg.Name).ToList();

        //context.AttachRange(listx);
        var list = context.ProductGroups.ToList();

        //Console.WriteLine (context.ChangeTracker.DebugView.ShortView);
        //var pg = list.FirstOrDefault();
        var pg = context.ProductGroups.Find((long)1);
        //var pg = context.ProductGroups.FirstOrDefault(g => g.Id == 1);
        pgsub.Id = pg.Id;
        var old = pg.Name;
        pg.Name = "Hallo";
        var entry = context?.Entry(pg!);
        //entry.Reload();
        
        entry.CurrentValues.SetValues(pgsub);
        Console.WriteLine(pg.Name);
        pg.Name = old;

        
        context = new ProductCatalogContext();
        Console.WriteLine(entry.State);
        context.Attach(pg);
        entry = context.Entry(pg);
        Console.WriteLine(entry.State);

        var val = entry.OriginalValues.GetValue<string>("Name");
        Console.WriteLine(val);
        pg.Name = "World";
        val = entry.CurrentValues.GetValue<string>("Name");
        Console.WriteLine(val);
        entry.CurrentValues["Name"] = "Haha";
        Console.WriteLine(pg.Name);

        //context.ChangeTracker.DetectChanges();
        entry.State = EntityState.Unchanged;
        Console.WriteLine(pg.Name);



    }

    public static List<ProductGroup> LoadGroups()
    {
        var context = new ProductCatalogContext();
        return context.ProductGroups.ToList();
    }

    private static void Navigatie()
    {
        var context = new ProductCatalogContext();

        var query = context.ProductGroups
            //.AsSplitQuery()
            .Include(g => g.Products.Where(p => p.Brand.Name.StartsWith("S")))
               .ThenInclude(p => p.Brand);
            
            
        foreach (var item in query) 
        {
            Console.WriteLine(item.Name);
           // context.Entry(item).Collection(g=>g.Products).Load();
            foreach(var prod in item.Products)
            {
                //context.Entry(prod).Reference(p=>p.Brand).Load();
                Console.WriteLine($"\t {prod.Brand?.Name} {prod.Name}");
            }
        }
    }

    private static void Link()
    { 
        var context = new ProductCatalogContext();
        
        var query = from grp in context.ProductGroups
                    join prod in context.Products on grp.Id equals prod.ProductGroupId
                    select new { grp, prod };

        query = query.OrderByDescending(p => p.grp.Name);

        foreach ( var item in query.Skip(5).Take(5) )
        {
            Console.WriteLine($"[{item.grp.Name}] {item.prod.Name}");
        }
    }

    private static void Extentions()
    {
        var context = new ProductCatalogContext();

        var query = context.ProductGroups
           //.Join(context.Products, g => g.Id, p => p.ProductGroupId, (p, g) => new { p, g });
            .OrderByDescending(g => g.Name)
            .Where(g => g.Name.Length > 5)
            .Where(g => g.Name.StartsWith("L"))
            .Select(g => new { g.Id, Name2 = g.Name });
        
    

        //foreach ( var g in query)
        //{
        //    Console.WriteLine(g.g.Name);
        //    Console.WriteLine(g.p.Name);
        //}
    }
}

public record class PG(long Id, string Name2);
