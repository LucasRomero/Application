using Core.Entities;
using Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ordenes.Create
{
    public sealed record CrearOrdenCommand : IRequest<int>
    {
        public int Cantidad { get; set; }
        public char Operacion { get; set; } // 'C' para compra, 'V' para venta
        public int ActivoId { get; set; }
        public Activo? Activo { get; set; }
        public decimal MontoTotal { get; set; }
        public int EstadoId { get; set; } // 0 = "En proceso"
        public int TipoActivoId { get; set; }
        public int CuentaId { get; set; }
        public TipoActivo? TipoActivo { get; set; }
        public EstadoOrden? Estado { get; set; }

    }
}
