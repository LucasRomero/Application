using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.GetById
{
    public sealed record GetOrdenByIdQuery : IRequest<Orden>
    {
        public int Id { get; set; }
    }
}
