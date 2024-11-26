using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public IReadOnlyCollection<ValidationError> Errors { get; }

        public ValidationException(IReadOnlyCollection<ValidationError> errors): base("Validation failed")
        {
            Errors = errors;
        }
    }

    public record ValidationError(string propertyName, string errorMessage);

}

