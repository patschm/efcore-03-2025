
using Microsoft.EntityFrameworkCore;
using NewSchool.NewModels;

namespace DemoWeb
{
    public class Program
    {
        const string constStr = "Server=.\\SQLExpress;Database=ShopDatabase;Trusted_Connection=Yes;TrustServerCertificate=true";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ShopDatabaseContext>(opts => { 
                opts.UseSqlServer(constStr);
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
