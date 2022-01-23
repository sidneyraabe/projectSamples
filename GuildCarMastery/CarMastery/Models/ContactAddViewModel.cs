using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarMastery.Models
{
    public class ContactAddViewModel : IValidatableObject
    {
        public ContactUs ContactUs { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (String.IsNullOrEmpty(ContactUs.Name))
            {
                errors.Add(new ValidationResult("Name is a required field."));
            }
            if (String.IsNullOrEmpty(ContactUs.Message))
            {
                errors.Add(new ValidationResult("Message is a required field."));
            }
            if (String.IsNullOrEmpty(ContactUs.Phone) && String.IsNullOrEmpty(ContactUs.Email))
            {
                errors.Add(new ValidationResult("Email and Phone fields cannot both be empty."));
            }
            return errors;
        }
    }
}