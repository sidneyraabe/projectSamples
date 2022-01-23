using CarMastery.Data.Factories;
using CarMastery.Models;
using CarMastery.Models.Queries.Home;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var model = VehicleRepositoryFactory.GetRepository().GetAllFeatured();

            return View(model);
        }

        public ActionResult Specials()
        {
            var model = SpecialRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }
        public ActionResult Contact(string vin)
        {
            var model = new ContactAddViewModel();
            model.ContactUs = new Models.Tables.ContactUs();
            model.ContactUs.Message = vin;
            

            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = ContactUsRepositoryFactory.GetRepository();
                try
                {
                    repo.Add(model.ContactUs);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else                
            return View(model);
        }
    }
}