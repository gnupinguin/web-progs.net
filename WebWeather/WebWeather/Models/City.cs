using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebWeather
{
    public class City
    {
        public int CityId { get; set; }
        [Column(TypeName = "VARCHAR")]
        [Index("IX_CityLocation", 1, IsUnique = true)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Index("IX_CityLocation", 2, IsUnique = true)]
        public string Location { get; set; }

        public virtual ICollection<WeatherData> WeatherData { get; set; }
    }
}
