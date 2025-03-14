﻿using ACME.DataLayer.Entities;
using ACME.DataLayer.Repository.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using MySqlServerProvider;

namespace ACME.Frontend.ConsoleClient;

internal class Program
{
    const string databaseName = "Shop4";
    const string connectionString = @$"Server=.\SQLEXPRESS;Database={databaseName};Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;";

    static void Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(svcs =>
            {
                // TODO 1: Register a DbContextFactory for ShopDatabaseContext
                svcs.AddDbContextFactory<ShopDatabaseContext>(optBld =>
                {
                    optBld.UnknownDatabase(connectionString);
                    //optBld.UseSqlServer(connectionString);
                });
                svcs.AddHostedService<ConsoleHost>();
            }).Build();

        host.StartAsync().Wait();
        // TODO 6: Run the code
    }
}


