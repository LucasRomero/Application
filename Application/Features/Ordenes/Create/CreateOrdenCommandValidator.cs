using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.Create
{
    public class CreateOrdenCommandValidator: AbstractValidator<CrearOrdenCommand>
    {

        public CreateOrdenCommandValidator()
        {
            RuleFor(x => x.NombreActivo).MaximumLength(32).WithMessage("Maximo superado");

            RuleFor(x => x.Cantidad).GreaterThan(0).WithMessage("Debe ser mayor a 0");

            RuleFor(x => x.Precio).GreaterThan(0).WithMessage("Debe ser mayor a 0");
        }

    }
}
