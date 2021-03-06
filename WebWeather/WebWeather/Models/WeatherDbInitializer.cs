﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebWeather.Models
{
    public class WeatherDbInitializer : DropCreateDatabaseAlways<WeatherContext>
    {
        protected override void Seed(WeatherContext db)
        {
            db.Cities.Add(new City { Name = "St. Petersburg", Location = "ru" });
            db.WeatherData.Add(
                   new WeatherData
                   {
                       CityId = 1,
                       Date = DateTime.Now,
                       Temperature = new OpenWeatherMap().getCurrentTemperatureByName("St. Petersburg", "ru")
                   });
            db.Cities.Add(new City { Name = "Ufa", Location = "ru" });
            db.WeatherData.Add(
                   new WeatherData
                   {
                       CityId = 2,
                       Date = DateTime.Now,
                       Temperature = new OpenWeatherMap().getCurrentTemperatureByName("Ufa", "ru")
                   });

            db.Cities.Add(new City { Name = "Minsk", Location = "by" });
            db.WeatherData.Add(
                   new WeatherData
                   {
                       CityId = 3,
                       Date = DateTime.Now,
                       Temperature = new OpenWeatherMap().getCurrentTemperatureByName("Minsk", "by")
                   });
            db.Cities.Add(new City { Name = "Navahrudak", Location = "by" });
            db.WeatherData.Add(
                   new WeatherData
                   {
                       CityId = 4,
                       Date = DateTime.Now,
                       Temperature = new OpenWeatherMap().getCurrentTemperatureByName("Navahrudak", "by")
                   });

            base.Seed(db);
        }
    }
}