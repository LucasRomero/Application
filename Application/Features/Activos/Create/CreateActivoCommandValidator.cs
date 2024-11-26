using Application.Features.Activos.Create;
using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activos.Create
{
    public class CreateActivoCommandValidator : AbstractValidator<CreateActivoCommand>
    {

        public CreateActivoCommandValidator()
        {
            RuleFor(x => x.Precio)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Debe ser mayor a 0");

            RuleFor(x => x.Nombre)
                .NotEmpty()
                .MaximumLength(32)
                .WithMessage("No mayor a 32 caracteres");
        }

    }
}
