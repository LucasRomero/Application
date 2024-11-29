using Application.Features.Ordenes.GetById;
using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BApplication.Features.Ordenes.GetByIdUser
{
    public class GetOrdenByIdUserQueryValidator : AbstractValidator<GetOrdenByIdUserQuery>
    {
        public GetOrdenByIdUserQueryValidator()
        {
            RuleFor(c => c.IdUser)
                .GreaterThan(0)
                .NotEmpty();
        }

    }
}
