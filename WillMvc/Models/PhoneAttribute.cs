using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WillMvc.Models
{
    public class PhoneAttribute : ValidationAttribute
    {
        protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            if (value != null)
            {
                if (Convert.ToString(value).Contains("-") == false)
                {
                    return new ValidationResult("Phone# must have -");
                }
            }
            return ValidationResult.Success;
        }
    }
}