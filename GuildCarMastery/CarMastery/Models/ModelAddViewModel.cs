using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMastery.Models
{
    public class ModelAddViewModel : IValidatableObject
    {
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<ModelListingItem> Models { get; set; }
        public Model newModel { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if(String.IsNullOrEmpty(newModel.ModelName))
            {
                errors.Add(new ValidationResult("Model Name cannot be empty."));
            }
            return errors;
        }
    }
}