using CarMastery.Data.Factories;
using CarMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {        
            return View();
        }

        public ActionResult Purchase(int id)
        {
            PurchaseViewModel model = new PurchaseViewModel();

            var vrepo = VehicleRepositoryFactory.GetRepository();
            var vehicleDetailsModel = vrepo.GetById(id);

            model.VehicleDetails = vehicleDetailsModel;

            var statesRepo = StateRepositoryFactory.GetRepository();
            var purchaseTypeRepo = PurchaseTypeRepositoryFactory.GetRepository();

            model.States = new SelectList(statesRepo.GetAll(), "StateId", "StateName");
            model.PurchaseType = new SelectList(purchaseTypeRepo.GetAll(), "PurchaseTypeId", "PurchaseTypeName");

            model.Sale = new Models.Tables.Sale();
            return View(model);
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel model)
        {
            ///model.Vehicle.UserId = AuthorizeUtilities.GetUserId(this);
            model.Sale.UserId = "00000000-0000-0000-0000-000000000000";
            model.Sale.VehicleId = model.VehicleDetails.VehicleId;
            model.Sale.DateSold = DateTime.Now;
            if (ModelState.IsValid)
            {
                var repo = SaleRepositoryFactory.GetRepository();
                    if(repo.Add(model.Sale)) //return true if sale was possible
                    return RedirectToAction("Index");
                ViewBag.ErrorMessage = "Error adding purchase. This vehicle is not available.";
            }

                var statesRepo = StateRepositoryFactory.GetRepository();
                var purchaseTypeRepo = PurchaseTypeRepositoryFactory.GetRepository();
                var vrepo = VehicleRepositoryFactory.GetRepository();
                var vehicleDetailsModel = vrepo.GetById(model.VehicleDetails.VehicleId);

                model.VehicleDetails = vehicleDetailsModel;

                model.States = new SelectList(statesRepo.GetAll(), "StateId", "StateName");
                model.PurchaseType = new SelectList(purchaseTypeRepo.GetAll(), "PurchaseTypeId", "PurchaseTypeName");

                return View(model);
            

        }
    }
}