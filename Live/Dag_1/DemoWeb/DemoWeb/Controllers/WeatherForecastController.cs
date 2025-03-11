using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewSchool.NewModels;

namespace DemoWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        readonly ShopDatabaseContext context;// = new ShopDatabaseContext();

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ShopDatabaseContext ctx, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            context = ctx;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Brand> Get()
        {
            //var bld = new DbContextOptionsBuilder();
            // bld.UseSqlServer()
           // ShopDatabaseContext context = new ShopDatabaseContext();
            return context.Brands.ToList();
        }
    }
}
