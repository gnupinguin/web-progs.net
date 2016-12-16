using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebWeather
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("WeatherDBConnection") { }
        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherData> WeatherData { get; set; }
    }
}
