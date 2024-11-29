using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.Create
{
    public class CreateOrdenCommandValidator: AbstractValidator<CreateOrdenCommand>
    {

        public CreateOrdenCommandValidator()
        {
            RuleFor(x => x.Cantidad)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Debe ser mayor a 0");

            RuleFor(x => x.Operacion)
                .Must(o => o.ToString().Length == 1)
                .NotEmpty()
                .Must(value => value == 'C' || value == 'V')
                .WithMessage("El Valor debe contener 'C' por compra o 'V' por venta.");

            RuleFor(x => x.ActivoId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Debe contener un ActivoId asociada");

            RuleFor(x => x.CuentaId)
                .NotEmpty()
                .WithMessage("Debe contener una CuentaId asociada");

        }

    }
}
