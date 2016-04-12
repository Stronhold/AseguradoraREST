using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseguradoraREST.Models.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DNIValidation : ValidationAttribute
    {
        public static ValidationResult DNICorrectlyFormed(string dni)
        {
            if (dni.Length == 9)
            {
                int number = 0;
                bool numeric = int.TryParse(dni.Substring(0, dni.Length - 2), out number);
                if (numeric)
                {
                    string last = dni.Substring(dni.Length - 1);
                    numeric = int.TryParse(last, out number);
                    if (!numeric)
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult("DNI malformed");
        }
    }
}
