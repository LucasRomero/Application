using Core.Entities;
using Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activos.Create
{
    public sealed record CreateActivoRequest
    {
        public string Nombre { get; set; }
        public string Ticker { get; set; }
        public decimal Precio { get; set; }
        public int TipoId { get; set; }
    }
}
