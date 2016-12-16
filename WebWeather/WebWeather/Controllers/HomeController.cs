using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
        public PartialViewResult CurrentWeather(City c)
        {
            var a = Request.Form["Cities"];
            int id = int.Parse(a);

            WebWeather weatherSource = new OpenWeatherMap();


            var isCurrentWeather = Request.Form["CurrentWeather"];

            if (isCurrentWeather != null)
            {
                var query = from city in db.Cities
                            join wd in db.WeatherData on city.CityId equals wd.CityId
                            where city.CityId == id
                            select new
                            {
                                CityName = city.Name,
                                CityLocation = city.Location,
                            };
                var location = query.AsEnumerable().Last();

                double temp = weatherSource.getCurrentTemperatureByName(location.CityName, location.CityLocation);

                db.WeatherData.Add(new WeatherData
                {
                    CityId = id,
                    Date = DateTime.Now,
                    Temperature = temp,
                });
                db.SaveChanges();

                List<WeatherDataInfo> list = new List<WeatherDataInfo>();
                list.Add(new WeatherDataInfo
                {
                    CityName = location.CityName,
                    CityLocation = location.CityLocation,
                    Temperature = temp,
                    Date = DateTime.Now
                });

                db.SaveChanges();
                return PartialView(list);
            }
            //for 5 days
            DateTime currentDate = DateTime.Now;
            var selected = from wd in db.WeatherData
                            join city in db.Cities on wd.CityId equals city.CityId
                            where wd.CityId == id && DbFunctions.DiffDays(currentDate, wd.Date) <= 5
                            orderby wd.Date
                            select new WeatherDataInfo
                            {
                                CityName = city.Name,
                                CityLocation = city.Location,
                                Date = wd.Date,
                                Temperature = wd.Temperature
                            };

            return PartialView(selected);
        }
    }
}
    