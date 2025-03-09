using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPerformance;

[MemoryDiagnoser]
[MaxIterationCount(200)]
public class BenchMarking
{
    public static string connectionString = @"Server=.\SQLEXPRESS;Database=ShopDatabase;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;Encrypt=False";

    [Benchmark]
    public ProductContext NormalInit()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
        optionsBuilder.UseSqlServer(connectionString);
        var options = optionsBuilder.Options;
        var context = new ProductContext(options);
        return context;
    }

    [Benchmark]
    public ProductContext NormalCompiledModelInit()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.UseModel(ProductContextModel.Instance);
        var options = optionsBuilder.Options;
        var context = new ProductContext(options);
        return context;
    }

    [Benchmark]
    public List<ProductGroup> NormalQuery()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
        optionsBuilder.UseSqlServer(connectionString);
        var options = optionsBuilder.Options;
        var context = new ProductContext(options);
    
        var query = context.ProductGroups
           .Include(pg => pg.Products)
               .ThenInclude(p => p.Brand)
           .Include(pg => pg.Products);
           return query.ToList();
        
    }

    private static Func<ProductContext, IEnumerable<ProductGroup>> _compiled =
       EF.CompileQuery((ProductContext ctx) => ctx.ProductGroups
          .Include(pg => pg.Products)
              .ThenInclude(p => p.Brand)
          .Include(pg => pg.Products));

    [Benchmark]
    public List<ProductGroup> CompiledQuery()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
        optionsBuilder.UseSqlServer(connectionString);
        var options = optionsBuilder.Options;

        var context = new ProductContext(options);
        return _compiled(context).ToList();
    }
}
