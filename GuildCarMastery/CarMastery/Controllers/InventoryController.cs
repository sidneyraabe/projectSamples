using CarMastery.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Details(int id)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            var model = repo.GetById(id);
            return View(model);
        }


        public ActionResult New()
        {
            return View();
        }

        public ActionResult Used()
        {
            return View();
        }
    }
}