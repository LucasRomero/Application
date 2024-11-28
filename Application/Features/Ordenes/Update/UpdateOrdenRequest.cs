using Core.Entities;
using Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.Update
{
    public sealed record UpdateOrdenRequest
    {
        public int IdOrden { get; set; }
        public int EstadoId { get; set; }
    }
}
