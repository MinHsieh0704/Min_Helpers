using System;
using System.ComponentModel.DataAnnotations;

namespace Min_Helpers.AttributeHelper
{
    /// <summary>
    /// PortAttribute
    /// </summary>
    public class PortAttribute : ValidationAttribute
    {
        private int _minimum = 0;

        private int _maximum = 65535;

        /// <summary>
        /// IsValid
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            int data = 0;
            try
            {
                data  = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return ValidationResult.Success;
            }

            if (data < this._minimum || data > this._maximum)
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must be between {this._minimum} and {this._maximum}.");
            }

            return ValidationResult.Success;
        }
    }
}
