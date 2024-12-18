﻿using Application.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public sealed record ValidationError : Error
    {
        public ValidationError(Error[] errors)
            : base(
                "Validation.General",
                "One or more validation errors occurred",
                ErrorType.Validation)
        {
            Errors = errors;
        }

        public Error[] Errors { get; }

        public static ValidationError FromResults(IEnumerable<Result> results)
        {
            return new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
        }
    }
}

