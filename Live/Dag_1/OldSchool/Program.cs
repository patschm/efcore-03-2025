using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace OldSchool;

internal class Program
{
    const string connectionString = @"Server =.\SQLExpress;Database=ShopDatabase;Trusted_Connection=Yes;TrustServerCertificate=true;MultipleActiveResultSets=true;";

    static void Main(string[] args)
    {
        ConfigurationBuilder bld = new ConfigurationBuilder();
        //bld.AddJsonFile("appsettings.json");
        // Alleen voor development 
        bld.AddUserSecrets<Program>();

        // dotnet user-secrets set "ConnectionStrings:ConnectionString" "Server =.\SQLExpress;Database=ShopDatabase;Trusted_Connection=Yes;TrustServerCertificate=true;MultipleActiveResultSets=true"

        IConfiguration config = bld.Build();
        string conStr = config.GetConnectionString("ConnectionString");
        Console.WriteLine(conStr);


        SqlConnection connection = new SqlConnection(conStr);
        connection.Open();
        Console.WriteLine(connection.State);
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Core.Brands";

        DbDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
        while (reader.Read())
        {
            var brand = new Brand
            {
                Id = (long)reader[0],
                Name = (string)reader[1],
                Website = (string)reader[2]
            };


            Console.WriteLine($"[{brand.Id} {brand.Name} ({brand.Website})]");

            SqlCommand prodCmd = new SqlCommand();
            prodCmd.Connection = connection;
            prodCmd.Parameters.AddWithValue("BId", brand.Id);
            prodCmd.CommandText = $"SELECT * FROM Core.Products WHERE BrandId=@BId";

            DbDataReader prdr = prodCmd.ExecuteReader();
            while (prdr.Read())
            {
                var p = new Product
                {
                    Id = (long)prdr[0],
                    Name = (string)prdr[1],
                    Brand = brand
                };
                Console.WriteLine($"\t{p.Name}");
            }

        }


        connection.Close();
    }
}
