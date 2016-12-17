using System;
using System.Net;
using System.Xml.Linq;


namespace WebWeather
{
    public class OpenWeatherMap : WebWeather
    {
        private string baseUrl;


        public OpenWeatherMap(string key= "12cedf83ccccc3b9fb9198adbfa51b25")
        {
            baseUrl = "http://api.openweathermap.org/data/2.5/weather?@params@" +
                "&mode=xml&units=metric&APPID=" + key;
        }

        public override double getCurrentTemperatureByName(string cityName, string location="")
        {
            string param = location.Equals("") ?
                cityName :
                cityName + "," + location;
            string url = baseUrl.Replace("@params@", "q=" + param);
            return getCurrentTemperature(url);
        }

        private double getCurrentTemperature(string url)
        {
            using (WebClient client = new WebClient())
            {
                string xmlData = client.DownloadString(url);
                XDocument xdoc = XDocument.Parse(xmlData);
                XElement xe = xdoc.Element("current").Element("temperature");
                double temperature = double.Parse(xe.Attribute("value").Value, System.Globalization.CultureInfo.InvariantCulture);
                return Math.Round(temperature);
            }
        }
    }
}
