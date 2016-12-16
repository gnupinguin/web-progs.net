using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWeather
{
    public abstract class WebWeather
    {
        public abstract double getCurrentTemperatureByName(string cityName, string location);
        public int timer { get; set; }
    }
}
