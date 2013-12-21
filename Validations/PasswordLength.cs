using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataNissen.Validations
{
    public class PasswordLength : ValidationAttribute
    {
        private readonly int _length;

        public PasswordLength(int length)
            : base("{0} har för få tecken, minst 8 behövs.")
        {
            _length = length;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
              
                var valueAsString = value.ToString();
                if (valueAsString.Length<_length)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }

            }
            return ValidationResult.Success;
        }
    }
}