using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activos.GetById
{
    public sealed record GetActivoByIdQuery : IRequest<Activo>
    {
        public int Id { get; set; }
    }
}
