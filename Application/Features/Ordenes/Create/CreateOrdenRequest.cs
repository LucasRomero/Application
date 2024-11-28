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
    public sealed record CreateOrdenRequest
    {
        public int CuentaId { get; set; }
        public User User { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public char Operacion { get; set; }
        public int TipoActivoId { get; set; }
        public TipoActivo TipoActivo { get; set; }
        public int ActivoId { get; set; }
        public Activo Activo { get; set; }
        public int EstadoId { get; set; } // 0 = "En proceso"
        public EstadoOrden EstadoOrden { get; set; }
    }
}
