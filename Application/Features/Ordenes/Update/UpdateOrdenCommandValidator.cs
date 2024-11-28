using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.Create
{
    public class UpdateOrdenCommandValidator : AbstractValidator<UpdateOrdenCommand>
    {

        public UpdateOrdenCommandValidator()
        {
            RuleFor(x => x.IdOrden)
                .NotEmpty()
                .WithMessage("Debe contener un IdOrden asociada");

            RuleFor(x => x.EstadoId)
                .NotEmpty()
                .WithMessage("Debe contener un EstadoId asociada");
        }
    }
}
