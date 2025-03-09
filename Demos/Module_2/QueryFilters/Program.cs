using QueryFilters.Models;

namespace QueryFilters;

internal class Program
{
    static void Main(string[] args)
    {
        var context = new ProductCatalogContext();
        foreach(var b in context.Brands)
        {
            Console.WriteLine(b.Name);
        }
    }
}
