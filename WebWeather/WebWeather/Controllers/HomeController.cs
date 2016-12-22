using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace WebWeather.Controllers
{

    public class HomeController : Controller
    {
        public WeatherContext db = new WeatherContext();

        public ActionResult Index()
        {
            var selected = (from city in db.Cities select city)
                .AsEnumerable()
                .Select(x => new
                {
                    Name = string.Format("{0}, {1}", x.Name, x.Location),
                    CityId = x.CityId
                });

            SelectList cities = new SelectList(selected, "CityId", "Name");
            ViewBag.Cities = cities;


            return View();

        }
        [HttpPost]
        public ActionResult CurrentWeather(City city)
        {
            WebWeather weatherSource = new OpenWeatherMap();
            double temp = 0;
            try
            {
                temp = weatherSource.getCurrentTemperatureByName(city.Name, city.Location);
            }
            catch (System.Net.WebException)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return null;
            }



            db.WeatherData.Add(new WeatherData
            {
                CityId = city.CityId,
                Date = DateTime.Now,
                Temperature = temp,
            });
            db.SaveChanges();

            List<WeatherDataInfo> list = new List<WeatherDataInfo>();
            list.Add(new WeatherDataInfo
            {
                CityName = city.Name,
                CityLocation = city.Location,
                Temperature = temp,
                Date = DateTime.Now
            });

            db.SaveChanges();

            return PartialView(list);

        }

        [HttpPost]
        public ActionResult Last5DaysWeather(City city)
        {
            DateTime currentDate = DateTime.Now;
            var selected = from wd in db.WeatherData
                           join c in db.Cities on wd.CityId equals city.CityId
                           where wd.CityId == city.CityId && DbFunctions.DiffDays(currentDate, wd.Date) <= 5
                           orderby wd.Date
                           select new WeatherDataInfo
                           {
                               CityName = city.Name,
                               CityLocation = city.Location,
                               Date = wd.Date,
                               Temperature = wd.Temperature
                           };

            return PartialView("CurrentWeather", selected);
        }
    }
}
    