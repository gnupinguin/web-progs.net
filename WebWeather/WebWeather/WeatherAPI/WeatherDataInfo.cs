using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWeather
{
    public class WeatherDataInfo
    {
        public double Temperature { get; set; }
        public DateTime Date { get; set; }
        public string CityName { get; set; }
        public string CityLocation { get; set; }
    }
}
