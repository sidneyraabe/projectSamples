using CarMastery.Data.Factories;
using System;
using CarMastery.Models.Queries.Inventory;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarMastery.Models;
using System.IO;
using CarMastery.Utilities;
using CarMastery.Models.Tables;

namespace CarMastery.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Vehicles()
        {
            return View();
        }

        public ActionResult Makes()
        {
            var model = new MakeAddViewModel();
            var makesRepo = MakeRepositoryFactory.GetRepository().GetAll();
            model.Makes = makesRepo;

            model.Make = new Make();

            return View(model);
        }

        [HttpPost]
        public ActionResult Makes(MakeAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = MakeRepositoryFactory.GetRepository();
                try
                {
                    repo.Add(model.Make.MakeName, "00000000-0000-0000-0000-000000000000"); //AuthorizeUtilities.GetUserId(this);
                    return RedirectToAction("Makes");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var makesRepo = MakeRepositoryFactory.GetRepository().GetAll();
                model.Makes = makesRepo;

                return View(model);
            }

        }

        public ActionResult Models()
        {
            var model = new ModelAddViewModel();
            var makesRepo = MakeRepositoryFactory.GetRepository().GetAll();
            var modelRepo = ModelRepositoryFactory.GetRepository().GetAll();


            model.Models = modelRepo;
            model.Makes = new SelectList(makesRepo, "MakeId", "MakeName");

            model.newModel = new Model();

            return View(model);
        }

        [HttpPost]
        public ActionResult Models(ModelAddViewModel model)
        {
            model.newModel.UserId = "00000000-0000-0000-0000-000000000000";
            if (ModelState.IsValid) // can't make model valid
            {
                var newModelRepo = ModelRepositoryFactory.GetRepository();
                Model newModel = new Model()
                {
                    ModelName = model.newModel.ModelName,
                    MakeId = model.newModel.MakeId,
                    UserId = "00000000-0000-0000-0000-000000000000"
                };
                try
                {
                    newModelRepo.Add(newModel);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            var makesRepo = MakeRepositoryFactory.GetRepository().GetAll();
            var modelRepo = ModelRepositoryFactory.GetRepository().GetAll();
            model.Models = modelRepo;
            model.Makes = new SelectList(makesRepo, "MakeId", "MakeName");

            return View(model);

        }

        public ActionResult Users()
        {
            var model = UserRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        public ActionResult Specials()
        {
            var model = SpecialRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }


        public ActionResult AddVehicle()
        {
            var model = new VehicleAddViewModel();

            var makesRepo = MakeRepositoryFactory.GetRepository();
            var modelsRepo = ModelRepositoryFactory.GetRepository();
            var bodyStylessRepo = BodyStyleRepositoryFactory.GetRepository();
            var interiorColorsRepo = InteriorColorRepositoryFactory.GetRepository();
            var exteriorColorsRepo = ExteriorColorRepositoryFactory.GetRepository();

            model.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName");
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelId", "ModelName");
            model.BodyStyles = new SelectList(bodyStylessRepo.GetAll(), "BodyStyleId", "BodyStyleName");
            model.InteriorColors = new SelectList(interiorColorsRepo.GetAll(), "InteriorColorId", "InteriorColorName");
            model.ExteriorColors = new SelectList(exteriorColorsRepo.GetAll(), "ExteriorColorId", "ExteriorColorName");
            model.Vehicle = new Models.Tables.Vehicle();

            return View(model);
        }
        //[Authorize]
        [HttpPost]
        public ActionResult AddVehicle(VehicleAddViewModel model)
        {
            ///model.Vehicle.UserId = AuthorizeUtilities.GetUserId(this);
            model.Vehicle.UserId = "00000000-0000-0000-0000-000000000000";
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();
                try
                {
                    List<Vehicle> vehicles = repo.GetAll();
                    int id = 0;
                    foreach (Vehicle v in vehicles)
                    {
                        if (v.VehicleId > id)
                            id = v.VehicleId;
                    }
                    id += 1; //this is gross


                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");
                        string extension = Path.GetExtension(model.ImageUpload.FileName);
                        string fileName = "inventory-" + id + extension;
                        var filePath = Path.Combine(savepath, fileName);

                        //If not routed exception:
                        //model.Vehicle.ImageLocation = "C:/Users/sraab/OneDrive/Documents/CarMasteryImageHolderer/Images/" + "inventory-" + id + extension;
                        //model.ImageUpload.SaveAs(model.Vehicle.ImageLocation);


                        model.ImageUpload.SaveAs(filePath);
                        model.Vehicle.ImageLocation = Path.GetFileName(filePath);
                    }

                    repo.Add(model.Vehicle);

                    return RedirectToAction("EditVehicle", new { id = model.Vehicle.VehicleId });

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var makesRepo = MakeRepositoryFactory.GetRepository();
                var modelsRepo = ModelRepositoryFactory.GetRepository();
                var bodyStylessRepo = BodyStyleRepositoryFactory.GetRepository();
                var interiorColorsRepo = InteriorColorRepositoryFactory.GetRepository();
                var exteriorColorsRepo = ExteriorColorRepositoryFactory.GetRepository();

                model.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName");
                model.Models = new SelectList(modelsRepo.GetAll(), "ModelId", "ModelName");
                model.BodyStyles = new SelectList(bodyStylessRepo.GetAll(), "BodyStyleId", "BodyStyleName");
                model.InteriorColors = new SelectList(interiorColorsRepo.GetAll(), "InteriorColorId", "InteriorColorName");
                model.ExteriorColors = new SelectList(exteriorColorsRepo.GetAll(), "ExteriorColorId", "ExteriorColorName");

                return View(model);
            }

        }


        public ActionResult EditVehicle(int id)
        {
            var model = new VehicleEditViewModel();

            var makesRepo = MakeRepositoryFactory.GetRepository();
            var modelsRepo = ModelRepositoryFactory.GetRepository();
            var bodyStylessRepo = BodyStyleRepositoryFactory.GetRepository();
            var interiorColorsRepo = InteriorColorRepositoryFactory.GetRepository();
            var exteriorColorsRepo = ExteriorColorRepositoryFactory.GetRepository();
            var vehicleRepo = VehicleRepositoryFactory.GetRepository();

            model.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName");
            model.Models = new SelectList(modelsRepo.GetAll(), "ModelId", "ModelName");
            model.BodyStyles = new SelectList(bodyStylessRepo.GetAll(), "BodyStyleId", "BodyStyleName");
            model.InteriorColors = new SelectList(interiorColorsRepo.GetAll(), "InteriorColorId", "InteriorColorName");
            model.ExteriorColors = new SelectList(exteriorColorsRepo.GetAll(), "ExteriorColorId", "ExteriorColorName");


            var previousVehicle = vehicleRepo.GetEditById(id);
            model.MakeId = previousVehicle.MakeId;
            model.ModelId = previousVehicle.ModelId;
            model.Vehicle = previousVehicle;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditVehicle(VehicleEditViewModel model)
        {
            model.Vehicle.UserId = "00000000-0000-0000-0000-000000000000";
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();
                try
                {

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");
                        string extension = Path.GetExtension(model.ImageUpload.FileName);
                        string fileName = "inventory-" + model.Vehicle.VehicleId + extension;
                        var filePath = Path.Combine(savepath, fileName);

                        //To do: refactor...
                        //vrepo.getVehicle(vehicleId).ImageLocation (needs instantiation)
                        string[] extensionsArray = new string[]
                        {
                            ".jpg",
                            ".jpeg",
                            ".png"
                        };
                        foreach (string extensions in extensionsArray)
                        {
                            var previousFile = Path.Combine(savepath, "inventory-" + model.Vehicle.VehicleId + extensions);
                            if (System.IO.File.Exists(previousFile))
                            {
                                System.IO.File.Delete(previousFile);
                                break;
                            }
                        }



                        model.ImageUpload.SaveAs(filePath);
                        model.Vehicle.ImageLocation = Path.GetFileName(filePath);
                    }                 

                        Vehicle changedVehicle = new Vehicle()
                    {
                        UserId = model.Vehicle.UserId,
                        VehicleId = model.Vehicle.VehicleId,
                        ModelId = model.Vehicle.ModelId,
                        //no makeId
                        InteriorColorId = model.Vehicle.InteriorColorId,
                        ExteriorColorId = model.Vehicle.ExteriorColorId,
                        BodyStyleId = model.Vehicle.BodyStyleId,
                        IsNew = model.Vehicle.IsNew,
                        IsAutoTransmission = model.Vehicle.IsAutoTransmission,
                        Mileage = model.Vehicle.Mileage,
                        Vin = model.Vehicle.Vin,
                        Msrp = model.Vehicle.Msrp,
                        VehicleSalePrice = model.Vehicle.VehicleSalePrice,
                        VehicleDescription = model.Vehicle.VehicleDescription,
                        ModelDate = model.Vehicle.ModelDate,
                        IsAvailable = model.Vehicle.IsAvailable,
                        IsFeatured = model.Vehicle.IsFeatured
                    };

                    if (model.ImageUpload != null)
                        changedVehicle.ImageLocation = model.Vehicle.ImageLocation;

                    repo.Update(changedVehicle);

                    return RedirectToAction("vehicles");

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                // currently if you change model and there happens to be validation error
                // on reload, selects the lowest modelId from the previous page's selected make

                var makesRepo = MakeRepositoryFactory.GetRepository();
                var modelsRepo = ModelRepositoryFactory.GetRepository();
                var bodyStylessRepo = BodyStyleRepositoryFactory.GetRepository();
                var interiorColorsRepo = InteriorColorRepositoryFactory.GetRepository();
                var exteriorColorsRepo = ExteriorColorRepositoryFactory.GetRepository();
                var vehicleRepo = VehicleRepositoryFactory.GetRepository();

                model.Makes = new SelectList(makesRepo.GetAll(), "MakeId", "MakeName");
                model.Models = new SelectList(modelsRepo.GetAll(), "ModelId", "ModelName");
                model.BodyStyles = new SelectList(bodyStylessRepo.GetAll(), "BodyStyleId", "BodyStyleName");
                model.InteriorColors = new SelectList(interiorColorsRepo.GetAll(), "InteriorColorId", "InteriorColorName");
                model.ExteriorColors = new SelectList(exteriorColorsRepo.GetAll(), "ExteriorColorId", "ExteriorColorName");


                var previousVehicle = vehicleRepo.GetEditById(model.Vehicle.VehicleId);
                model.ModelId = previousVehicle.ModelId;
                return View(model);
            }

        }

    }
}