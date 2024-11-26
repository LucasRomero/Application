using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BApplication.Features.Activos.Delete
{
    public class DeleteOrdenCommandValidator : AbstractValidator<Activo>
    {
        public DeleteOrdenCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }

    }
}
