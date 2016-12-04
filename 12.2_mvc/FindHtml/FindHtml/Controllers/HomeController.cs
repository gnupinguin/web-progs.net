using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace FindHtml.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<string[]> files = new List<string[]>();
            string path = @"C:\Users\iljap\Documents\Projects\htmls.csv";
            StreamReader csv = new StreamReader(path);
            string str;
            while ((str = csv.ReadLine()) != null)
            {
                files.Add(str.Split(';'));
            }
            
            ViewBag.files = files;
            return View();
        }
       
    }
}