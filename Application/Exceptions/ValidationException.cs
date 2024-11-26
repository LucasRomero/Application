using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{

    public abstract class AppException : Exception
    {
        protected AppException(string message) : base(message) { }
    }

    public class ValidationException : AppException
    {
        public IEnumerable<ValidationError> Errors { get; }

        public ValidationException(IEnumerable<ValidationError> errors)
            : base("Se encontraron errores de validación.")
        {
            Errors = errors;
        }
    }

    public record ValidationError(string propertyName, string errorMessage);

}

