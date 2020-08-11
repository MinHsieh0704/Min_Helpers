using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Min_Helpers.AttributeHelper
{
    /// <summary>
    /// CollectionRangeAttribute
    /// </summary>
    public class CollectionRangeAttribute : ValidationAttribute
    {
        private int _minimum { get; set; }

        private int _maximum { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        public CollectionRangeAttribute(int minimum, int maximum)
        {
            this._minimum = minimum;
            this._maximum = maximum;
        }

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

            ICollection data = value as ICollection;
            if (data == null)
            {
                return ValidationResult.Success;
            }

            if (data.Count < this._minimum || data.Count > this._maximum)
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must be between {this._minimum} and {this._maximum}.");
            }

            return ValidationResult.Success;
        }
    }
}
