using CarMastery.Models.Queries.Inventory;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.Models
{
    public class PurchaseViewModel : IValidatableObject
    {
        public VehicleDetailsItem VehicleDetails { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> PurchaseType { get; set; }
        public Sale Sale { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            decimal lowestVehicleSalePrice = VehicleDetails.VehicleSalePrice * 0.95M;

            if (String.IsNullOrEmpty(Sale.CustomerName))
                errors.Add(new ValidationResult("Name field is required."));

            if (String.IsNullOrEmpty(Sale.Email) && String.IsNullOrEmpty(Sale.Phone))
                errors.Add(new ValidationResult("Email and Phone must not both be empty"));

            if (String.IsNullOrEmpty(Sale.Street1))
                errors.Add(new ValidationResult("Street 1 field is required."));

            if (int.TryParse(Sale.Zip, out int Zip))
                if (Zip > 0)
                {
                    if (Sale.Zip.ToString().Length != 5)
                        errors.Add(new ValidationResult("Zipcode must be 5 digits."));
                }
                else
                    errors.Add(new ValidationResult("Zipcode cannot be a negative number."));
            else
                errors.Add(new ValidationResult("Zip code must be a 5-digit number"));

            EmailAddressAttribute e = new EmailAddressAttribute();
            if (!e.IsValid(Sale.Email))
                errors.Add(new ValidationResult("Email field is not a valid format"));

            if (decimal.TryParse(Sale.Price, out decimal Price))
            {
                if (Decimal.Round(Price, 2) != Price)
                {
                    errors.Add(new ValidationResult("Purchase price field contains too many decimals."));
                }
                else if (Price < lowestVehicleSalePrice)
                {
                    errors.Add(new ValidationResult("Purchase price cannot be less than 95% of sale price."));
                }
                else if (Price > VehicleDetails.Msrp)
                {
                    errors.Add(new ValidationResult("Purchase price cannot exceed MSRP."));
                }
            }
            else
                errors.Add(new ValidationResult("Price is not valid."));

            return errors;
        }
    }
}