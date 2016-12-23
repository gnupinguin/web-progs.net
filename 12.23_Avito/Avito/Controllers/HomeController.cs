using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Avito.Models;

namespace Avito.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private DataBase db = new DataBase();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddLabel()
        {
            return View("AddLabel");
        }

        [HttpGet]
        public ActionResult AddRecord(Record r)
        {

            db.Add(r);
            db.SaveChanges();
            if (ModelState.IsValid)
                return View();
            else return View("AddLabel");
        }

        [HttpGet]
        public ActionResult GetRecords()
        {
            db.Update();
            return db.records.Count == 0 ? View("GetRecords",null) : View(db.records);
        }
    }
}