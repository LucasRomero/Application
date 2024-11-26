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
    public sealed record GetOrdenByIdQuery : IRequest<Result<Orden>>
    {
        public int Id { get; set; }
    }
}
