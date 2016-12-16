using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebWeather
{
    public class WeatherData
    {
        public int WeatherDataId { get; set; }
        public int CityId { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }

        public City City { get; set; }
    }
}
