using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Filmuthyrning
{
    public static class ValidationExtension
    {
        //listan med ev. valideringsfel skickas tillbaka i outparametern
        public static bool Validate<T>(this T instance, out ICollection<ValidationResult> validationResults) 
        {
            var validationContext = new ValidationContext(instance); //bestämmer hur objektet ska valideras
            validationResults = new List<ValidationResult>();

            //true om valideringen är helt godkänd, annars false.
            return Validator.TryValidateObject(instance, validationContext, validationResults, true); 
        }
    }
}