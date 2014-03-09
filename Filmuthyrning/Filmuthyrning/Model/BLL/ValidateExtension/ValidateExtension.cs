using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Filmuthyrning.Model.BLL
{
    public static class ValidateExtension
    {

        //Extension-metod som använder valideringen i ett objekt och validerar det.
        //Out-parametern skickar tillbaka lista med eventuella fel.
        public static bool Validate(this object instance, out ICollection<ValidationResult> valResults)
        {
            ValidationContext valContext = new ValidationContext(instance);
            valResults = new List<ValidationResult>();

            //skickar tillbaka en bool som anger om valideringen lyckades
            return Validator.TryValidateObject(instance, valContext, valResults, true);
        }
    }
}