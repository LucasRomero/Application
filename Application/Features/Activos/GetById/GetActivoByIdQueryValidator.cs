using Application.Features.Activos.GetById;
using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BApplication.Features.Activos.GetById
{
    public class GetActivoByIdQueryValidator : AbstractValidator<GetActivoByIdQuery>
    {
        public GetActivoByIdQueryValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThanOrEqualTo(0)
                .NotEmpty();
        }

    }
}
