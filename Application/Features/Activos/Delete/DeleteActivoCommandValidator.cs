using Application.Features.Activos.Delete;
using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BApplication.Features.Activos.Delete
{
    public class DeleteActivoCommandValidator : AbstractValidator<DeleteActivoCommand>
    {
        public DeleteActivoCommandValidator()
        {
            RuleFor(c => c.ActivoId)
                .GreaterThanOrEqualTo(0)
                .NotEmpty();
        }

    }
}
