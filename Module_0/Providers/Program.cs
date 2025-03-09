
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace Providers;

internal class Program
{
    const string connectionString = @"Server = .\sqlexpress; Database=ProductCatalog;Trusted_Connection=True;TrustServerCertificate =True;MultipleActiveResultSets=true;";
    static void Main(string[] args)
    {
        //ReadData();
        UpdateBrand();
    }

    private static void UpdateBrand()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();


        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE Core.Brands SET Website = @site WHERE Id = @bid AND WebSite=@oldsite";
        command.Parameters.AddWithValue("site", "www.hiworld.nl");
        command.Parameters.AddWithValue("bid", 1);
        command.Parameters.AddWithValue("oldsite", "oei");

        int nrChanged = command.ExecuteNonQuery();
        Console.WriteLine(nrChanged);
        connection.Dispose();

    }

    private static void ReadData()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        //SqlTransaction tran =  connection.BeginTransaction();
        Console.WriteLine(connection.State);

        foreach (var brand in ReadBrands(connection))
        {
            Console.WriteLine($"[{brand.Id}] {brand.Name} ({brand.WebSite})");
            foreach(var product in ReadProducts(connection, brand.Id))
            {
                Console.WriteLine($"\t{product.Name}");
            }
        }

       // tran.Rollback();
        connection.Close();
    }

    private static IEnumerable<Product> ReadProducts(SqlConnection connection, long id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM Core.Products WHERE BrandId = @bid;";
        cmd.Parameters.AddWithValue("bid", id);
        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
        while (reader.Read())
        {
            var b = new Product
            {
                Id = (long)reader[0],
                Name = (string)reader[1],
                BrandId = (long)reader[2],
                ProductGroupId = (long)reader[3],
                Image = (string)reader[4],
                TimeStamp = (byte[])reader[5]
            };
            yield return b;
        }

    }

    private static IEnumerable<Brand> ReadBrands(SqlConnection connection)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;
        cmd.CommandText = "SELECT * FROM Core.Brands";
        cmd.CommandType =  CommandType.Text;
        //cmd.ExecuteNonQuery()
        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
        while(reader.Read())
        {
            var b = new Brand
            {
                Id = (long)reader[0],
                Name = (string)reader[1],
                WebSite = (string)reader[2],          
                TimeStamp = (byte[])reader[3]
            };
           yield return b;
        }
        //cmd.ExecuteScalar();
    }
}
