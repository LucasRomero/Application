using Application.Exceptions;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.GetById
{
    public sealed record GetOrdenByIdUserQuery : IRequest<Result<IEnumerable<Orden>>>
    {
        public int IdUser { get; set; }
    }
}
