
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Queries;
using System.Data.Common;
using System.Transactions;

namespace Transactions;

internal class Program
{
    private const string constr = @"Server = .\sqlexpress; Database=ProductCatalog;Trusted_Connection=True;TrustServerCertificate =True;MultipleActiveResultSets=True";
    private static DbContextOptions options;

    static void Main(string[] args)
    {
        options = new DbContextOptionsBuilder().UseSqlServer(constr).Options;
        //Basics();
        HoedanEF();
        Console.ReadLine();
    }

    private static void HoedanEF()
    {
        SqlConnection conn = new SqlConnection(constr);
        Console.WriteLine(conn.ClientConnectionId );
       
        var opts = new DbContextOptionsBuilder().UseSqlServer(conn).Options;

        ShopDatabaseContext context = new ShopDatabaseContext(opts);
        Console.WriteLine(context.Database.GetDbConnection().GetType().Name);

        var opt2s = new DbContextOptionsBuilder().UseSqlServer(conn).Options;
        ShopDatabaseContext contex2 = new ShopDatabaseContext(opts);

        using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
        {
            //Console.WriteLine(Transaction.Current.TransactionInformation.LocalIdentifier);
            //Console.WriteLine(Transaction.Current.TransactionInformation.DistributedIdentifier);
            SqlConnection conn2 = new SqlConnection(constr);
            Console.WriteLine(conn2.ClientConnectionId);

        }

        //var tran = context.Database.BeginTransaction();
        //context.SaveChanges();
        //contex2.SaveChanges();
       // tran.Commit();
        //tran.Rollback();


        context.Database.BeginTransaction();
        var xtranx = context.Database.GetEnlistedTransaction();

        contex2.Database.EnlistTransaction(xtranx);

        
    }

    private static void Basics()
    {
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        DbTransaction tran = conn.BeginTransaction();


        tran.Commit();
        tran.Rollback();
    }
}
