using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Min_Helpers.AttributeHelper
{
    /// <summary>
    /// Validate
    /// </summary>
    public class Validate
    {
        /// <summary>
        /// Try Validate Object
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static void TryValidateObject(object instance)
        {
            try
            {
                if (instance == null)
                {
                    Exception exception = new Exception("validate object can not null");

                    throw exception;
                }

                ValidationContext context = new ValidationContext(instance, null, null);
                List<ValidationResult> result = new List<ValidationResult>();
                if (!Validator.TryValidateObject(instance, context, result, true))
                {
                    ValidationException exception = new ValidationException("validate object error");
                    exception.Data["ValidationResult"] = result.Select((n) => n.ToString()).ToList();

                    throw exception;
                }
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"attribute helper: {ex.Message}", ex);

                throw exception;
            }
        }
    }
}
