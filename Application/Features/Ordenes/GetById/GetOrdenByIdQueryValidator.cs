using Application.Features.Ordenes.GetById;
using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BApplication.Features.Ordenes.GetById
{
    public class GetOrdenByIdQueryValidator : AbstractValidator<GetOrdenByIdQuery>
    {
        public GetOrdenByIdQueryValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThanOrEqualTo(0)
                .NotEmpty();
        }

    }
}
