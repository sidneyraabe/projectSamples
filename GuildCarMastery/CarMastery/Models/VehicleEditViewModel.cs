using CarMastery.Models.Queries.Inventory;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.Models
{

    public class VehicleEditViewModel : IValidatableObject
    {
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> BodyStyles { get; set; }
        public IEnumerable<SelectListItem> InteriorColors { get; set; }
        public IEnumerable<SelectListItem> ExteriorColors { get; set; }
        public VehicleEditItem Vehicle { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (Vehicle.ModelDate < 2000 || Vehicle.ModelDate > DateTime.Now.Year + 1)
            {
                errors.Add(new ValidationResult("Please enter a year between 2000 and the current year + 1"));
            }
            if (Vehicle.Mileage < 1000 && !Vehicle.IsNew)
            {
                errors.Add(new ValidationResult("Used vehicles must have over 1000 miles."));
            }
            if (Vehicle.Mileage > 1000 && Vehicle.IsNew)
            {
                errors.Add(new ValidationResult("New vehicles must have under 1000 miles."));
            }
            if (Vehicle.Msrp <= 0)
            {
                errors.Add(new ValidationResult("MSRP must be a positive number."));
            }
            if (Vehicle.VehicleSalePrice > Vehicle.Msrp)
            {
                errors.Add(new ValidationResult("Sale price cannot exceed MSRP."));
            }
            else if (Vehicle.VehicleSalePrice < 0)
            {
                errors.Add(new ValidationResult("Sale price cannot be a negative number"));
            }
            if (string.IsNullOrEmpty(Vehicle.Vin))
            {
                errors.Add(new ValidationResult("A Vin# is required."));
            }
            else if (Vehicle.Vin.Length > 17)
            {
                errors.Add(new ValidationResult("Vin must be 17 or fewer characters."));
            }
            if (string.IsNullOrEmpty(Vehicle.VehicleDescription))
            {
                errors.Add(new ValidationResult("A description is required."));
            }
            if (ImageUpload == null)
            {
                errors.Add(new ValidationResult("File is empty."));


            }
            else if (Path.GetExtension(ImageUpload.FileName) != ".jpg" && Path.GetExtension(ImageUpload.FileName) != ".jpeg" && Path.GetExtension(ImageUpload.FileName) != ".png")
            {
                errors.Add(new ValidationResult("Invalid file upload. Supported extensions: .jpg, .jpeg, .png."));
            }



            return errors;
        }
    }

}