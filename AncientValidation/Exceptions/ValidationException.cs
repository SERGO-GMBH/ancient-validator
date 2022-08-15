using System;
using System.Collections.Generic;
using System.Text;

namespace Me.Kuerschner.AncientValidation.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationResult ValidationResult { get; private set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
