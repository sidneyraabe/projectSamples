using CarMastery.Data.Factories;
using CarMastery.Models;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            ViewBag.NewVehicles = ReportRepositoryFactory.GetRepository().GetAllNew();
            ViewBag.UsedVehicles = ReportRepositoryFactory.GetRepository().GetAllUsed();
            return View();
        }

        public ActionResult Sales()
        {
            IEnumerable<User> model = UserRepositoryFactory.GetRepository().GetAll();      
            return View(model);
        }
    }
}