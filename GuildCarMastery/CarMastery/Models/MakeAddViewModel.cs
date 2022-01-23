using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarMastery.Models
{
    public class MakeAddViewModel : IValidatableObject
    {
        public IEnumerable<MakeListingItem> Makes { get; set; }
        public Make Make { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (String.IsNullOrEmpty(Make.MakeName))
            {
                errors.Add(new ValidationResult("Model Name cannot be empty."));
            }
            return errors;
        }
    }
}