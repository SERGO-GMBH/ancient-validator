using Me.Kuerschner.AncientValidation.Models;
using System.Collections.Generic;
using System.Linq;

namespace Me.Kuerschner.AncientValidation
{
    public partial class ValidationResult
    {
        public IEnumerable<Error> Errors { get; }
        public bool IsValid { get; }

        internal ValidationResult(List<Error> errors)
        {
            Errors = errors;
            IsValid = Errors.Count() == 0;
        }

        public string ToString(char seperator = ',')
        {
            return string.Join(seperator, Errors.Select(item => item.ErrorMessage));
        }
    }
}
